using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace SDNApp
{
    public partial class Openstack_Manager : Form
    {
        private static string login_file = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"app_data\user_login.json");
        private static string login_scoped_file = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"app_data\login_with_scope.json");
        private static string auth_token_file = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"app_data\auth_token");
        private HashSet<Control> errorControls = new HashSet<Control>();
        public string ip = "";
        private String responseString = "";
        private User user = null;

        public Openstack_Manager()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void btnAccess_Click(object sender, EventArgs e)
        {
            textBoxIP.Tag = "You need to insert an IPv4 address!";
            textBoxUsername.Tag = "You need to insert an username!";
            textBoxPassword.Tag = "You need to insert a password";

            //Check if the fields are empty
            if (textBoxIP.Text == "" || textBoxUsername.Text == "" || textBoxPassword.Text == "")
            {
                ValidateFields(textBoxIP, EventArgs.Empty);
                ValidateFields(textBoxUsername, EventArgs.Empty);
                ValidateFields(textBoxPassword, EventArgs.Empty);
            }
            else
            {
                IPAddress ipAddress;
                if (IPAddress.TryParse(textBoxIP.Text, out ipAddress))
                {
                    //Debug.WriteLine("### VALID IP ###");
                    //MessageBox.Show("### VALID IP ###");

                    this.ip = textBoxIP.Text;
                    string URI = "http://" + this.ip + "/identity/v3/auth/tokens";

                    login(URI);
                    this.listBoxProjects.Enabled = true;
                }
                else
                {
                    //Debug.WriteLine("### INVALID IP ###");
                    //MessageBox.Show("### INVALID IP ###");
                }
            }
        }

        private void ValidateFields(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;

            if (textBox.Text == "")
            {
                errorProvider1.SetError(textBox, (string)textBox.Tag);
                errorControls.Add(textBox);
            }
            else
            {
                errorProvider1.SetError(textBox, null);
                errorControls.Remove(textBox);
            }
        }

        private void Openstack_Manager_Load(object sender, EventArgs e)
        {
            errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        }

        private void login(string URL)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            JObject login_body = get_login_body();
            byte[] body = Encoding.UTF8.GetBytes(login_body.ToString());

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
                request.Method = "POST";
                request.ContentType = "application/json";
                request.Accept = "application/json";
                request.ContentLength = body.Length;

                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(body, 0, body.Length);
                }

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                if (response.StatusCode == HttpStatusCode.Created)
                {
                    //MessageBox.Show("Im here");
                    using (Stream stream = response.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                        responseString = reader.ReadToEnd();
                    }
                    JObject json_object = JObject.Parse(responseString);
                    //MessageBox.Show(json_object.ToString());

                    //HERE WE CREATE THE USER
                    createUser(json_object);

                    WebHeaderCollection headers = response.Headers;

                    for (int i = 0; i < headers.Count; ++i)
                    {
                        if (headers.Keys[i].Equals("X-Subject-Token"))
                        {
                            //MessageBox.Show("Got the token bruh!");
                            File.WriteAllText(auth_token_file, headers[i]);
                            //MessageBox.Show(headers[i].ToString());
                        }
                    }
                    //MessageBox.Show(response.StatusCode.ToString());

                    response.Close();

                    this.labelStatus.ForeColor = System.Drawing.Color.Green;
                    this.labelStatus.Text = "OK";
                    this.labelStatus.Visible = true;
                    this.btn_logout.Visible = true;
                    this.labelUser.Text = "Welcome " + user.name + ", connected to Openstack with IP " + this.ip;
                    this.labelUser.Visible = true;
                    this.textBoxIP.Enabled = false;
                    this.textBoxUsername.Enabled = false;
                    this.textBoxPassword.Enabled = false;
                    this.btn_change_password.Visible = true;
                    this.btnAccess.Enabled = false;
                    this.btnScope.Enabled = true;

                    //HERE WE GET THE PROJECTS
                    get_projects();
                }
            }
            catch (WebException ex)
            {
                using (var stream = ex.Response.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                    JObject jobject = JObject.Parse(reader.ReadToEnd());
                    var error = jobject["error"];
                    var code = error["code"];
                    var title = error["title"];

                    MessageBox.Show("Code: " + code + "\n" + title + "\n" + "Verify password");
                    //DEBUG
                    //MessageBox.Show(jobject.ToString());
                }
            }
        }

        private JObject get_login_body()
        {
            string result = string.Empty;
            using (StreamReader r = new StreamReader(login_file))
            {
                var json = r.ReadToEnd();
                JObject jobj = JObject.Parse(json);
                //MessageBox.Show(jobj.ToString());

                var auth = jobj["auth"];
                var identity = auth["identity"];
                var passwd = identity["password"];
                var user = passwd["user"];

                string password = (string)user["password"];
                user["password"] = textBoxPassword.Text;
                user["name"] = textBoxUsername.Text;

                //DEBUG
                //MessageBox.Show(auth.ToString());
                //MessageBox.Show(identity.ToString());
                //MessageBox.Show(passwd.ToString());

                return jobj;
            }
        }

        //BUTTON FOR DEBUG
        private void button2_Click(object sender, EventArgs e)
        {
            string result = string.Empty;
            using (StreamReader r = new StreamReader(login_file))
            {
                var json = r.ReadToEnd();
                MessageBox.Show(json.ToString());
            }
        }

        public void btn_logout_Click(object sender, EventArgs e)
        {
            string result = string.Empty;
            using (StreamReader r = new StreamReader(auth_token_file))
            {
                var token = r.ReadToEnd();

                string URL = "http://" + this.ip + "/identity/v3/auth/tokens";

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
                request.Method = "DELETE";
                request.Headers.Add("X-Auth-Token", token);
                request.Headers.Add("X-Subject-Token", token);

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                response.Close();
            }

            using (StreamWriter writetext = new StreamWriter(auth_token_file))
            {
                writetext.WriteLine(string.Empty);
            }

            using (StreamReader r = new StreamReader(auth_token_file))
            {
                var json = r.ReadToEnd();
                MessageBox.Show("I logged out");
            }

            //deleteUser();

            this.labelStatus.ForeColor = System.Drawing.Color.Red;
            this.labelStatus.Text = "Session closed";
            this.btn_logout.Visible = false;
            this.labelUser.Visible = false;
            this.btn_change_password.Visible = false;
            this.btnScope.Enabled = false;

            this.textBoxIP.Text = "";
            this.textBoxUsername.Text = "";
            this.textBoxPassword.Text = "";
            this.textBoxIP.Enabled = true;
            this.textBoxUsername.Enabled = true;
            this.textBoxPassword.Enabled = true;
            this.btnAccess.Enabled = true;

            this.listBoxProjects.Items.Clear();
            this.listBoxServers.Items.Clear();
            this.groupServerInfo.Visible = false;
            this.btnGetServers.Enabled = false;
            this.btnON.Enabled = false;
            this.btnSUS.Enabled = false;
            this.btnOFF.Enabled = false;
            this.btnON.Visible = false;
            this.btnSUS.Visible = false;
            this.btnOFF.Visible = false;
        }

        //CREATE USER
        private void createUser(JObject json_object)
        {
            var token_json = json_object["token"];
            var user_json = token_json["user"];

            user = new User();
            user.id = (string)user_json["id"];
            user.name = (string)user_json["name"];

            //DEBUG
            //MessageBox.Show(user.ToString());
        }

        //GET PROJECTS
        private void get_projects()
        {
            using (StreamReader r = new StreamReader(auth_token_file))
            {
                var token = r.ReadToEnd();
                string URI = "http://" + this.ip + "/identity/v3/users/" + user.id + "/projects";

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URI);
                request.Method = "GET";
                request.Headers.Add("X-Auth-Token", token);

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                using (Stream stream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                    responseString = reader.ReadToEnd();
                }

                JObject json_object = JObject.Parse(responseString);

                //DEBUG
                //MessageBox.Show(json_object.ToString());

                foreach (var result in json_object["projects"])
                {
                    create_project(result);
                }

                response.Close();
            }
        }

        //CREATE PROJECT
        private void create_project(JToken jtoken)
        {
            //MessageBox.Show(jtoken.ToString());
            Project project = new Project();
            project.id = (string)jtoken["id"];
            project.name = (string)jtoken["name"];
            project.is_enabled = (Boolean)jtoken["enabled"];
            listBoxProjects.Items.Add(project);
        }

        //DELETE USER
        private void deleteUser()
        {
            user = null;
        }

        private void btnScope_Click(object sender, EventArgs e)
        {
            if (listBoxProjects.SelectedIndex == -1)
            {
                //CHANGE LATER TO ERROR PROVIDER
                MessageBox.Show("Must select a project first!");
            }
            else
            {
                login_scoped();
                this.btnGetServers.Enabled = true;
            }
        }

        private void listBoxProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.btnScope.Enabled = true;
            this.btnScope.Visible = true;
        }

        private void login_scoped()
        {
            /////////////////////LOGOUT FIRST////////////////////////////////////////////////////////////
            string result = string.Empty;
            using (StreamReader r = new StreamReader(auth_token_file))
            {
                var token = r.ReadToEnd();

                string URL = "http://" + this.ip + "/identity/v3/auth/tokens";

                HttpWebRequest request1 = (HttpWebRequest)WebRequest.Create(URL);
                request1.Method = "DELETE";
                request1.Headers.Add("X-Auth-Token", token);
                request1.Headers.Add("X-Subject-Token", token);

                HttpWebResponse response1 = (HttpWebResponse)request1.GetResponse();

                response1.Close();
            }

            using (StreamWriter writetext = new StreamWriter(auth_token_file))
            {
                writetext.WriteLine(string.Empty);
            }

            using (StreamReader r = new StreamReader(auth_token_file))
            {
                var json = r.ReadToEnd();
                //MessageBox.Show("I logged out");
            }

            /////////////////////LOGOUT ENDED////////////////////////////////////////////////////////////

            /////////////////////LOGIN SCOPED////////////////////////////////////////////////////////////

            UTF8Encoding encoding = new UTF8Encoding();
            JObject login_body = get_login_scped_body();
            byte[] body = Encoding.UTF8.GetBytes(login_body.ToString());

            string URI = "http://" + this.ip + "/identity/v3/auth/tokens";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URI);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            request.ContentLength = body.Length;

            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(body, 0, body.Length);
            }

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            using (Stream stream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                responseString = reader.ReadToEnd();
            }
            JObject json_object = JObject.Parse(responseString);
            //MessageBox.Show(json_object.ToString());

            WebHeaderCollection headers = response.Headers;

            for (int i = 0; i < headers.Count; ++i)
            {
                if (headers.Keys[i].Equals("X-Subject-Token"))
                {
                    //MessageBox.Show("Got the token bruh!");
                    File.WriteAllText(auth_token_file, headers[i]);
                }
            }
            //MessageBox.Show(response.StatusCode.ToString());

            response.Close();

            MessageBox.Show("Consegui fazer scoped login");

            /////////////////////LOGOUT SCOPED ENDED////////////////////////////////////////////////////////////
        }

        private JObject get_login_scped_body()
        {
            string result = string.Empty;
            using (StreamReader r = new StreamReader(login_scoped_file))
            {
                var json = r.ReadToEnd();
                JObject jobj = JObject.Parse(json);
                //MessageBox.Show(jobj.ToString());

                var auth = jobj["auth"];
                var identity = auth["identity"];
                var passwd = identity["password"];
                var user = passwd["user"];

                string password = (string)user["password"];
                user["password"] = textBoxPassword.Text;
                user["name"] = textBoxUsername.Text;

                var scope = auth["scope"];
                var project = scope["project"];

                Project project_object = new Project();
                project_object = listBoxProjects.SelectedItem as Project;

                project["id"] = project_object.id;

                //DEBUG
                //MessageBox.Show(project["id"].ToString());
                //MessageBox.Show(auth.ToString());
                //MessageBox.Show(identity.ToString());
                //MessageBox.Show(passwd.ToString());

                return jobj;
            }
        }

        private void btn_change_password_Click(object sender, EventArgs e)
        {
            Openstack_Change_Password view = new Openstack_Change_Password();
            view.user_id = this.user.id;
            view.ip = this.ip;
            view.openstack = this;
            view.Show();
        }

        private void btnGetServers_Click(object sender, EventArgs e)
        {
            listBoxServers.Items.Clear();
            try
            {
                using (StreamReader r = new StreamReader(auth_token_file))
                {
                    var token = r.ReadToEnd();
                    string URI = "http://" + this.ip + "/compute/v2.1/servers/detail";

                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URI);
                    request.Method = "GET";
                    request.Headers.Add("X-Auth-Token", token);

                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                    using (Stream stream = response.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                        responseString = reader.ReadToEnd();
                    }

                    JObject json_object = JObject.Parse(responseString);

                    //MessageBox.Show(json_object.ToString());

                    createServers(json_object);
                    this.listBoxServers.Enabled = true;
                    this.btnON.Visible = true;
                    this.btnSUS.Visible = true;
                    this.btnOFF.Visible = true;
                }
            }
            catch (WebException ex)
            {
                using (var stream = ex.Response.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                    JObject jobject = JObject.Parse(reader.ReadToEnd());
                    var error = jobject["error"];
                    var code = error["code"];
                    var title = error["title"];

                    MessageBox.Show("Code: " + code + "\n" + title + "\n" + "Verify password");
                    //DEBUG
                    //MessageBox.Show(jobject.ToString());
                }
            }
        }

        private void createServers(JObject json_object)
        {
            foreach (var server in json_object["servers"])
            {
                Server server_obj = new Server();

                var id = server["id"];
                var status = server["status"];
                var name = server["name"];
                //MessageBox.Show(id.ToString());

                var addresses = server["addresses"];

                foreach (var interfaces in addresses["private"])
                {
                    //MessageBox.Show(interfaces.ToString());
                    Interface interface_obj = new Interface();

                    interface_obj.mac_address = (string)interfaces["OS-EXT-IPS-MAC:mac_addr"];
                    interface_obj.version = (int)interfaces["version"];
                    interface_obj.ip_address = (string)interfaces["addr"];
                    interface_obj.type = (string)interfaces["OS-EXT-IPS:type"];

                    server_obj.interfaces.Add(interface_obj);
                }

                var flavor = server["flavor"];
                var flavor_id = flavor["id"];

                //GET THE FLAVOR
                try
                {
                    using (StreamReader r = new StreamReader(auth_token_file))
                    {
                        var token = r.ReadToEnd();
                        string URI = "http://" + this.ip + "/compute/v2.1/flavors/" + flavor_id;

                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URI);
                        request.Method = "GET";
                        request.Headers.Add("X-Auth-Token", token);

                        HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                        using (Stream stream = response.GetResponseStream())
                        {
                            StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                            responseString = reader.ReadToEnd();
                        }

                        JObject json_object2 = JObject.Parse(responseString);

                        //MessageBox.Show(json_object2.ToString());
                        Flavor flavor_obj = new Flavor();

                        var flavor_json = json_object2["flavor"];

                        flavor_obj.id = (int)flavor_json["id"];
                        flavor_obj.name = (string)flavor_json["name"];
                        flavor_obj.ram = (int)flavor_json["ram"];
                        flavor_obj.vcpu = (int)flavor_json["vcpus"];
                        flavor_obj.disk = (int)flavor_json["disk"];

                        server_obj.flavor = flavor_obj;
                    }
                }
                catch (WebException ex)
                {
                    using (var stream = ex.Response.GetResponseStream())
                    using (var reader = new StreamReader(stream))
                    {
                        JObject jobject = JObject.Parse(reader.ReadToEnd());
                        var error = jobject["error"];
                        var code = error["code"];
                        var title = error["title"];

                        MessageBox.Show("Code: " + code + "\n" + title + "\n" + "Verify password");
                        //DEBUG
                        //MessageBox.Show(jobject.ToString());
                    }
                }

                server_obj.id = (string)id;
                server_obj.status = (string)status;
                server_obj.name = (string)name;

                listBoxServers.Items.Add(server_obj);
            }
        }

        private void listBoxServers_SelectedIndexChanged(object sender, EventArgs e)
        {
            Server server = listBoxServers.SelectedItem as Server;

            if (server.status == "ACTIVE")
            {
                labelState.ForeColor = System.Drawing.Color.Green;
                this.btnON.Enabled = false;
                this.btnSUS.Enabled = true;
                this.btnOFF.Enabled = true;
            }
            else if (server.status == "SUSPENDED")
            {
                labelState.ForeColor = System.Drawing.Color.Orange;
                this.btnON.Enabled = true;
                this.btnSUS.Enabled = false;
                this.btnOFF.Enabled = false;
            }
            else if (server.status == "SHUTOFF")
            {
                labelState.ForeColor = System.Drawing.Color.Red;
                this.btnON.Enabled = true;
                this.btnSUS.Enabled = false;
                this.btnOFF.Enabled = false;
            }

            labelState.Text = server.status;
            labelCPU.Text = server.flavor.vcpu.ToString();
            labelRAM.Text = server.flavor.ram.ToString();
            labelDisk.Text = server.flavor.disk.ToString();
            groupServerInfo.Visible = true;
        }

        private void btnON_Click(object sender, EventArgs e)
        {
            Server server = listBoxServers.SelectedItem as Server;
            string ONBody = "";

            if (server.status == "SUSPENDED")
            {
                ONBody = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"app_data\ServerResume.json");
            }
            else if (server.status == "SHUTOFF")
            {
                ONBody = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"app_data\ServerON.json");
            }

            try
            {
                using (StreamReader r = new StreamReader(auth_token_file))
                {
                    var token = r.ReadToEnd();
                    string URI = "http://" + this.ip + "/compute/v2/servers/" + server.id + "/action";
                    JObject jobj = new JObject();

                    using (StreamReader aux = new StreamReader(ONBody))
                    {
                        var json = aux.ReadToEnd();
                        jobj = JObject.Parse(json);
                    }

                    byte[] body = Encoding.UTF8.GetBytes(jobj.ToString());

                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URI);
                    request.Method = "POST";
                    request.Headers.Add("X-Auth-Token", token);
                    request.ContentType = "application/json";
                    request.Accept = "application/json";
                    request.ContentLength = body.Length;

                    using (Stream stream = request.GetRequestStream())
                    {
                        stream.Write(body, 0, body.Length);
                    }

                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                    //using (Stream stream = response.GetResponseStream())
                    //{
                    //    StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                    //    responseString = reader.ReadToEnd();
                    //}
                    server.status = "ACTIVE";
                    listBoxServers_SelectedIndexChanged(null, null);
                }
            }
            catch (WebException ex)
            {
                using (var stream = ex.Response.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                    JObject jobject = JObject.Parse(reader.ReadToEnd());
                    var error = jobject["error"];
                    var code = error["code"];
                    var title = error["title"];

                    MessageBox.Show("Code: " + code + "\n" + title + "\n" + "Verify password");
                    //DEBUG
                    //MessageBox.Show(jobject.ToString());
                }
            }
        }

        private void btnSUS_Click(object sender, EventArgs e)
        {
            Server server = listBoxServers.SelectedItem as Server;
            string SUSBody = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"app_data\ServerSUS.json");

            try
            {
                using (StreamReader r = new StreamReader(auth_token_file))
                {
                    var token = r.ReadToEnd();
                    string URI = "http://" + this.ip + "/compute/v2/servers/" + server.id + "/action";
                    JObject jobj = new JObject();

                    using (StreamReader aux = new StreamReader(SUSBody))
                    {
                        var json = aux.ReadToEnd();
                        jobj = JObject.Parse(json);
                    }

                    byte[] body = Encoding.UTF8.GetBytes(jobj.ToString());

                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URI);
                    request.Method = "POST";
                    request.Headers.Add("X-Auth-Token", token);
                    request.ContentType = "application/json";
                    request.Accept = "application/json";
                    request.ContentLength = body.Length;

                    using (Stream stream = request.GetRequestStream())
                    {
                        stream.Write(body, 0, body.Length);
                    }

                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                    //using (Stream stream = response.GetResponseStream())
                    //{
                    //    StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                    //    responseString = reader.ReadToEnd();
                    //}
                    server.status = "SUSPENDED";
                    listBoxServers_SelectedIndexChanged(null, null);
                }
            }
            catch (WebException ex)
            {
                using (var stream = ex.Response.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                    JObject jobject = JObject.Parse(reader.ReadToEnd());
                    var error = jobject["error"];
                    var code = error["code"];
                    var title = error["title"];

                    MessageBox.Show("Code: " + code + "\n" + title + "\n" + "Verify password");
                    //DEBUG
                    //MessageBox.Show(jobject.ToString());
                }
            }
        }

        private void btnOFF_Click(object sender, EventArgs e)
        {
            Server server = listBoxServers.SelectedItem as Server;
            string OFFBody = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"app_data\ServerOFF.json");

            try
            {
                using (StreamReader r = new StreamReader(auth_token_file))
                {
                    var token = r.ReadToEnd();
                    string URI = "http://" + this.ip + "/compute/v2/servers/" + server.id + "/action";
                    JObject jobj = new JObject();

                    using (StreamReader aux = new StreamReader(OFFBody))
                    {
                        var json = aux.ReadToEnd();
                        jobj = JObject.Parse(json);
                    }

                    byte[] body = Encoding.UTF8.GetBytes(jobj.ToString());

                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URI);
                    request.Method = "POST";
                    request.Headers.Add("X-Auth-Token", token);
                    request.ContentType = "application/json";
                    request.Accept = "application/json";
                    request.ContentLength = body.Length;

                    using (Stream stream = request.GetRequestStream())
                    {
                        stream.Write(body, 0, body.Length);
                    }

                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                    //using (Stream stream = response.GetResponseStream())
                    //{
                    //    StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                    //    responseString = reader.ReadToEnd();
                    //}
                    server.status = "SHUTOFF";
                    listBoxServers_SelectedIndexChanged(null, null);
                }
            }
            catch (WebException ex)
            {
                using (var stream = ex.Response.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                    JObject jobject = JObject.Parse(reader.ReadToEnd());
                    var error = jobject["error"];
                    var code = error["code"];
                    var title = error["title"];

                    MessageBox.Show("Code: " + code + "\n" + title + "\n" + "Verify password");
                    //DEBUG
                    //MessageBox.Show(jobject.ToString());
                }
            }
        }
    }
}