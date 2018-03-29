using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;


namespace SDNApp
{
    public partial class Form1 : Form
    {
        string baseURI = @"http://recurso.dad/api/users";
        private List<User> listaUsers;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //IPAddress ipAddress;
            //if (IPAddress.TryParse(textBoxSDNData.Text, out ipAddress))
            //{
            //    Debug.WriteLine("### VALID IP ###");

            //}
            //else
            //{
            //    Debug.WriteLine("### INVALID IP ###");
            //}

            string URI = baseURI;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URI);

            if (testConnectionWebService(URI, request))
            {
                this.getUsers();

            }

        }

        // funcao para testes de connection com um webservice
        private Boolean testConnectionWebService(string URI, HttpWebRequest request)
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

        // faz um pedido get a um URL
        private string getURIcontent(string URI)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URI);

            if (testConnectionWebService(URI, request))
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();


                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        Console.WriteLine(reader.ReadToEnd());
                        //MessageBox.Show(reader.ReadToEnd());

                        JObject results = JObject.Parse(reader.ReadToEnd());
                        foreach (var result in results["Data"])
                        {

                        }

                        return reader.ReadToEnd();
                    }
                }

            }
            return null;
        }

        // testes
        private void getUsers()
        {
            string URI = baseURI;
            string content = getURIcontent(URI);


        }
    }
}


