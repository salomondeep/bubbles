namespace SDNApp
{
    partial class Openstack_Manager
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
            this.components = new System.ComponentModel.Container();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxIP = new System.Windows.Forms.TextBox();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAccess = new System.Windows.Forms.Button();
            this.listBoxProjects = new System.Windows.Forms.ListBox();
            this.btnGetServers = new System.Windows.Forms.Button();
            this.listBoxServers = new System.Windows.Forms.ListBox();
            this.groupServerInfo = new System.Windows.Forms.GroupBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btn_logout = new System.Windows.Forms.Button();
            this.labelStatus = new System.Windows.Forms.Label();
            this.labelUser = new System.Windows.Forms.Label();
            this.btnScope = new System.Windows.Forms.Button();
            this.btn_change_password = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.labelState = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labelCPU = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelRAM = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.labelDisk = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnON = new System.Windows.Forms.Button();
            this.btnSUS = new System.Windows.Forms.Button();
            this.btnOFF = new System.Windows.Forms.Button();
            this.groupServerInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(92, 95);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(166, 22);
            this.textBoxPassword.TabIndex = 0;
            this.textBoxPassword.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Password:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Username:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Openstack IP:";
            // 
            // textBoxIP
            // 
            this.textBoxIP.Location = new System.Drawing.Point(116, 32);
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.Size = new System.Drawing.Size(142, 22);
            this.textBoxIP.TabIndex = 4;
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(97, 64);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(161, 22);
            this.textBoxUsername.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Projects:";
            // 
            // btnAccess
            // 
            this.btnAccess.Location = new System.Drawing.Point(183, 123);
            this.btnAccess.Name = "btnAccess";
            this.btnAccess.Size = new System.Drawing.Size(75, 30);
            this.btnAccess.TabIndex = 8;
            this.btnAccess.Text = "Access";
            this.btnAccess.UseVisualStyleBackColor = true;
            this.btnAccess.Click += new System.EventHandler(this.btnAccess_Click);
            // 
            // listBoxProjects
            // 
            this.listBoxProjects.Enabled = false;
            this.listBoxProjects.FormattingEnabled = true;
            this.listBoxProjects.ItemHeight = 16;
            this.listBoxProjects.Location = new System.Drawing.Point(16, 189);
            this.listBoxProjects.Name = "listBoxProjects";
            this.listBoxProjects.Size = new System.Drawing.Size(200, 84);
            this.listBoxProjects.TabIndex = 9;
            this.listBoxProjects.SelectedIndexChanged += new System.EventHandler(this.listBoxProjects_SelectedIndexChanged);
            // 
            // btnGetServers
            // 
            this.btnGetServers.Enabled = false;
            this.btnGetServers.Location = new System.Drawing.Point(238, 213);
            this.btnGetServers.Name = "btnGetServers";
            this.btnGetServers.Size = new System.Drawing.Size(121, 28);
            this.btnGetServers.TabIndex = 10;
            this.btnGetServers.Text = "Get Servers >>>";
            this.btnGetServers.UseVisualStyleBackColor = true;
            this.btnGetServers.Click += new System.EventHandler(this.btnGetServers_Click);
            // 
            // listBoxServers
            // 
            this.listBoxServers.Enabled = false;
            this.listBoxServers.FormattingEnabled = true;
            this.listBoxServers.ItemHeight = 16;
            this.listBoxServers.Location = new System.Drawing.Point(378, 189);
            this.listBoxServers.Name = "listBoxServers";
            this.listBoxServers.Size = new System.Drawing.Size(200, 100);
            this.listBoxServers.TabIndex = 11;
            this.listBoxServers.SelectedIndexChanged += new System.EventHandler(this.listBoxServers_SelectedIndexChanged);
            // 
            // groupServerInfo
            // 
            this.groupServerInfo.Controls.Add(this.labelDisk);
            this.groupServerInfo.Controls.Add(this.label8);
            this.groupServerInfo.Controls.Add(this.labelRAM);
            this.groupServerInfo.Controls.Add(this.label6);
            this.groupServerInfo.Controls.Add(this.labelCPU);
            this.groupServerInfo.Controls.Add(this.label7);
            this.groupServerInfo.Controls.Add(this.labelState);
            this.groupServerInfo.Controls.Add(this.label5);
            this.groupServerInfo.Location = new System.Drawing.Point(584, 173);
            this.groupServerInfo.Name = "groupServerInfo";
            this.groupServerInfo.Size = new System.Drawing.Size(272, 152);
            this.groupServerInfo.TabIndex = 12;
            this.groupServerInfo.TabStop = false;
            this.groupServerInfo.Text = "Server Info:";
            this.groupServerInfo.Visible = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btn_logout
            // 
            this.btn_logout.Location = new System.Drawing.Point(781, 26);
            this.btn_logout.Name = "btn_logout";
            this.btn_logout.Size = new System.Drawing.Size(75, 28);
            this.btn_logout.TabIndex = 14;
            this.btn_logout.Text = "logout";
            this.btn_logout.UseVisualStyleBackColor = true;
            this.btn_logout.Visible = false;
            this.btn_logout.Click += new System.EventHandler(this.btn_logout_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(44, 126);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(48, 17);
            this.labelStatus.TabIndex = 15;
            this.labelStatus.Text = "Status";
            this.labelStatus.Visible = false;
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Location = new System.Drawing.Point(288, 32);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(46, 17);
            this.labelUser.TabIndex = 16;
            this.labelUser.Text = "label5";
            this.labelUser.Visible = false;
            // 
            // btnScope
            // 
            this.btnScope.Enabled = false;
            this.btnScope.Location = new System.Drawing.Point(116, 279);
            this.btnScope.Name = "btnScope";
            this.btnScope.Size = new System.Drawing.Size(100, 32);
            this.btnScope.TabIndex = 17;
            this.btnScope.Text = "Scoped login";
            this.btnScope.UseVisualStyleBackColor = true;
            this.btnScope.Click += new System.EventHandler(this.btnScope_Click);
            // 
            // btn_change_password
            // 
            this.btn_change_password.Location = new System.Drawing.Point(708, 75);
            this.btn_change_password.Name = "btn_change_password";
            this.btn_change_password.Size = new System.Drawing.Size(148, 37);
            this.btn_change_password.TabIndex = 18;
            this.btn_change_password.Text = "Change Password";
            this.btn_change_password.UseVisualStyleBackColor = true;
            this.btn_change_password.Visible = false;
            this.btn_change_password.Click += new System.EventHandler(this.btn_change_password_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(11, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Status:";
            // 
            // labelState
            // 
            this.labelState.AutoSize = true;
            this.labelState.Location = new System.Drawing.Point(69, 31);
            this.labelState.Name = "labelState";
            this.labelState.Size = new System.Drawing.Size(38, 17);
            this.labelState.TabIndex = 1;
            this.labelState.Text = "label";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(11, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 17);
            this.label7.TabIndex = 2;
            this.label7.Text = "CPU:";
            // 
            // labelCPU
            // 
            this.labelCPU.AutoSize = true;
            this.labelCPU.Location = new System.Drawing.Point(57, 61);
            this.labelCPU.Name = "labelCPU";
            this.labelCPU.Size = new System.Drawing.Size(46, 17);
            this.labelCPU.TabIndex = 3;
            this.labelCPU.Text = "label8";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(11, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 17);
            this.label6.TabIndex = 4;
            this.label6.Text = "RAM:";
            // 
            // labelRAM
            // 
            this.labelRAM.AutoSize = true;
            this.labelRAM.Location = new System.Drawing.Point(59, 93);
            this.labelRAM.Name = "labelRAM";
            this.labelRAM.Size = new System.Drawing.Size(46, 17);
            this.labelRAM.TabIndex = 5;
            this.labelRAM.Text = "label8";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(11, 124);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 17);
            this.label8.TabIndex = 6;
            this.label8.Text = "Disk";
            // 
            // labelDisk
            // 
            this.labelDisk.AutoSize = true;
            this.labelDisk.Location = new System.Drawing.Point(52, 124);
            this.labelDisk.Name = "labelDisk";
            this.labelDisk.Size = new System.Drawing.Size(54, 17);
            this.labelDisk.TabIndex = 8;
            this.labelDisk.Text = "label10";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(375, 160);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 17);
            this.label9.TabIndex = 19;
            this.label9.Text = "Servers:";
            // 
            // btnON
            // 
            this.btnON.BackColor = System.Drawing.Color.Green;
            this.btnON.Enabled = false;
            this.btnON.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnON.Location = new System.Drawing.Point(378, 295);
            this.btnON.Name = "btnON";
            this.btnON.Size = new System.Drawing.Size(41, 25);
            this.btnON.TabIndex = 20;
            this.btnON.Text = "ON";
            this.btnON.UseVisualStyleBackColor = false;
            this.btnON.Visible = false;
            this.btnON.Click += new System.EventHandler(this.btnON_Click);
            // 
            // btnSUS
            // 
            this.btnSUS.BackColor = System.Drawing.Color.Gold;
            this.btnSUS.Enabled = false;
            this.btnSUS.Location = new System.Drawing.Point(447, 295);
            this.btnSUS.Name = "btnSUS";
            this.btnSUS.Size = new System.Drawing.Size(52, 25);
            this.btnSUS.TabIndex = 21;
            this.btnSUS.Text = "SUS";
            this.btnSUS.UseVisualStyleBackColor = false;
            this.btnSUS.Visible = false;
            this.btnSUS.Click += new System.EventHandler(this.btnSUS_Click);
            // 
            // btnOFF
            // 
            this.btnOFF.BackColor = System.Drawing.Color.Red;
            this.btnOFF.Enabled = false;
            this.btnOFF.Location = new System.Drawing.Point(527, 295);
            this.btnOFF.Name = "btnOFF";
            this.btnOFF.Size = new System.Drawing.Size(51, 23);
            this.btnOFF.TabIndex = 22;
            this.btnOFF.Text = "OFF";
            this.btnOFF.UseVisualStyleBackColor = false;
            this.btnOFF.Visible = false;
            this.btnOFF.Click += new System.EventHandler(this.btnOFF_Click);
            // 
            // Openstack_Manager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 450);
            this.Controls.Add(this.btnOFF);
            this.Controls.Add(this.btnSUS);
            this.Controls.Add(this.btnON);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btn_change_password);
            this.Controls.Add(this.btnScope);
            this.Controls.Add(this.labelUser);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.btn_logout);
            this.Controls.Add(this.groupServerInfo);
            this.Controls.Add(this.listBoxServers);
            this.Controls.Add(this.btnGetServers);
            this.Controls.Add(this.listBoxProjects);
            this.Controls.Add(this.btnAccess);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxUsername);
            this.Controls.Add(this.textBoxIP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxPassword);
            this.Name = "Openstack_Manager";
            this.Text = "Openstack_Manager";
            this.Load += new System.EventHandler(this.Openstack_Manager_Load);
            this.groupServerInfo.ResumeLayout(false);
            this.groupServerInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxIP;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAccess;
        private System.Windows.Forms.ListBox listBoxProjects;
        private System.Windows.Forms.Button btnGetServers;
        private System.Windows.Forms.ListBox listBoxServers;
        private System.Windows.Forms.GroupBox groupServerInfo;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btn_logout;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.Button btnScope;
        private System.Windows.Forms.Button btn_change_password;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelState;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelCPU;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelRAM;
        private System.Windows.Forms.Label labelDisk;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnON;
        private System.Windows.Forms.Button btnOFF;
        private System.Windows.Forms.Button btnSUS;
    }
}