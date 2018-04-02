namespace SDNApp
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.buttonGetSDNData = new System.Windows.Forms.Button();
            this.textBoxSDNIP = new System.Windows.Forms.TextBox();
            this.labelStatus = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.listBoxNodeIDS = new System.Windows.Forms.ListBox();
            this.buttonGetNodeTerminationPoints = new System.Windows.Forms.Button();
            this.listBoxNodeTerminationPoints = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(118, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "SDN IP";
            // 
            // buttonGetSDNData
            // 
            this.buttonGetSDNData.Location = new System.Drawing.Point(12, 44);
            this.buttonGetSDNData.Name = "buttonGetSDNData";
            this.buttonGetSDNData.Size = new System.Drawing.Size(75, 23);
            this.buttonGetSDNData.TabIndex = 2;
            this.buttonGetSDNData.Text = "Get Data";
            this.buttonGetSDNData.UseVisualStyleBackColor = true;
            this.buttonGetSDNData.Click += new System.EventHandler(this.buttonGetNodeIDS_Click);
            // 
            // textBoxSDNIP
            // 
            this.textBoxSDNIP.Location = new System.Drawing.Point(12, 18);
            this.textBoxSDNIP.Name = "textBoxSDNIP";
            this.textBoxSDNIP.Size = new System.Drawing.Size(100, 20);
            this.textBoxSDNIP.TabIndex = 3;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(93, 49);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(37, 13);
            this.labelStatus.TabIndex = 5;
            this.labelStatus.Text = "Status";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(167, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(78, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "192.168.10.3";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // listBoxNodeIDS
            // 
            this.listBoxNodeIDS.FormattingEnabled = true;
            this.listBoxNodeIDS.Location = new System.Drawing.Point(12, 73);
            this.listBoxNodeIDS.Name = "listBoxNodeIDS";
            this.listBoxNodeIDS.Size = new System.Drawing.Size(149, 95);
            this.listBoxNodeIDS.TabIndex = 7;
            this.listBoxNodeIDS.SelectedIndexChanged += new System.EventHandler(this.listBoxNodeIDS_SelectedIndexChanged);
            // 
            // buttonGetNodeTerminationPoints
            // 
            this.buttonGetNodeTerminationPoints.Enabled = false;
            this.buttonGetNodeTerminationPoints.Location = new System.Drawing.Point(167, 109);
            this.buttonGetNodeTerminationPoints.Name = "buttonGetNodeTerminationPoints";
            this.buttonGetNodeTerminationPoints.Size = new System.Drawing.Size(123, 23);
            this.buttonGetNodeTerminationPoints.TabIndex = 8;
            this.buttonGetNodeTerminationPoints.Text = "Get Node TP";
            this.buttonGetNodeTerminationPoints.UseVisualStyleBackColor = true;
            this.buttonGetNodeTerminationPoints.Click += new System.EventHandler(this.buttonGetNodeTerminationPoints_Click);
            // 
            // listBoxNodeTerminationPoints
            // 
            this.listBoxNodeTerminationPoints.FormattingEnabled = true;
            this.listBoxNodeTerminationPoints.Location = new System.Drawing.Point(296, 73);
            this.listBoxNodeTerminationPoints.Name = "listBoxNodeTerminationPoints";
            this.listBoxNodeTerminationPoints.Size = new System.Drawing.Size(155, 95);
            this.listBoxNodeTerminationPoints.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 246);
            this.Controls.Add(this.listBoxNodeTerminationPoints);
            this.Controls.Add(this.buttonGetNodeTerminationPoints);
            this.Controls.Add(this.listBoxNodeIDS);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.textBoxSDNIP);
            this.Controls.Add(this.buttonGetSDNData);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonGetSDNData;
        private System.Windows.Forms.TextBox textBoxSDNIP;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBoxNodeIDS;
        private System.Windows.Forms.Button buttonGetNodeTerminationPoints;
        private System.Windows.Forms.ListBox listBoxNodeTerminationPoints;
    }
}

