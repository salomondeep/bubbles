using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SDNApp
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            SDN_Manager manager = new SDN_Manager();
            manager.Show();
        }
    }
}
