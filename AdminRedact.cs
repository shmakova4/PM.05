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
    public partial class AdminRedact : Form
    {
        public AdminRedact()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var redactsForm = new AdminForm();
            redactsForm.Show();
            Hide();
        }

        private void AdminRedact_Load(object sender, EventArgs e)
        {

        }
    }
}
