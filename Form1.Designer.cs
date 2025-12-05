namespace SHMIP
{
    partial class AutorizationForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutorizationForm));
            this.button_enter = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBoxCaptcha = new System.Windows.Forms.PictureBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button_captcha = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCaptcha)).BeginInit();
            this.SuspendLayout();
            // 
            // button_enter
            // 
            this.button_enter.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_enter.Location = new System.Drawing.Point(249, 249);
            this.button_enter.Name = "button_enter";
            this.button_enter.Size = new System.Drawing.Size(141, 39);
            this.button_enter.TabIndex = 0;
            this.button_enter.Text = "Войти";
            this.button_enter.UseVisualStyleBackColor = true;
            this.button_enter.Click += new System.EventHandler(this.button_enter_Click_1);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(221, 116);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(198, 22);
            this.textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(222, 170);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(198, 22);
            this.textBox2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(292, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Логин";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(288, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Пароль";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(215, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(205, 41);
            this.label3.TabIndex = 5;
            this.label3.Text = "Авторизация";
            // 
            // pictureBoxCaptcha
            // 
            this.pictureBoxCaptcha.Location = new System.Drawing.Point(447, 48);
            this.pictureBoxCaptcha.Name = "pictureBoxCaptcha";
            this.pictureBoxCaptcha.Size = new System.Drawing.Size(199, 90);
            this.pictureBoxCaptcha.TabIndex = 6;
            this.pictureBoxCaptcha.TabStop = false;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(447, 164);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(199, 22);
            this.textBox3.TabIndex = 7;
            this.textBox3.Visible = false;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // button_captcha
            // 
            this.button_captcha.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_captcha.Location = new System.Drawing.Point(465, 207);
            this.button_captcha.Name = "button_captcha";
            this.button_captcha.Size = new System.Drawing.Size(158, 35);
            this.button_captcha.TabIndex = 8;
            this.button_captcha.Text = "Подтвердить";
            this.button_captcha.UseVisualStyleBackColor = true;
            this.button_captcha.Visible = false;
            this.button_captcha.Click += new System.EventHandler(this.button_captcha_Click_1);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Comic Sans MS", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.linkLabel1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(140)))), ((int)(((byte)(81)))));
            this.linkLabel1.Location = new System.Drawing.Point(265, 217);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(106, 18);
            this.linkLabel1.TabIndex = 9;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Войти как гость";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked_1);
            // 
            // AutorizationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(707, 310);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.button_captcha);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.pictureBoxCaptcha);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button_enter);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AutorizationForm";
            this.Text = "AutorizationForm";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCaptcha)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBoxCaptcha;
        private System.Windows.Forms.LinkLabel linkLabel1;
        public System.Windows.Forms.TextBox textBox3;
        public System.Windows.Forms.Button button_captcha;
        public System.Windows.Forms.Button button_enter;
    }
}

