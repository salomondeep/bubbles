using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace SDNApp
{
    public partial class Openstack_Manager : Form
    {
        private static string login_file = AppDomain.CurrentDomain.BaseDirectory.ToString() + SDNApp.Properties.Settings.Default.user_login_file;
        private static string auth_token_file = AppDomain.CurrentDomain.BaseDirectory.ToString() + SDNApp.Properties.Settings.Default.auth_token_file;
        private HashSet<Control> errorControls = new HashSet<Control>();
        private string ip = "";

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
                //errorControls.Remove(textBox);
            }
        }

        private void Openstack_Manager_Load(object sender, EventArgs e)
        {
            errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        }

        // funcao para testes de connection com um webservice
        private Boolean testConnectionWebService(string URI, HttpWebRequest request)
        {
            try
            {
                request.GetResponse();
                Debug.WriteLine("### Acedeu ao URI: " + URI + " ###");
                return true;
            }
            catch (Exception)
            {
                Debug.WriteLine("Nao foi possivel aceder ao URI: " + URI + " ###");
                MessageBox.Show("ERROR 1: " + URI + " - NOT AVAILABLE");
                return false;
            }
        }

        private void login(string URL)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            JObject login_body = get_login_body();
            //MessageBox.Show(login_body.ToString());
            byte[] body = Encoding.UTF8.GetBytes(login_body.ToString());

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            request.ContentLength = body.Length;

            if (testConnection(URL, request))
            {
                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(body, 0, body.Length);
                }

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

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
                JObject jobj = JObject.Parse(json);
                MessageBox.Show(jobj.ToString());

                var auth = jobj["auth"];
                var identity = auth["identity"];
                var passwd = identity["password"];
                var user = passwd["user"];

                string password = (string)user["password"];
                user["password"] = textBoxPassword.Text;
                user["user"] = textBoxUsername.Text;

                //DEBUG
                //MessageBox.Show(auth.ToString());
                //MessageBox.Show(identity.ToString());
                //MessageBox.Show(passwd.ToString());
                MessageBox.Show(user.ToString());
                MessageBox.Show(user["password"].ToString());
            }
        }

        private void btn_logout_Click(object sender, EventArgs e)
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

                //ERROR, need to find other way to open the file [used by another process]

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                response.Close();
            }

            using (StreamWriter writetext = new StreamWriter(auth_token_file))
            {
                writetext.WriteLine(string.Empty);
            }
        }

        private Boolean testConnection(string URI, HttpWebRequest request)
        {
            try
            {
                request.GetResponse();
                Debug.WriteLine("### Acedeu ao URI: " + URI + " ###");
                this.labelStatus.ForeColor = System.Drawing.Color.Green;
                this.labelStatus.Text = "OK";
                return true;
            }
            catch (Exception)
            {
                Debug.WriteLine("Nao foi possivel aceder ao URI: " + URI + " ###");
                MessageBox.Show("ERROR 1: " + URI + " - NOT AVAILABLE");
                this.labelStatus.ForeColor = System.Drawing.Color.Red;
                this.labelStatus.Text = "OFF";
                return false;
            }
        }
    }
}