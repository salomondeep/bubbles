namespace Flavor_Management
{
    partial class Flavor_Management
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
            this.listFlavors = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listFlavors
            // 
            this.listFlavors.FormattingEnabled = true;
            this.listFlavors.ItemHeight = 16;
            this.listFlavors.Location = new System.Drawing.Point(37, 56);
            this.listFlavors.Name = "listFlavors";
            this.listFlavors.Size = new System.Drawing.Size(370, 132);
            this.listFlavors.TabIndex = 0;
            // 
            // Flavor_Management
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 450);
            this.Controls.Add(this.listFlavors);
            this.Name = "Flavor_Management";
            this.Text = "Flavor Management";
            this.Load += new System.EventHandler(this.Flavor_Management_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listFlavors;
    }
}

