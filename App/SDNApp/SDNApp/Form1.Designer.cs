namespace SDNApp
{
    partial class SDN_Manager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SDN_Manager));
            this.buttonGetSDNData = new System.Windows.Forms.Button();
            this.textBoxSDNIP = new System.Windows.Forms.TextBox();
            this.labelStatus = new System.Windows.Forms.Label();
            this.listBoxOpenflow = new System.Windows.Forms.ListBox();
            this.buttonGetNodeTerminationPoints = new System.Windows.Forms.Button();
            this.listBoxNodeTerminationPoints = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxFlowIpSource = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButtonFalse = new System.Windows.Forms.RadioButton();
            this.radioButtonTrue = new System.Windows.Forms.RadioButton();
            this.textBoxFlowEtherType = new System.Windows.Forms.TextBox();
            this.textBoxFlowIpDest = new System.Windows.Forms.TextBox();
            this.textBoxFlowPriority = new System.Windows.Forms.TextBox();
            this.textBoxIdleTimeout = new System.Windows.Forms.TextBox();
            this.textBoxHardTimeout = new System.Windows.Forms.TextBox();
            this.textBoxFlowOrder = new System.Windows.Forms.TextBox();
            this.textBoxTableId = new System.Windows.Forms.TextBox();
            this.textBoxFlowId = new System.Windows.Forms.TextBox();
            this.textBoxFlowname = new System.Windows.Forms.TextBox();
            this.buttonDeleteFlow = new System.Windows.Forms.Button();
            this.buttonUpdateFlow = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonCreateFlow = new System.Windows.Forms.Button();
            this.listBoxFlows = new System.Windows.Forms.ListBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.listBoxHosts = new System.Windows.Forms.ListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelIdInfo = new System.Windows.Forms.Label();
            this.labelMACInfo = new System.Windows.Forms.Label();
            this.labelConnectionInfo = new System.Windows.Forms.Label();
            this.labelActiveInfo = new System.Windows.Forms.Label();
            this.labelIDStatus = new System.Windows.Forms.Label();
            this.labelMACStatus = new System.Windows.Forms.Label();
            this.labelConnectionToStatus = new System.Windows.Forms.Label();
            this.labelActiveStatus = new System.Windows.Forms.Label();
            this.groupBoxHostInfo = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBoxHostInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonGetSDNData
            // 
            this.buttonGetSDNData.Location = new System.Drawing.Point(156, 27);
            this.buttonGetSDNData.Margin = new System.Windows.Forms.Padding(4);
            this.buttonGetSDNData.Name = "buttonGetSDNData";
            this.buttonGetSDNData.Size = new System.Drawing.Size(100, 28);
            this.buttonGetSDNData.TabIndex = 2;
            this.buttonGetSDNData.Text = "Get Data";
            this.buttonGetSDNData.UseVisualStyleBackColor = true;
            this.buttonGetSDNData.Click += new System.EventHandler(this.buttonGetNodeIDS_Click);
            // 
            // textBoxSDNIP
            // 
            this.textBoxSDNIP.Location = new System.Drawing.Point(16, 30);
            this.textBoxSDNIP.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxSDNIP.Name = "textBoxSDNIP";
            this.textBoxSDNIP.Size = new System.Drawing.Size(132, 22);
            this.textBoxSDNIP.TabIndex = 3;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(13, 98);
            this.labelStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(48, 17);
            this.labelStatus.TabIndex = 5;
            this.labelStatus.Text = "Status";
            // 
            // listBoxOpenflow
            // 
            this.listBoxOpenflow.FormattingEnabled = true;
            this.listBoxOpenflow.ItemHeight = 16;
            this.listBoxOpenflow.Location = new System.Drawing.Point(16, 128);
            this.listBoxOpenflow.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxOpenflow.Name = "listBoxOpenflow";
            this.listBoxOpenflow.Size = new System.Drawing.Size(197, 116);
            this.listBoxOpenflow.TabIndex = 7;
            this.listBoxOpenflow.SelectedIndexChanged += new System.EventHandler(this.listBoxNodeIDS_SelectedIndexChanged);
            // 
            // buttonGetNodeTerminationPoints
            // 
            this.buttonGetNodeTerminationPoints.Enabled = false;
            this.buttonGetNodeTerminationPoints.Location = new System.Drawing.Point(223, 162);
            this.buttonGetNodeTerminationPoints.Margin = new System.Windows.Forms.Padding(4);
            this.buttonGetNodeTerminationPoints.Name = "buttonGetNodeTerminationPoints";
            this.buttonGetNodeTerminationPoints.Size = new System.Drawing.Size(164, 28);
            this.buttonGetNodeTerminationPoints.TabIndex = 8;
            this.buttonGetNodeTerminationPoints.Text = "Get Node TP";
            this.buttonGetNodeTerminationPoints.UseVisualStyleBackColor = true;
            this.buttonGetNodeTerminationPoints.Click += new System.EventHandler(this.buttonGetNodeTerminationPoints_Click);
            // 
            // listBoxNodeTerminationPoints
            // 
            this.listBoxNodeTerminationPoints.FormattingEnabled = true;
            this.listBoxNodeTerminationPoints.ItemHeight = 16;
            this.listBoxNodeTerminationPoints.Location = new System.Drawing.Point(395, 128);
            this.listBoxNodeTerminationPoints.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxNodeTerminationPoints.Name = "listBoxNodeTerminationPoints";
            this.listBoxNodeTerminationPoints.Size = new System.Drawing.Size(205, 116);
            this.listBoxNodeTerminationPoints.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxFlowIpSource);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.radioButtonFalse);
            this.groupBox1.Controls.Add(this.radioButtonTrue);
            this.groupBox1.Controls.Add(this.textBoxFlowEtherType);
            this.groupBox1.Controls.Add(this.textBoxFlowIpDest);
            this.groupBox1.Controls.Add(this.textBoxFlowPriority);
            this.groupBox1.Controls.Add(this.textBoxIdleTimeout);
            this.groupBox1.Controls.Add(this.textBoxHardTimeout);
            this.groupBox1.Controls.Add(this.textBoxFlowOrder);
            this.groupBox1.Controls.Add(this.textBoxTableId);
            this.groupBox1.Controls.Add(this.textBoxFlowId);
            this.groupBox1.Controls.Add(this.textBoxFlowname);
            this.groupBox1.Controls.Add(this.buttonDeleteFlow);
            this.groupBox1.Controls.Add(this.buttonUpdateFlow);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.buttonCreateFlow);
            this.groupBox1.Location = new System.Drawing.Point(12, 400);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(291, 366);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Flow";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter_1);
            // 
            // textBoxFlowIpSource
            // 
            this.textBoxFlowIpSource.Enabled = false;
            this.textBoxFlowIpSource.Location = new System.Drawing.Point(121, 248);
            this.textBoxFlowIpSource.Name = "textBoxFlowIpSource";
            this.textBoxFlowIpSource.Size = new System.Drawing.Size(119, 22);
            this.textBoxFlowIpSource.TabIndex = 33;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 251);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 17);
            this.label1.TabIndex = 32;
            this.label1.Text = "IPv4 source:";
            // 
            // radioButtonFalse
            // 
            this.radioButtonFalse.AutoSize = true;
            this.radioButtonFalse.Enabled = false;
            this.radioButtonFalse.Location = new System.Drawing.Point(121, 160);
            this.radioButtonFalse.Name = "radioButtonFalse";
            this.radioButtonFalse.Size = new System.Drawing.Size(63, 21);
            this.radioButtonFalse.TabIndex = 31;
            this.radioButtonFalse.TabStop = true;
            this.radioButtonFalse.Text = "False";
            this.radioButtonFalse.UseVisualStyleBackColor = true;
            // 
            // radioButtonTrue
            // 
            this.radioButtonTrue.AutoSize = true;
            this.radioButtonTrue.Enabled = false;
            this.radioButtonTrue.Location = new System.Drawing.Point(56, 160);
            this.radioButtonTrue.Name = "radioButtonTrue";
            this.radioButtonTrue.Size = new System.Drawing.Size(59, 21);
            this.radioButtonTrue.TabIndex = 30;
            this.radioButtonTrue.TabStop = true;
            this.radioButtonTrue.Text = "True";
            this.radioButtonTrue.UseVisualStyleBackColor = true;
            // 
            // textBoxFlowEtherType
            // 
            this.textBoxFlowEtherType.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxFlowEtherType.Enabled = false;
            this.textBoxFlowEtherType.Location = new System.Drawing.Point(104, 280);
            this.textBoxFlowEtherType.Name = "textBoxFlowEtherType";
            this.textBoxFlowEtherType.Size = new System.Drawing.Size(58, 22);
            this.textBoxFlowEtherType.TabIndex = 29;
            this.textBoxFlowEtherType.TextChanged += new System.EventHandler(this.textBox9_TextChanged);
            // 
            // textBoxFlowIpDest
            // 
            this.textBoxFlowIpDest.Enabled = false;
            this.textBoxFlowIpDest.Location = new System.Drawing.Point(121, 216);
            this.textBoxFlowIpDest.Name = "textBoxFlowIpDest";
            this.textBoxFlowIpDest.Size = new System.Drawing.Size(119, 22);
            this.textBoxFlowIpDest.TabIndex = 28;
            // 
            // textBoxFlowPriority
            // 
            this.textBoxFlowPriority.Enabled = false;
            this.textBoxFlowPriority.Location = new System.Drawing.Point(62, 187);
            this.textBoxFlowPriority.Name = "textBoxFlowPriority";
            this.textBoxFlowPriority.Size = new System.Drawing.Size(62, 22);
            this.textBoxFlowPriority.TabIndex = 27;
            // 
            // textBoxIdleTimeout
            // 
            this.textBoxIdleTimeout.Enabled = false;
            this.textBoxIdleTimeout.Location = new System.Drawing.Point(232, 125);
            this.textBoxIdleTimeout.Name = "textBoxIdleTimeout";
            this.textBoxIdleTimeout.Size = new System.Drawing.Size(48, 22);
            this.textBoxIdleTimeout.TabIndex = 26;
            // 
            // textBoxHardTimeout
            // 
            this.textBoxHardTimeout.Enabled = false;
            this.textBoxHardTimeout.Location = new System.Drawing.Point(96, 125);
            this.textBoxHardTimeout.Name = "textBoxHardTimeout";
            this.textBoxHardTimeout.Size = new System.Drawing.Size(48, 22);
            this.textBoxHardTimeout.TabIndex = 25;
            // 
            // textBoxFlowOrder
            // 
            this.textBoxFlowOrder.Enabled = false;
            this.textBoxFlowOrder.Location = new System.Drawing.Point(58, 97);
            this.textBoxFlowOrder.Name = "textBoxFlowOrder";
            this.textBoxFlowOrder.Size = new System.Drawing.Size(86, 22);
            this.textBoxFlowOrder.TabIndex = 24;
            // 
            // textBoxTableId
            // 
            this.textBoxTableId.Enabled = false;
            this.textBoxTableId.Location = new System.Drawing.Point(219, 95);
            this.textBoxTableId.Name = "textBoxTableId";
            this.textBoxTableId.Size = new System.Drawing.Size(61, 22);
            this.textBoxTableId.TabIndex = 23;
            // 
            // textBoxFlowId
            // 
            this.textBoxFlowId.Enabled = false;
            this.textBoxFlowId.Location = new System.Drawing.Point(62, 69);
            this.textBoxFlowId.Name = "textBoxFlowId";
            this.textBoxFlowId.Size = new System.Drawing.Size(82, 22);
            this.textBoxFlowId.TabIndex = 22;
            // 
            // textBoxFlowname
            // 
            this.textBoxFlowname.Enabled = false;
            this.textBoxFlowname.Location = new System.Drawing.Point(87, 30);
            this.textBoxFlowname.Name = "textBoxFlowname";
            this.textBoxFlowname.Size = new System.Drawing.Size(100, 22);
            this.textBoxFlowname.TabIndex = 21;
            // 
            // buttonDeleteFlow
            // 
            this.buttonDeleteFlow.BackColor = System.Drawing.Color.Red;
            this.buttonDeleteFlow.Enabled = false;
            this.buttonDeleteFlow.Location = new System.Drawing.Point(165, 326);
            this.buttonDeleteFlow.Name = "buttonDeleteFlow";
            this.buttonDeleteFlow.Size = new System.Drawing.Size(75, 28);
            this.buttonDeleteFlow.TabIndex = 13;
            this.buttonDeleteFlow.Text = "Delete";
            this.buttonDeleteFlow.UseVisualStyleBackColor = false;
            this.buttonDeleteFlow.Click += new System.EventHandler(this.buttonDeleteFlow_Click);
            // 
            // buttonUpdateFlow
            // 
            this.buttonUpdateFlow.BackColor = System.Drawing.Color.Yellow;
            this.buttonUpdateFlow.Enabled = false;
            this.buttonUpdateFlow.Location = new System.Drawing.Point(84, 326);
            this.buttonUpdateFlow.Name = "buttonUpdateFlow";
            this.buttonUpdateFlow.Size = new System.Drawing.Size(75, 28);
            this.buttonUpdateFlow.TabIndex = 13;
            this.buttonUpdateFlow.Text = "Update";
            this.buttonUpdateFlow.UseVisualStyleBackColor = false;
            this.buttonUpdateFlow.Click += new System.EventHandler(this.buttonUpdateFlow_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 285);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(97, 17);
            this.label11.TabIndex = 20;
            this.label11.Text = "Ethernet type:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 216);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(112, 17);
            this.label10.TabIndex = 19;
            this.label10.Text = "IPv4 destination:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 190);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 17);
            this.label9.TabIndex = 18;
            this.label9.Text = "Priority:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(150, 128);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 17);
            this.label8.TabIndex = 17;
            this.label8.Text = "Idle timeout:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 128);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 17);
            this.label7.TabIndex = 16;
            this.label7.Text = "Hard timeout:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 162);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "Strict:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 17);
            this.label5.TabIndex = 15;
            this.label5.Text = "Order:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 17);
            this.label4.TabIndex = 14;
            this.label4.Text = "Flow id:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(150, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "Table id:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "Flow name:";
            // 
            // buttonCreateFlow
            // 
            this.buttonCreateFlow.BackColor = System.Drawing.Color.Green;
            this.buttonCreateFlow.Enabled = false;
            this.buttonCreateFlow.Location = new System.Drawing.Point(3, 326);
            this.buttonCreateFlow.Name = "buttonCreateFlow";
            this.buttonCreateFlow.Size = new System.Drawing.Size(75, 28);
            this.buttonCreateFlow.TabIndex = 10;
            this.buttonCreateFlow.Text = "Create";
            this.buttonCreateFlow.UseVisualStyleBackColor = false;
            this.buttonCreateFlow.Click += new System.EventHandler(this.buttonCreateFlow_Click);
            // 
            // listBoxFlows
            // 
            this.listBoxFlows.FormattingEnabled = true;
            this.listBoxFlows.ItemHeight = 16;
            this.listBoxFlows.Location = new System.Drawing.Point(395, 451);
            this.listBoxFlows.Name = "listBoxFlows";
            this.listBoxFlows.Size = new System.Drawing.Size(205, 228);
            this.listBoxFlows.TabIndex = 13;
            this.listBoxFlows.SelectedIndexChanged += new System.EventHandler(this.listBoxFlows_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(392, 430);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 17);
            this.label12.TabIndex = 21;
            this.label12.Text = "Flows:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(392, 98);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(129, 17);
            this.label13.TabIndex = 22;
            this.label13.Text = "Termination points:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(13, 9);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(89, 17);
            this.label14.TabIndex = 21;
            this.label14.Text = "Controller IP:";
            // 
            // listBoxHosts
            // 
            this.listBoxHosts.FormattingEnabled = true;
            this.listBoxHosts.ItemHeight = 16;
            this.listBoxHosts.Location = new System.Drawing.Point(16, 251);
            this.listBoxHosts.Name = "listBoxHosts";
            this.listBoxHosts.Size = new System.Drawing.Size(197, 116);
            this.listBoxHosts.TabIndex = 23;
            this.listBoxHosts.SelectedIndexChanged += new System.EventHandler(this.listBoxHosts_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(395, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(187, 62);
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // labelIdInfo
            // 
            this.labelIdInfo.AutoSize = true;
            this.labelIdInfo.Location = new System.Drawing.Point(6, 27);
            this.labelIdInfo.Name = "labelIdInfo";
            this.labelIdInfo.Size = new System.Drawing.Size(23, 17);
            this.labelIdInfo.TabIndex = 25;
            this.labelIdInfo.Text = "Id:";
            // 
            // labelMACInfo
            // 
            this.labelMACInfo.AutoSize = true;
            this.labelMACInfo.Location = new System.Drawing.Point(6, 54);
            this.labelMACInfo.Name = "labelMACInfo";
            this.labelMACInfo.Size = new System.Drawing.Size(41, 17);
            this.labelMACInfo.TabIndex = 26;
            this.labelMACInfo.Text = "MAC:";
            // 
            // labelConnectionInfo
            // 
            this.labelConnectionInfo.AutoSize = true;
            this.labelConnectionInfo.Location = new System.Drawing.Point(6, 80);
            this.labelConnectionInfo.Name = "labelConnectionInfo";
            this.labelConnectionInfo.Size = new System.Drawing.Size(96, 17);
            this.labelConnectionInfo.TabIndex = 27;
            this.labelConnectionInfo.Text = "Connected to:";
            // 
            // labelActiveInfo
            // 
            this.labelActiveInfo.AutoSize = true;
            this.labelActiveInfo.Location = new System.Drawing.Point(6, 106);
            this.labelActiveInfo.Name = "labelActiveInfo";
            this.labelActiveInfo.Size = new System.Drawing.Size(50, 17);
            this.labelActiveInfo.TabIndex = 29;
            this.labelActiveInfo.Text = "Active:";
            // 
            // labelIDStatus
            // 
            this.labelIDStatus.AutoSize = true;
            this.labelIDStatus.Location = new System.Drawing.Point(35, 27);
            this.labelIDStatus.Name = "labelIDStatus";
            this.labelIDStatus.Size = new System.Drawing.Size(54, 17);
            this.labelIDStatus.TabIndex = 30;
            this.labelIDStatus.Text = "label15";
            // 
            // labelMACStatus
            // 
            this.labelMACStatus.AutoSize = true;
            this.labelMACStatus.Location = new System.Drawing.Point(53, 54);
            this.labelMACStatus.Name = "labelMACStatus";
            this.labelMACStatus.Size = new System.Drawing.Size(54, 17);
            this.labelMACStatus.TabIndex = 31;
            this.labelMACStatus.Text = "label15";
            // 
            // labelConnectionToStatus
            // 
            this.labelConnectionToStatus.AutoSize = true;
            this.labelConnectionToStatus.Location = new System.Drawing.Point(108, 80);
            this.labelConnectionToStatus.Name = "labelConnectionToStatus";
            this.labelConnectionToStatus.Size = new System.Drawing.Size(54, 17);
            this.labelConnectionToStatus.TabIndex = 32;
            this.labelConnectionToStatus.Text = "label15";
            // 
            // labelActiveStatus
            // 
            this.labelActiveStatus.AutoSize = true;
            this.labelActiveStatus.Location = new System.Drawing.Point(62, 106);
            this.labelActiveStatus.Name = "labelActiveStatus";
            this.labelActiveStatus.Size = new System.Drawing.Size(54, 17);
            this.labelActiveStatus.TabIndex = 33;
            this.labelActiveStatus.Text = "label15";
            // 
            // groupBoxHostInfo
            // 
            this.groupBoxHostInfo.Controls.Add(this.labelConnectionToStatus);
            this.groupBoxHostInfo.Controls.Add(this.labelIdInfo);
            this.groupBoxHostInfo.Controls.Add(this.labelActiveInfo);
            this.groupBoxHostInfo.Controls.Add(this.labelActiveStatus);
            this.groupBoxHostInfo.Controls.Add(this.labelIDStatus);
            this.groupBoxHostInfo.Controls.Add(this.labelConnectionInfo);
            this.groupBoxHostInfo.Controls.Add(this.labelMACStatus);
            this.groupBoxHostInfo.Controls.Add(this.labelMACInfo);
            this.groupBoxHostInfo.Location = new System.Drawing.Point(223, 251);
            this.groupBoxHostInfo.Name = "groupBoxHostInfo";
            this.groupBoxHostInfo.Size = new System.Drawing.Size(260, 143);
            this.groupBoxHostInfo.TabIndex = 34;
            this.groupBoxHostInfo.TabStop = false;
            this.groupBoxHostInfo.Text = "Host info";
            this.groupBoxHostInfo.Visible = false;
            // 
            // SDN_Manager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 778);
            this.Controls.Add(this.groupBoxHostInfo);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.listBoxHosts);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.listBoxFlows);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listBoxNodeTerminationPoints);
            this.Controls.Add(this.buttonGetNodeTerminationPoints);
            this.Controls.Add(this.listBoxOpenflow);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.textBoxSDNIP);
            this.Controls.Add(this.buttonGetSDNData);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SDN_Manager";
            this.Text = "SDN Manager";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBoxHostInfo.ResumeLayout(false);
            this.groupBoxHostInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonGetSDNData;
        private System.Windows.Forms.TextBox textBoxSDNIP;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.ListBox listBoxOpenflow;
        private System.Windows.Forms.Button buttonGetNodeTerminationPoints;
        private System.Windows.Forms.ListBox listBoxNodeTerminationPoints;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonCreateFlow;
        private System.Windows.Forms.Button buttonDeleteFlow;
        private System.Windows.Forms.Button buttonUpdateFlow;
        private System.Windows.Forms.ListBox listBoxFlows;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBoxIdleTimeout;
        private System.Windows.Forms.TextBox textBoxHardTimeout;
        private System.Windows.Forms.TextBox textBoxFlowOrder;
        private System.Windows.Forms.TextBox textBoxTableId;
        private System.Windows.Forms.TextBox textBoxFlowId;
        private System.Windows.Forms.TextBox textBoxFlowname;
        private System.Windows.Forms.TextBox textBoxFlowEtherType;
        private System.Windows.Forms.TextBox textBoxFlowIpDest;
        private System.Windows.Forms.TextBox textBoxFlowPriority;
        private System.Windows.Forms.RadioButton radioButtonFalse;
        private System.Windows.Forms.RadioButton radioButtonTrue;
        private System.Windows.Forms.TextBox textBoxFlowIpSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxHosts;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelIdInfo;
        private System.Windows.Forms.Label labelMACInfo;
        private System.Windows.Forms.Label labelConnectionInfo;
        private System.Windows.Forms.Label labelActiveInfo;
        private System.Windows.Forms.Label labelIDStatus;
        private System.Windows.Forms.Label labelMACStatus;
        private System.Windows.Forms.Label labelConnectionToStatus;
        private System.Windows.Forms.Label labelActiveStatus;
        private System.Windows.Forms.GroupBox groupBoxHostInfo;
    }
}

