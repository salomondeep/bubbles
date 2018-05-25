using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SDNApp
{
    public partial class Openstack_Flavor_Management : Form
    {
        public string ipv4 = "";
        private static string auth_token_file = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"app_data\auth_token");
        private static string flavor_path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"app_data\create_flavor.json");
        private String responseString = "";
        public Openstack_Manager openstack = null;
        private List<Flavor> listFlavors = new List<Flavor>();

        public Openstack_Flavor_Management()
        {
            InitializeComponent();
        }

        private void Openstack_Flavor_Management_Load(object sender, EventArgs e)
        {
            listBoxFlavors.Items.Clear();
            try
            {
                using (StreamReader r = new StreamReader(auth_token_file))
                {
                    var token = r.ReadToEnd();
                    string URI = "http://" + this.ipv4 + "/compute/v2.1/flavors/detail";

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
                    foreach (var result in json_object["flavors"])
                    {
                        create_flavor(result);
                        //MessageBox.Show(result.ToString());
                    }
                    response.Close();
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

        private void create_flavor(JToken jtoken)
        {
            Flavor flavor_obj = new Flavor();

            flavor_obj.id = (string)jtoken["id"];
            flavor_obj.name = (string)jtoken["name"];
            flavor_obj.vcpu = (int)jtoken["vcpus"];
            flavor_obj.ram = (int)jtoken["ram"];
            flavor_obj.disk = (int)jtoken["disk"];

            listFlavors.Add(flavor_obj);
            listBoxFlavors.Items.Add(flavor_obj);
        }

        private void listBoxFlavors_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxFlavors.SelectedItem != null)
            {
                btnDelete.Enabled = true;
                Flavor flavor_obj = listBoxFlavors.SelectedItem as Flavor;
                labelRAM.Text = flavor_obj.ram.ToString();
                labelVCPU.Text = flavor_obj.vcpu.ToString();
                labelDISK.Text = flavor_obj.disk.ToString();
                groupBox1.Visible = true;
            }
            else
            {
                labelRAM.Text = "";
                labelVCPU.Text = "";
                labelDISK.Text = "";
                //listBoxFlavors.ClearSelected();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Flavor flavor_obj2 = listBoxFlavors.SelectedItem as Flavor;
            string result = string.Empty;
            using (StreamReader r = new StreamReader(auth_token_file))
            {
                var token = r.ReadToEnd();

                string URL = "http://" + this.ipv4 + "/compute/v2.1/flavors/" + flavor_obj2.id;

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
                request.Method = "DELETE";
                request.Headers.Add("X-Auth-Token", token);

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                response.Close();
                listBoxFlavors.ClearSelected();
                listFlavors.Remove(flavor_obj2);
                groupBox1.Visible = false;
                listBoxFlavors.Items.Remove(flavor_obj2);
                openstack.ListFlavors.Remove(flavor_obj2);
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            textBoxName.Visible = true;
            textBoxRAM.Visible = true;
            textBoxVCPU.Visible = true;
            textBoxDISK.Visible = true;
            btnApply.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            labelRAM.Text = "";
            labelVCPU.Text = "";
            labelDISK.Text = "";
            listBoxFlavors.ClearSelected();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text == "" || textBoxRAM.Text == "" || textBoxVCPU.Text == "" || textBoxDISK.Text == "")
            {
                MessageBox.Show("You must insert the values");
            }
            else
            {
                string result = string.Empty;
                using (StreamReader r = new StreamReader(flavor_path))
                {
                    var json = r.ReadToEnd();
                    MessageBox.Show(json.ToString());
                    JObject jobj = JObject.Parse(json);

                    var flavor = jobj["flavor"];
                    flavor["name"] = textBoxName.Text;
                    flavor["ram"] = Int32.Parse(textBoxRAM.Text);
                    flavor["vcpus"] = Int32.Parse(textBoxVCPU.Text);
                    flavor["disk"] = Int32.Parse(textBoxDISK.Text);

                    try
                    {
                        using (StreamReader r2 = new StreamReader(auth_token_file))
                        {
                            var token = r2.ReadToEnd();
                            var URL = "http://" + ipv4 + "/compute/v2.1/flavors";

                            UTF8Encoding encoding = new UTF8Encoding();
                            byte[] body = Encoding.UTF8.GetBytes(jobj.ToString());

                            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
                            request.Method = "POST";
                            request.Headers.Add("X-Auth-Token", token);
                            request.ContentType = "application/json";
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

                            var flavor_aux = json_object["flavor"];

                            Flavor flavor_obj = new Flavor();
                            flavor_obj.name = textBoxName.Text;
                            flavor_obj.ram = Int32.Parse(textBoxRAM.Text);
                            flavor_obj.vcpu = Int32.Parse(textBoxVCPU.Text);
                            flavor_obj.disk = Int32.Parse(textBoxDISK.Text);
                            flavor_obj.id = (string)flavor_aux["id"];

                            listFlavors.Add(flavor_obj);
                            listBoxFlavors.Items.Add(flavor_obj);
                            openstack.ListFlavors.Add(flavor_obj);
                            response.Close();
                        }
                    }
                    catch (WebException ex)
                    {
                        MessageBox.Show("Erro inesperado");
                        //using (var stream = ex.Response.GetResponseStream())
                        //using (var reader = new StreamReader(stream))
                        //{
                        //    JObject jobject = JObject.Parse(reader.ReadToEnd());
                        //    var error = jobject["error"];
                        //    var code = error["code"];
                        //    var title = error["title"];
                        //    var message = error["message"];

                        //    MessageBox.Show("Code: " + code + "\n" + title + "\n" + message);
                        //    //DEBUG
                        //    //MessageBox.Show(jobject.ToString());
                        //}
                    }
                }
            }

            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            textBoxName.Visible = false;
            textBoxRAM.Visible = false;
            textBoxVCPU.Visible = false;
            textBoxDISK.Visible = false;
            btnApply.Visible = false;
        }
    }
}