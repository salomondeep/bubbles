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
using System.Xml;

namespace SDNApp
{
    public partial class SDN_Manager : Form
    {
        string baseURI = "http://";
        private String responseString = "";
        static String username = "admin";
        static String password = "admin";
        string ip = "";
        private string port = "8181";
        String encoded = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(username + ":" + password));
        string xmlns = "urn:opendaylight:flow:inventory";

        public SDN_Manager()
        {
            InitializeComponent();
        }



        private void buttonGetNodeIDS_Click(object sender, EventArgs e)
        {
            IPAddress ipAddress;
            if (IPAddress.TryParse(textBoxSDNIP.Text, out ipAddress))
            {
                //Debug.WriteLine("### VALID IP ###");
                //MessageBox.Show("### VALID IP ###");

                this.ip = textBoxSDNIP.Text;
                string URI = baseURI + this.ip + ":" + this.port + "/restconf/operational/network-topology:network-topology";

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
                //MessageBox.Show("### INVALID IP ###");
            }
        }


        private void getNodeIds(HttpWebRequest request)
        {
            listBoxOpenflow.Items.Clear();
            listBoxHosts.Items.Clear();
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            using (Stream stream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                responseString = reader.ReadToEnd();
            }
            //MessageBox.Show(responseString);

            JObject networkTopology = JObject.Parse(responseString);
            var aux = networkTopology["network-topology"];

            //DEBUG
            //MessageBox.Show(aux.ToString());

            foreach (var result in aux["topology"])
            {
                string topologyID = (string)result["topology-id"];
                //MessageBox.Show(topologyID);

                foreach (var result2 in result["node"])
                {
                    //string tpId = (string)result2["host-tracker-service:attachment-points"];
                    //MessageBox.Show(result2.ToString());
                    string nodeID = (string)result2["node-id"];
                    //MessageBox.Show("topology: " + topologyID + " | node-id: " + nodeID);
                    if(nodeID.StartsWith("host:"))
                    {
                        listBoxHosts.Items.Add(nodeID);
                    }

                    if(nodeID.StartsWith("openflow:"))
                    {
                        listBoxOpenflow.Items.Add(nodeID);
                    }
                }
            }
        }





