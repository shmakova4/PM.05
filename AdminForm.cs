using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SHMIP
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void AdminForm_Load(object sender, EventArgs e)
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
            var redactForm = new AdminAdd();
            redactForm.Show();   
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var redacAtForm = new AdminRedact();
            redacAtForm.Show();
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var redacdAtForm = new AutorizationForm();
            redacdAtForm.Show();
            Hide();
        }
    }
}
