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
        string baseURI = "http://";
        private String responseString = "";
        static String username = "admin";
        static String password = "admin";
        String encoded = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(username + ":" + password));

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IPAddress ipAddress;

            if (IPAddress.TryParse(textBoxSDNIP.Text, out ipAddress))
            {
                //Debug.WriteLine("### VALID IP ###");
                MessageBox.Show("### VALID IP ###");

                string URI = baseURI + textBoxSDNIP.Text + ":8181/restconf/operational/network-topology:network-topology";

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URI);
                request.Headers.Add("Authorization", "Basic " + encoded);

                if (testConnectionWebService(URI, request))
                {
                    this.getNodeIds(request);
                }

            }
            else
            {
                //Debug.WriteLine("### INVALID IP ###");
                MessageBox.Show("### INVALID IP ###");
            }
        }



        private void getNodeIds(HttpWebRequest request)
        {
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

            foreach (var result in aux["topology"])
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
    }
}