        private void buttonGetNodeTerminationPoints_Click(object sender, EventArgs e)
        {
            listBoxNodeTerminationPoints.Items.Clear();

            string URI = "";
            IPAddress ipAddress;
            if (IPAddress.TryParse(textBoxSDNIP.Text, out ipAddress))
            {
                //Debug.WriteLine("### VALID IP ###");
                //MessageBox.Show("### VALID IP ###");

                this.ip = textBoxSDNIP.Text;
                if(listBoxOpenflow.SelectedItem != null)
                {
                    URI = baseURI + this.ip + ":" + this.port + "/restconf/operational/network-topology:network-topology/topology/flow:1/node/" + listBoxOpenflow.Text;

                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URI);
                    request.Headers.Add("Authorization", "Basic " + encoded);

                    if (testConnectionWebService(URI, request))
                    {
                        this.getOpenflowTPs(request);
                    }
                }

                if(listBoxHosts.SelectedItem != null)
                {
                    URI = baseURI + this.ip + ":" + this.port + "/restconf/operational/network-topology:network-topology/topology/flow:1/node/" + listBoxHosts.Text;

                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URI);
                    request.Headers.Add("Authorization", "Basic " + encoded);

                    if (testConnectionWebService(URI, request))
                    {
                        this.getHostsTPs(request);
                    }
                }
                


            }
            else
            {
                //Debug.WriteLine("### INVALID IP ###");
                //MessageBox.Show("### INVALID IP ###");
            }
        }

        private void getOpenflowTPs(HttpWebRequest request)
        {
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            using (Stream stream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                responseString = reader.ReadToEnd();
            }
            //MessageBox.Show(responseString);

            JObject networkTopology = JObject.Parse(responseString);
            var aux = networkTopology["node"];

            //DEBUG
            //MessageBox.Show(aux.ToString());


            foreach (var result in aux)
            {
                //MessageBox.Show((string)result["node-id"]);

                foreach (var result2 in result["termination-point"])
                {
                    //MessageBox.Show(result2.ToString());

                    string tpID = (string)result2["tp-id"];
                    //MessageBox.Show(tpID);

                    listBoxNodeTerminationPoints.Items.Add(tpID);
                }
            }
        }


        private void getHostsTPs(HttpWebRequest request)
        {
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            using (Stream stream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                responseString = reader.ReadToEnd();
            }
            //MessageBox.Show(responseString);

            JObject networkTopology = JObject.Parse(responseString);
            var aux = networkTopology["node"];

            //DEBUG
            //MessageBox.Show(aux.ToString());


            //groupBoxHostInfo.Visible = true;


            foreach (var result in aux)
            {
                //MessageBox.Show((string)result["node-id"]);

                //this.labelStatus.ForeColor = System.Drawing.Color.Green;
                //this.labelStatus.Text = "OK";

                foreach (var result2 in result["host-tracker-service:addresses"])
                {
                    //MessageBox.Show(result2.ToString());

                    string tpID = (string)result2["ip"];
                    string id = (string)result2["id"];
                    string mac = (string)result2["mac"];
                    //MessageBox.Show(tpID);

                    listBoxNodeTerminationPoints.Items.Add("IPv4: " + tpID);
                    labelIDStatus.Text = id;
                    labelMACStatus.Text = mac;
                }


                foreach (var result3 in result["host-tracker-service:attachment-points"])
                {
                    string tpID = (string)result3["tp-id"];
                    string active = (string)result3["active"];

                    labelConnectionToStatus.Text = tpID;
                    labelActiveStatus.Text = active;

                    if(labelActiveStatus.Text.Equals("True"))
                    {
                        labelActiveStatus.ForeColor = System.Drawing.Color.Green;
                    }
                }
            }

            groupBoxHostInfo.Visible = true;
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            textBoxSDNIP.Text = "192.168.10.3";
        }

        private void listBoxNodeIDS_SelectedIndexChanged(object sender, EventArgs e)
        {            
                buttonGetNodeTerminationPoints.Enabled = true;
                textBoxFlowname.Enabled = true;
                textBoxFlowId.Enabled = true;
                textBoxFlowOrder.Enabled = true;
                textBoxTableId.Enabled = true;
                textBoxHardTimeout.Enabled = true;
                textBoxIdleTimeout.Enabled = true;
                textBoxFlowPriority.Enabled = true;
                textBoxFlowIpDest.Enabled = true;
                textBoxFlowIpSource.Enabled = true;
                textBoxFlowEtherType.Enabled = true;
                buttonCreateFlow.Enabled = true;
                radioButtonTrue.Enabled = true;
                radioButtonFalse.Enabled = true;
            

            //if(listBoxFlows.SelectedItem != null)
            //{
            //    listBoxFlows.ClearSelected();
            //}

            if(listBoxHosts.SelectedItem != null)
            {
                listBoxHosts.ClearSelected();

                if(groupBoxHostInfo.Visible)
                {
                    groupBoxHostInfo.Visible = false;
                }

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void buttonUpdateFlow_Click(object sender, EventArgs e)
        {
            //UPDATE FLOW LIST
            Flow flow = listBoxFlows.SelectedItem as Flow;
            
            if (listBoxFlows.SelectedItem != null)
            {
                listBoxFlows.ClearSelected();
            }

            listBoxFlows.Items.Remove(flow);
            


            //PUT
            ip = textBoxSDNIP.Text;
            string URL = baseURI + ip + ":" + port + "/restconf/config/opendaylight-inventory:nodes/node/" +
                flow.openflow + "/table/" + flow.Table_id + "/flow/" + flow.Id;

            //MessageBox.Show(URL);
            XmlDocument doc = createXml();
            UTF8Encoding encoding = new UTF8Encoding();
            byte[] body = Encoding.UTF8.GetBytes(doc.OuterXml);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
            request.Method = "PUT";
            request.ContentType = "application/xml";
            request.ContentLength = body.Length;
            request.Headers.Add("Authorization", "Basic " + encoded);

            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(body, 0, body.Length);
            }


            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //MessageBox.Show(response.StatusCode.ToString());

            response.Close();
            DisableAndClean();

            //DEBUG
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonCreateFlow_Click(object sender, EventArgs e)
        {
            //DEBUG
            //MessageBox.Show(textBoxFlowname.Text + " " + textBoxFlowId.Text +
            //    " " + textBoxFlowOrder.Text + " " + textBoxTableId.Text + " " +
            //    textBoxHardTimeout.Text + " " + textBoxIdleTimeout.Text +
            //    " " + textBoxFlowPriority.Text + " " + textBoxFlowIp.Text +
            //    " " + textBoxFlowEtherType.Text);

            //if(radioButtonTrue.Checked)
            //{
            //    MessageBox.Show("Radio Button True");
            //}
            //else
            //{
            //    MessageBox.Show("Radio Button False");
            //}

            XmlDocument doc = createXml();
            XmlPost(doc);
            //DisableAndClean();
        }


        private XmlDocument createXml()
        {
            XmlDocument doc = new XmlDocument();
            XmlNode root = doc.CreateElement("flow");
            XmlAttribute attr = doc.CreateAttribute("xmlns");
            attr.Value = xmlns;

            root.Attributes.SetNamedItem(attr);

            XmlNode strict = doc.CreateElement("strict");
            XmlNode instructions = doc.CreateElement("instructions");
            XmlNode instruction = doc.CreateElement("instruction");
            XmlNode order = doc.CreateElement("order");
            XmlNode order2 = doc.CreateElement("order");
            XmlNode apply_actions = doc.CreateElement("apply-actions");
            XmlNode action = doc.CreateElement("action");
            XmlNode flood_all_actions = doc.CreateElement("flood-all-action");
            XmlNode table_id = doc.CreateElement("table_id");
            XmlNode id = doc.CreateElement("id");
            XmlNode cookie_mask = doc.CreateElement("cookie_mask");
            XmlNode out_port = doc.CreateElement("out_port");
            XmlNode installHw = doc.CreateElement("installHw");
            XmlNode out_group = doc.CreateElement("out_group");
            XmlNode match = doc.CreateElement("match");
            XmlNode ethernet_match = doc.CreateElement("ethernet-match");
            XmlNode ethernet_type = doc.CreateElement("ethernet-type");
            XmlNode type = doc.CreateElement("type");
            XmlNode ipSource = doc.CreateElement("ipv4-source");
            XmlNode ipDestination = doc.CreateElement("ipv4-destination");
            XmlNode hard_timeout = doc.CreateElement("hard-timeout");
            XmlNode cookie = doc.CreateElement("cookie");
            XmlNode idle_timeout = doc.CreateElement("idle-timeout");
            XmlNode flowName = doc.CreateElement("flow-name");
            XmlNode priority = doc.CreateElement("priority");
            XmlNode barrier = doc.CreateElement("barrier");


            order.InnerText = textBoxFlowOrder.Text;
            order2.InnerText = textBoxFlowOrder.Text;
            table_id.InnerText = textBoxTableId.Text;
            id.InnerText = textBoxFlowId.Text;
            type.InnerText = textBoxFlowEtherType.Text;
            ipSource.InnerText = textBoxFlowIpSource.Text + "/32";
            ipDestination.InnerText = textBoxFlowIpDest.Text + "/32";
            hard_timeout.InnerText = textBoxHardTimeout.Text;
            idle_timeout.InnerText = textBoxIdleTimeout.Text;
            flowName.InnerText = textBoxFlowname.Text;
            priority.InnerText = textBoxFlowPriority.Text;

            if (radioButtonTrue.Checked)
            {
                //MessageBox.Show("Radio Button True");
                strict.InnerText = "true";
            }
            else
            {
                //MessageBox.Show("Radio Button False");
                strict.InnerText = "false";
            }

             Flow flow = createFlow(strict.InnerText, order.InnerText, id.InnerText, hard_timeout.InnerText,
                idle_timeout.InnerText, flowName.InnerText, textBoxFlowIpSource.Text, textBoxFlowIpDest.Text,
                priority.InnerText, table_id.InnerText);

            sendFlowToList(flow);

            cookie_mask.InnerText = "10";
            out_port.InnerText = "10";
            installHw.InnerText = "false";
            out_group.InnerText = "2";
            cookie.InnerText = "10";
            barrier.InnerText = "false";

            root.AppendChild(strict);
            action.AppendChild(order2);
            action.AppendChild(flood_all_actions);
            apply_actions.AppendChild(action);
            instruction.AppendChild(order);
            instruction.AppendChild(apply_actions);
            instructions.AppendChild(instruction);
            root.AppendChild(instructions);
            root.AppendChild(table_id);
            root.AppendChild(id);
            root.AppendChild(cookie_mask);
            root.AppendChild(out_port);
            root.AppendChild(installHw);
            root.AppendChild(out_group);
            ethernet_type.AppendChild(type);
            ethernet_match.AppendChild(ethernet_type);
            match.AppendChild(ethernet_match);
            match.AppendChild(ipSource);
            match.AppendChild(ipDestination);
            root.AppendChild(match);
            root.AppendChild(hard_timeout);
            root.AppendChild(cookie);
            root.AppendChild(idle_timeout);
            root.AppendChild(flowName);
            root.AppendChild(priority);
            root.AppendChild(barrier);

            doc.AppendChild(root);

            //MessageBox.Show(doc.OuterXml.ToString());

            //XmlPost(doc);
            return doc;
        }

        private void XmlPost(XmlDocument doc)
        {
            ip = textBoxSDNIP.Text;
            string URL = baseURI + ip + ":" + port + "/restconf/config/opendaylight-inventory:nodes/node/"+ 
                listBoxOpenflow.SelectedItem.ToString() + "/table/" + textBoxTableId.Text;

            //MessageBox.Show(URL);

            UTF8Encoding encoding = new UTF8Encoding();
            byte[] body = Encoding.UTF8.GetBytes(doc.OuterXml);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
            request.Method = "POST";
            request.ContentType = "application/xml";
            request.Accept = "application/xml";
            request.ContentLength = body.Length;
            request.Headers.Add("Authorization", "Basic " + encoded);

            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(body, 0, body.Length);
            }
                

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //MessageBox.Show(response.StatusCode.ToString());

            response.Close();




            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URI);
            //request.Headers.Add("Authorization", "Basic " + encoded);

            DisableAndClean();
        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void buttonDeleteFlow_Click(object sender, EventArgs e)
        {
            Flow flow = listBoxFlows.SelectedItem as Flow;

            ip = textBoxSDNIP.Text;
            string URL = baseURI + ip + ":" + port + "/restconf/config/opendaylight-inventory:nodes/node/" +
                flow.openflow + "/table/" + flow.Table_id + "/flow/" + flow.Id;

            //MessageBox.Show(URL);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
            request.Method = "DELETE";
            request.Headers.Add("Authorization", "Basic " + encoded);


            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //MessageBox.Show(response.StatusCode.ToString());

            response.Close();

            //buttonDeleteFlow.Enabled = false;
            //buttonUpdateFlow.Enabled = false;
            
            if (listBoxFlows.SelectedItem != null)
            {
                listBoxFlows.ClearSelected();
            }

            listBoxFlows.Items.Remove(flow);
            DisableAndClean();
        }


        //Method that creates a flow
        private Flow createFlow(string strict, string order, string id, string hard_timeout, string idle_timeout,
            string flowName, string ipSource, string ipDestination, string priority, string table_id)
        {
            Flow flow = new Flow();


            //Parsing string to IPs
            IPAddress source = IPAddress.Parse(ipSource);
            IPAddress destination = IPAddress.Parse(ipDestination);


            //Flow Object creation
            if(strict.Equals("true"))
            {
                flow.Strict = true;
            }else
            {
                flow.Strict = false;
            }

            flow.Order = Convert.ToInt32(order);
            flow.Id = Convert.ToInt32(id);
            flow.Hard_timeout = Convert.ToInt32(hard_timeout);
            flow.Idle_timeout = Convert.ToInt32(idle_timeout);
            flow.Flow_name = flowName;
            flow.Ipv4_source = source;
            flow.Ipv4_destination = destination;
            flow.Priority = Convert.ToInt32(priority);
            flow.Table_id = Convert.ToInt32(table_id);
            flow.openflow = listBoxOpenflow.SelectedItem.ToString();

            return flow;
        }

        private void sendFlowToList(Flow flow)
        {
            listBoxFlows.Items.Add(flow);
        }

        private void DisableAndClean()
        {
            //listBoxOpenflow.ClearSelected();

            textBoxFlowname.Clear();
            textBoxFlowId.Clear();
            textBoxFlowOrder.Clear();
            textBoxTableId.Clear();
            textBoxHardTimeout.Clear();
            textBoxIdleTimeout.Clear();
            textBoxFlowPriority.Clear();
            textBoxFlowIpDest.Clear();
            textBoxFlowIpSource.Clear();
            textBoxFlowEtherType.Clear();
            radioButtonTrue.Checked = false;
            radioButtonFalse.Checked = false;

            textBoxFlowname.Enabled = false;
            textBoxFlowId.Enabled = false;
            textBoxFlowOrder.Enabled = false;
            textBoxTableId.Enabled = false;
            textBoxHardTimeout.Enabled = false;
            textBoxIdleTimeout.Enabled = false;
            textBoxFlowPriority.Enabled = false;
            textBoxFlowIpDest.Enabled = false;
            textBoxFlowIpSource.Enabled = false;
            textBoxFlowEtherType.Enabled = false;
            buttonCreateFlow.Enabled = false;
            radioButtonTrue.Enabled = false;
            radioButtonFalse.Enabled = false;

            closeButtons();

        }

        private void listBoxFlows_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxOpenflow.SelectedItem != null)
            {
                listBoxOpenflow.ClearSelected();
            }

            if (listBoxHosts.SelectedItem != null)
            {
                listBoxHosts.ClearSelected();
            }

            //Flow flow = new Flow();
            string flow = listBoxFlows.SelectedItem.ToString();

            buttonDeleteFlow.Enabled = true;
            buttonUpdateFlow.Enabled = true;

            enableFields();
            //fillFields(flow);
        }


        //fill the fields with flow information
        private void fillFields(Flow flow)
        {
            //textBoxFlowname.Text = flow.Flow_name;
            //textBoxFlowId.Text = flow.Id.ToString();
            //textBoxFlowOrder.Text = flow.Order.ToString();


            if(flow != null)
            {
                this.ip = textBoxSDNIP.Text;
                string URI = baseURI + this.ip + ":" + this.port + "/restconf/config/opendaylight-inventory:nodes/node/" + flow.openflow +
                    "/table/" + flow.Table_id.ToString() + "/flow/" + flow.Id.ToString();

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URI);
                request.Headers.Add("Authorization", "Basic " + encoded);

                if (testConnectionWebService(URI, request))
                {
                    //this.getNodeIds(request);
                    //MessageBox.Show("I'm in");
                    //MessageBox.Show(URI);

                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                    using (Stream stream = response.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                        responseString = reader.ReadToEnd();
                    }
                    //MessageBox.Show(responseString);

                    JObject networkTopology = JObject.Parse(responseString);
                    var aux = networkTopology["flow-node-inventory:flow"];

                    foreach (var result in aux)
                    {
                        textBoxFlowname.Text = result["flow-name"].ToString();
                        textBoxFlowId.Text = result["id"].ToString();

                        JObject instructions = JObject.Parse(result["instructions"].ToString());

                        foreach (var result2 in instructions["instruction"])
                        {
                            textBoxFlowOrder.Text = result2["order"].ToString();
                        }

                        textBoxTableId.Text = result["table_id"].ToString();
                        textBoxHardTimeout.Text = result["hard-timeout"].ToString();
                        textBoxIdleTimeout.Text = result["idle-timeout"].ToString();

                        if (result["strict"].ToString().Equals("True"))
                        {
                            radioButtonFalse.Checked = false;
                            radioButtonTrue.Checked = true;
                        }
                        else if (result["strict"].ToString().Equals("False"))
                        {
                            radioButtonFalse.Checked = true;
                            radioButtonTrue.Checked = false;
                        }

                        textBoxFlowPriority.Text = result["priority"].ToString();


                        JObject match = JObject.Parse(result["match"].ToString());

                        string ipDest = match["ipv4-destination"].ToString();
                        string ipSource = match["ipv4-source"].ToString();

                        JObject ethernetMatch = JObject.Parse(match["ethernet-match"].ToString());
                        JObject ethernetType = JObject.Parse(ethernetMatch["ethernet-type"].ToString());

                        string type = ethernetMatch["ethernet-type"]["type"].ToString();

                        string[] splitIPDest = ipDest.Split('/');
                        string[] splitIPSource = ipSource.Split('/');

                        //HERE
                        textBoxFlowEtherType.Text = type;
                        textBoxFlowIpDest.Text = splitIPDest[0];
                        textBoxFlowIpSource.Text = splitIPSource[0];

                        //DEBUGING
                        //MessageBox.Show(ipDest);
                        //MessageBox.Show(ipSource);
                        //MessageBox.Show(splitIPDest[0]);
                        //MessageBox.Show(splitIPSource[0]);
                        //MessageBox.Show(result["strict"].ToString());

                    }
                    //foreach (var result in aux["topology"])
                    //{
                    //    string topologyID = (string)result["topology-id"];
                    //    //MessageBox.Show(topologyID);

                    //    foreach (var result2 in result["node"])
                    //    {
                    //        //string tpId = (string)result2["host-tracker-service:attachment-points"];
                    //        //MessageBox.Show(result2.ToString());
                    //        string nodeID = (string)result2["node-id"];
                    //        //MessageBox.Show("topology: " + topologyID + " | node-id: " + nodeID);
                    //        if (nodeID.StartsWith("host:"))
                    //        {
                    //            listBoxHosts.Items.Add(nodeID);
                    //        }

                    //        if (nodeID.StartsWith("openflow:"))
                    //        {
                    //            listBoxOpenflow.Items.Add(nodeID);
                    //        }
                    //    }
                    //}


                }
            }else
            {
                //MessageBox.Show("Flow deleted");
            }
            
        }


        //Enable fields for user to write
        private void enableFields()
        {
            textBoxFlowname.Enabled = true;
            textBoxFlowId.Enabled = true;
            textBoxFlowOrder.Enabled = true;
            textBoxTableId.Enabled = true;
            textBoxHardTimeout.Enabled = true;
            textBoxIdleTimeout.Enabled = true;
            textBoxFlowPriority.Enabled = true;
            textBoxFlowIpDest.Enabled = true;
            textBoxFlowIpSource.Enabled = true;
            textBoxFlowEtherType.Enabled = true;
            //buttonCreateFlow.Enabled = true;
            radioButtonTrue.Enabled = true;
            radioButtonFalse.Enabled = true;
        }

        private void closeButtons()
        {
            if(buttonCreateFlow.Enabled)
            {
                buttonCreateFlow.Enabled = false;
            }

            if (buttonDeleteFlow.Enabled)
            {
                buttonDeleteFlow.Enabled = false;
            }

            if (buttonUpdateFlow.Enabled)
            {
                buttonUpdateFlow.Enabled = false;
            }
        }

        private void listBoxHosts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxOpenflow.SelectedItem != null)
            {
                listBoxOpenflow.ClearSelected();
            }

            buttonGetNodeTerminationPoints.Enabled = true;

            DisableAndClean();
        }

        private void listBoxFlows_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //if (listBoxOpenflow.SelectedItem != null)
            //{
            //    listBoxOpenflow.ClearSelected();
            //}

            if (listBoxHosts.SelectedItem != null)
            {
                listBoxHosts.ClearSelected();
            }

            if(buttonCreateFlow.Enabled)
            {
                buttonCreateFlow.Enabled = false;
            }

            Flow flow = new Flow();
            flow = listBoxFlows.SelectedItem as Flow;

            buttonDeleteFlow.Enabled = true;
            buttonUpdateFlow.Enabled = true;

            enableFields();
            fillFields(flow);
        }
    }
}


