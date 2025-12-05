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
    public partial class AutorizationForm : Form
    {
        private string captchaValue;
        private Random random = new Random();

        public AutorizationForm()
        {
            InitializeComponent();
        }

        public bool AuthenticateUser(string username, string password, out string userRole, out string fullName)
        {
            userRole = null;
            fullName = null;

            if (username == "o@outlook.com" && password == "2L6KZG")
            {
                userRole = "admin";
                fullName = "Федоров Глеб Михайлович";
                return true;
            }
            else if (username == "admin2" && password == "admin2")
            {
                userRole = "admin";
                fullName = "Ницше Евгений Замятович";
                return true;
            }
            else if (username == "admin3" && password == "admin3")
            {
                userRole = "admin";
                fullName = "Гандзи Пётр Аксёнович";
                return true;
            }
            else if (username == "manager1" && password == "manager1")
            {
                userRole = "manager";
                fullName = "Балабаева Лидия Андреевна";
                return true;
            }
            else if (username == "manager2" && password == "manager2")
            {
                userRole = "manager";
                fullName = "Обманщиков Снитч Импостерович";
                return true;
            }
            else if (username == "manager3" && password == "manager3")
            {
                userRole = "manager";
                fullName = "Торгашов Фрод Продажнович";
                return true;
            }
            else if (username == "client1" && password == "client1")
            {
                userRole = "client";
                fullName = "Оруэлл Джордж Генадьевич";
                return true;
            }
            else if (username == "client2" && password == "client2")
            {
                userRole = "client";
                fullName = "Маяковский Владимир Ильич";
                return true;
            }
            else if (username == "client3" && password == "client3")
            {
                userRole = "client";
                fullName = "Сталин Металл Сплавович";
                return true;
            }
            else if (username == "client4" && password == "client4")
            {
                userRole = "client";
                fullName = "Ленин Ленивец Тунеядцович";
                return true;
            }

            else
            {
                return false;
            }
        }
        public int failedLoginAttempts = 0;
        public string userRole;
        private void button_enter_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;


            
            if (AuthenticateUser(username, password, out userRole, out string fullName))
            {
                
                if (userRole == "admin")
                {
                    AdminForm adminForm = new AdminForm();
                    adminForm.UserName = fullName;
                    adminForm.Show();
                }
                else if (userRole == "manager")
                {
                    ManagerForm managerForm = new ManagerForm();
                    managerForm.UserName = fullName;
                    managerForm.Show();
                }
                else if (userRole == "client")
                {
                    ClientForm clientForm = new ClientForm();
                    clientForm.UserName = fullName;
                    clientForm.Show();
                }

                this.Hide(); 
                failedLoginAttempts = 0;

            }

            else

            {
                failedLoginAttempts++;
                if (failedLoginAttempts >= 2)
                {
                    DisableLogin();
                    MessageBox.Show("Вы не смогли войти дважды. Попробуйте снова через 10 секунд.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    
                    MessageBox.Show("Неверный логин или пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    string captcha = GenerateCaptcha();
                    captchaValue = captcha; 
                    DrawCaptcha(captcha); 

                    
                    textBox1.Enabled = false;
                    textBox2.Enabled = false;
                    button_enter.Enabled = false;

                    textBox3.Visible = true;
                    button_captcha.Visible = true;

                    textBox3.Clear();
                    textBox3.Focus();
                }

            }

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                textBox2.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_enter_Click(sender, e);
                e.SuppressKeyPress = true;
            }
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                textBox1.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void button_enter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                button_enter.PerformClick();

            }
        }


        public string GenerateCaptcha()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, 4)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        private void DrawCaptcha(string captchaText)
        {
            Bitmap bitmap = new Bitmap(200, 100);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.White); 
                Font font = new Font("Arial", 24, FontStyle.Bold);

                
                for (int i = 0; i < captchaText.Length; i++)
                {
                   
                    int x = 20 + i * 30; 
                    int y = random.Next(10, 40); 
                    g.DrawString(captchaText[i].ToString(), font, Brushes.DarkGreen, new PointF(x, y));
                }

                
                for (int i = 0; i < 15; i++)
                {
                    g.DrawLine(Pens.Gray, new Point(0, random.Next(0, 100)), new Point(200, random.Next(0, 100)));
                }

            }
            pictureBoxCaptcha.Image = bitmap;
        }


        public void button_captcha_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == captchaValue)
            {
                MessageBox.Show("CAPTCHA введена верно", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                button_enter.Enabled = true;
                textBox3.Visible = false;
                button_captcha.Visible = false;
                pictureBoxCaptcha.Visible = false;
            }
            else
            {
                MessageBox.Show("CAPTCHA введена неверно. Попробуйте снова.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DisableLogin(); 
            }
        }

        private System.Windows.Forms.Timer timer;
        private void DisableLogin()
        {
            button_enter.Enabled = false; 
            timer = new System.Windows.Forms.Timer(); 
            timer.Interval = 10000; 
            timer.Tick += Timer_Tick;
            timer.Start(); 
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            button_enter.Enabled = true; 
            timer.Stop(); 
            timer.Dispose(); 
        }

        private void AutorizationForm_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_captcha_Click(sender, e);
                e.SuppressKeyPress = true;
            }
        }

        private void linkLabel1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Вы успешно вошли как гость", "Вход", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ProductForm productsList = new ProductForm(this);
            productsList.Show();
            this.Hide();
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void button_enter_Click_1(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;


            if (AuthenticateUser(username, password, out userRole, out string fullName))
            {
                if (userRole == "admin")
                {
                    AdminForm adminForm = new AdminForm();
                    adminForm.UserName = fullName;
                    adminForm.Show();
                }
                else if (userRole == "manager")
                {
                    ManagerForm managerForm = new ManagerForm();
                    managerForm.UserName = fullName;
                    managerForm.Show();
                }
                else if (userRole == "client")
                {
                    ClientForm clientForm = new ClientForm();
                    clientForm.UserName = fullName;
                    clientForm.Show();
                }

                this.Hide(); 
                failedLoginAttempts = 0;

            }

            else

            {
                failedLoginAttempts++;
                if (failedLoginAttempts >= 2)
                {
                    DisableLogin();
                    MessageBox.Show("Вы не смогли войти дважды. Попробуйте снова через 10 секунд.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                   
                    MessageBox.Show("Неверный логин или пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    string captcha = GenerateCaptcha();
                    captchaValue = captcha; 
                    DrawCaptcha(captcha); 

                    textBox1.Enabled = false;
                    textBox2.Enabled = false;
                    button_enter.Enabled = false;

                    textBox3.Visible = true;
                    button_captcha.Visible = true;

                    textBox3.Clear();
                    textBox3.Focus();
                }

            }
        }

        private void button_captcha_Click_1(object sender, EventArgs e)
        {
            if (textBox3.Text == captchaValue)
            {
                MessageBox.Show("CAPTCHA введена верно", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                button_enter.Enabled = true;
                textBox3.Visible = false;
                button_captcha.Visible = false;
                pictureBoxCaptcha.Visible = false;
            }
            else
            {
                MessageBox.Show("CAPTCHA введена неверно. Попробуйте снова.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DisableLogin(); 
            }
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Вы успешно вошли как гость", "Вход", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ProductForm productsList = new ProductForm(this);
            productsList.Show();
            this.Hide();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
