using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SHMIP
{
    public partial class ManagerForm : Form
    {
        public ManagerForm()
        {
            InitializeComponent();
        }

        private void ManagerForm_Load(object sender, EventArgs e)
        {

        }

        public string UserName
        {
            set { labelUserName.Text = value; }
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            AutorizationForm autorizationForm = new AutorizationForm();
            autorizationForm.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var redacdAtForm = new AutorizationForm();
            redacdAtForm.Show();
            Hide();
        }
    }
}
