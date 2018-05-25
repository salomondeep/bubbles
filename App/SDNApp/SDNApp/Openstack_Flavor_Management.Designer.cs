namespace SDNApp
{
    partial class Openstack_Flavor_Management
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
            this.listBoxFlavors = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelDISK = new System.Windows.Forms.Label();
            this.labelVCPU = new System.Windows.Forms.Label();
            this.labelRAM = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxDISK = new System.Windows.Forms.TextBox();
            this.textBoxRAM = new System.Windows.Forms.TextBox();
            this.textBoxVCPU = new System.Windows.Forms.TextBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxFlavors
            // 
            this.listBoxFlavors.FormattingEnabled = true;
            this.listBoxFlavors.ItemHeight = 16;
            this.listBoxFlavors.Location = new System.Drawing.Point(50, 50);
            this.listBoxFlavors.Name = "listBoxFlavors";
            this.listBoxFlavors.Size = new System.Drawing.Size(365, 100);
            this.listBoxFlavors.TabIndex = 0;
            this.listBoxFlavors.SelectedIndexChanged += new System.EventHandler(this.listBoxFlavors_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelDISK);
            this.groupBox1.Controls.Add(this.labelVCPU);
            this.groupBox1.Controls.Add(this.labelRAM);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(50, 163);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(176, 109);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Flavor Info";
            this.groupBox1.Visible = false;
            // 
            // labelDISK
            // 
            this.labelDISK.AutoSize = true;
            this.labelDISK.Location = new System.Drawing.Point(59, 73);
            this.labelDISK.Name = "labelDISK";
            this.labelDISK.Size = new System.Drawing.Size(46, 17);
            this.labelDISK.TabIndex = 2;
            this.labelDISK.Text = "label4";
            // 
            // labelVCPU
            // 
            this.labelVCPU.AutoSize = true;
            this.labelVCPU.Location = new System.Drawing.Point(57, 49);
            this.labelVCPU.Name = "labelVCPU";
            this.labelVCPU.Size = new System.Drawing.Size(46, 17);
            this.labelVCPU.TabIndex = 2;
            this.labelVCPU.Text = "label4";
            // 
            // labelRAM
            // 
            this.labelRAM.AutoSize = true;
            this.labelRAM.Location = new System.Drawing.Point(57, 23);
            this.labelRAM.Name = "labelRAM";
            this.labelRAM.Size = new System.Drawing.Size(46, 17);
            this.labelRAM.TabIndex = 5;
            this.labelRAM.Text = "label4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "DISK:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "VCPU:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "RAM:";
            // 
            // btnCreate
            // 
            this.btnCreate.BackColor = System.Drawing.Color.Green;
            this.btnCreate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCreate.Location = new System.Drawing.Point(265, 169);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(114, 34);
            this.btnCreate.TabIndex = 2;
            this.btnCreate.Text = "Create New";
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Red;
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(265, 219);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(114, 34);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 303);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Name:";
            this.label4.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(210, 385);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "DISK:";
            this.label5.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(47, 385);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 17);
            this.label6.TabIndex = 6;
            this.label6.Text = "VCPU:";
            this.label6.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(210, 303);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 17);
            this.label7.TabIndex = 7;
            this.label7.Text = "RAM:";
            this.label7.Visible = false;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(102, 303);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(86, 22);
            this.textBoxName.TabIndex = 8;
            this.textBoxName.Visible = false;
            // 
            // textBoxDISK
            // 
            this.textBoxDISK.Location = new System.Drawing.Point(258, 380);
            this.textBoxDISK.Name = "textBoxDISK";
            this.textBoxDISK.Size = new System.Drawing.Size(86, 22);
            this.textBoxDISK.TabIndex = 9;
            this.textBoxDISK.Visible = false;
            // 
            // textBoxRAM
            // 
            this.textBoxRAM.Location = new System.Drawing.Point(258, 300);
            this.textBoxRAM.Name = "textBoxRAM";
            this.textBoxRAM.Size = new System.Drawing.Size(86, 22);
            this.textBoxRAM.TabIndex = 10;
            this.textBoxRAM.Visible = false;
            // 
            // textBoxVCPU
            // 
            this.textBoxVCPU.Location = new System.Drawing.Point(102, 380);
            this.textBoxVCPU.Name = "textBoxVCPU";
            this.textBoxVCPU.Size = new System.Drawing.Size(86, 22);
            this.textBoxVCPU.TabIndex = 11;
            this.textBoxVCPU.Visible = false;
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(353, 409);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 29);
            this.btnApply.TabIndex = 12;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Visible = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // Openstack_Flavor_Management
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 450);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.textBoxVCPU);
            this.Controls.Add(this.textBoxRAM);
            this.Controls.Add(this.textBoxDISK);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listBoxFlavors);
            this.Name = "Openstack_Flavor_Management";
            this.Text = "Openstack_Flavor_Management";
            this.Load += new System.EventHandler(this.Openstack_Flavor_Management_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxFlavors;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelDISK;
        private System.Windows.Forms.Label labelVCPU;
        private System.Windows.Forms.Label labelRAM;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxDISK;
        private System.Windows.Forms.TextBox textBoxRAM;
        private System.Windows.Forms.TextBox textBoxVCPU;
        private System.Windows.Forms.Button btnApply;
    }
}