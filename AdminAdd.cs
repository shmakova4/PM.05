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
    public partial class AdminAdd : Form
    {
        public AdminAdd()
        {
            InitializeComponent();
        }

        private void AdminAdd_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var redactуыForm = new AdminForm();
            redactуыForm.Show();
            Hide();
        }
    }
}
