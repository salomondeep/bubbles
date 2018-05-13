namespace SDNApp
{
    partial class StartForm
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
            this.btn_Start_Openstack = new System.Windows.Forms.Button();
            this.btn_start_Opendaylight = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Start_Openstack
            // 
            this.btn_Start_Openstack.Location = new System.Drawing.Point(111, 262);
            this.btn_Start_Openstack.Name = "btn_Start_Openstack";
            this.btn_Start_Openstack.Size = new System.Drawing.Size(171, 38);
            this.btn_Start_Openstack.TabIndex = 0;
            this.btn_Start_Openstack.Text = "Openstack Manager";
            this.btn_Start_Openstack.UseVisualStyleBackColor = true;
            this.btn_Start_Openstack.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // btn_start_Opendaylight
            // 
            this.btn_start_Opendaylight.Location = new System.Drawing.Point(111, 141);
            this.btn_start_Opendaylight.Name = "btn_start_Opendaylight";
            this.btn_start_Opendaylight.Size = new System.Drawing.Size(171, 38);
            this.btn_start_Opendaylight.TabIndex = 1;
            this.btn_start_Opendaylight.Text = "Opendaylight Manager";
            this.btn_start_Opendaylight.UseVisualStyleBackColor = true;
            this.btn_start_Opendaylight.Click += new System.EventHandler(this.btn_start_Opendaylight_Click);
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 450);
            this.Controls.Add(this.btn_start_Opendaylight);
            this.Controls.Add(this.btn_Start_Openstack);
            this.Name = "StartForm";
            this.Text = "StartForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Start_Openstack;
        private System.Windows.Forms.Button btn_start_Opendaylight;
    }
}