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
        string baseURI = @"http://192.168.56.102:8181/restconf/operational/network-topology:network-topology";
        private List<User> listaUsers;
        private String responseString = "";

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

            String username = "admin";
            String password = "admin";
            String encoded = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(username + ":" + password));
            

            string URI = baseURI;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URI);
            request.Headers.Add("Authorization", "Basic " + encoded);


            HttpWebResponse response = (HttpWebResponse)request.GetResponse();


            using (Stream stream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                responseString = reader.ReadToEnd();
            }
            //MessageBox.Show(responseString);
            parseTextTest(responseString);

        }



        private void parseTextTest(string text)
        {
            JObject networkTopology = JObject.Parse(text);
            var aux = networkTopology["network-topology"];

            //DEBUG
            //MessageBox.Show(networkTopology["network-topology"].ToString());
            MessageBox.Show(aux.ToString());

            foreach(var result in aux["topology"])
            {
                string topologyID = (string)result["topology-id"];
                MessageBox.Show(topologyID);

                foreach (var result2 in result["node"])
                {
                    //string tpId = (string)result2["host-tracker-service:attachment-points"];
                    MessageBox.Show(result2.ToString());
                }

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


