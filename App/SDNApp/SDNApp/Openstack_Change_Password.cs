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
    public partial class Openstack_Change_Password : Form
    {
        private static string change_passwd_file = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"app_data\change_password.json");
        public string user_id = "";
        public string ip = "";
        private HashSet<Control> errorControls = new HashSet<Control>();
        public Openstack_Manager openstack = null;

        public Openstack_Change_Password()
        {
            InitializeComponent();
        }

        private void Openstack_Change_Password_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(user_id);
        }

        private void btn_apply_Click(object sender, EventArgs e)
        {
            textBoxCurrentPassword.Tag = "You need to insert the current password!";
            textBoxNewPassword.Tag = "You need to insert the new password!";
            textBoxConfirmPassword.Tag = "You need to insert the confirm password!";

            //Check if the fields are empty
            if (textBoxCurrentPassword.Text == "" || textBoxNewPassword.Text == "" || textBoxConfirmPassword.Text == "")
            {
                ValidateFields(textBoxCurrentPassword, EventArgs.Empty);
                ValidateFields(textBoxNewPassword, EventArgs.Empty);
                ValidateFields(textBoxConfirmPassword, EventArgs.Empty);
            }
            else
            {
                if (textBoxNewPassword.Text != textBoxConfirmPassword.Text)
                {
                    MessageBox.Show("Passwords must match!");
                    textBoxCurrentPassword.Text = "";
                    textBoxNewPassword.Text = "";
                    textBoxConfirmPassword.Text = "";
                    return;
                }
                else
                {
                    string result = string.Empty;
                    using (StreamReader r = new StreamReader(change_passwd_file))
                    {
                        var json = r.ReadToEnd();
                        JObject jobj = JObject.Parse(json);

                        var user = jobj["user"];
                        user["password"] = textBoxNewPassword.Text;
                        user["original_password"] = textBoxCurrentPassword.Text;

                        try
                        {
                            openstack.btn_logout_Click(null, null);
                            var URL = "http://" + ip + "/identity/v3/users/" + user_id + "/password";

                            UTF8Encoding encoding = new UTF8Encoding();
                            byte[] body = Encoding.UTF8.GetBytes(jobj.ToString());
                            //MessageBox.Show(jobj.ToString());
                            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
                            request.Method = "POST";
                            request.ContentType = "application/json";
                            request.ContentLength = body.Length;

                            using (Stream stream = request.GetRequestStream())
                            {
                                stream.Write(body, 0, body.Length);
                            }

                            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                            // TRY CATCH THE ERRORS HERE SAME PASSWD CANNOT BE CHOSEN TWICE
                            if (response.StatusCode == HttpStatusCode.NoContent)
                            {
                                MessageBox.Show("password changed succesfully");
                                this.Close();
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
                                var message = error["message"];

                                MessageBox.Show("Code: " + code + "\n" + title + "\n" + message);
                                //DEBUG
                                //MessageBox.Show(jobject.ToString());
                            }
                        }
                    }
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
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}