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
    public partial class Openstack_Image_Management : Form
    {
        public string ipv4 = "";
        private static string auth_token_file = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"app_data\auth_token");
        private String responseString = "";
        public Openstack_Manager openstack = null;
        private List<Image> listImages = new List<Image>();

        public Openstack_Image_Management()
        {
            InitializeComponent();
        }

        private void Openstack_Image_Management_Load(object sender, EventArgs e)
        {
            listBoxImage.Items.Clear();
            try
            {
                using (StreamReader r = new StreamReader(auth_token_file))
                {
                    var token = r.ReadToEnd();
                    string URI = "http://" + this.ipv4 + "/compute/v2.1/images/detail";

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
                    foreach (var result in json_object["images"])
                    {
                        create_image(result);
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

        private void create_image(JToken result)
        {
            Image image_obj = new Image();

            image_obj.id = (string)result["id"];
            image_obj.name = (string)result["name"];
            image_obj.size = (int)result["OS-EXT-IMG-SIZE:size"] / 1000000;
            //MessageBox.Show(image_obj.size.ToString());

            if (result["status"].ToString() == "ACTIVE")
            {
                image_obj.status = true;
            }
            else
            {
                image_obj.status = false;
            }

            listImages.Add(image_obj);
            listBoxImage.Items.Add(image_obj);
        }

        private void listBoxImage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxImage.SelectedItem != null)
            {
                Image image_obj = listBoxImage.SelectedItem as Image;
                labelSize.Text = image_obj.size.ToString();

                if (image_obj.status)
                {
                    labelStatus.ForeColor = System.Drawing.Color.Green;
                    labelStatus.Text = "ACTIVE";
                }
                else
                {
                    labelStatus.ForeColor = System.Drawing.Color.Red;
                    labelStatus.Text = "INACTIVE";
                }
                btnDelete.Enabled = true;
                groupBox1.Visible = true;
            }
            else
            {
                groupBox1.Visible = false;
                labelSize.Text = "";
                labelStatus.Text = "";
                btnDelete.Enabled = false;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Image image_obj2 = listBoxImage.SelectedItem as Image;
            string result = string.Empty;
            using (StreamReader r = new StreamReader(auth_token_file))
            {
                var token = r.ReadToEnd();

                string URL = "http://" + this.ipv4 + "/compute/v2.1/images/" + image_obj2.id;

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
                request.Method = "DELETE";
                request.Headers.Add("X-Auth-Token", token);

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                response.Close();
                listBoxImage.ClearSelected();
                listImages.Remove(image_obj2);
                groupBox1.Visible = false;
                listBoxImage.Items.Remove(image_obj2);
                openstack.ListImages.Remove(image_obj2);
            }
        }
    }
}