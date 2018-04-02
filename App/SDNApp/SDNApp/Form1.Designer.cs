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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.labelStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(157, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "SDN IP";
            // 
            // buttonGetSDNData
            // 
            this.buttonGetSDNData.Location = new System.Drawing.Point(16, 54);
            this.buttonGetSDNData.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonGetSDNData.Name = "buttonGetSDNData";
            this.buttonGetSDNData.Size = new System.Drawing.Size(100, 28);
            this.buttonGetSDNData.TabIndex = 2;
            this.buttonGetSDNData.Text = "Get Data";
            this.buttonGetSDNData.UseVisualStyleBackColor = true;
            this.buttonGetSDNData.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxSDNIP
            // 
            this.textBoxSDNIP.Location = new System.Drawing.Point(16, 22);
            this.textBoxSDNIP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxSDNIP.Name = "textBoxSDNIP";
            this.textBoxSDNIP.Size = new System.Drawing.Size(132, 22);
            this.textBoxSDNIP.TabIndex = 3;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(16, 90);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(267, 117);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(124, 60);
            this.labelStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(48, 17);
            this.labelStatus.TabIndex = 5;
            this.labelStatus.Text = "Status";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 329);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.textBoxSDNIP);
            this.Controls.Add(this.buttonGetSDNData);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonGetSDNData;
        private System.Windows.Forms.TextBox textBoxSDNIP;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label labelStatus;
    }
}

