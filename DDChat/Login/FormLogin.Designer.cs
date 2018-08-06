namespace Login
{
    partial class FormLogin
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.checkBoxRemmberPsd = new System.Windows.Forms.CheckBox();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.pictureBoxUserNameTip = new System.Windows.Forms.PictureBox();
            this.pictureBoxPsdTip = new System.Windows.Forms.PictureBox();
            this.labelRegist = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelOpreationResult = new System.Windows.Forms.Label();
            this.timerOpreationResult = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.labelForget = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUserNameTip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPsdTip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Location = new System.Drawing.Point(281, 195);
            this.textBoxUserName.MaxLength = 10;
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(165, 21);
            this.textBoxUserName.TabIndex = 0;
            this.textBoxUserName.TextChanged += new System.EventHandler(this.textBoxUserName_TextChanged);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(281, 225);
            this.textBoxPassword.MaxLength = 13;
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(165, 21);
            this.textBoxPassword.TabIndex = 1;
            this.textBoxPassword.TextChanged += new System.EventHandler(this.textBoxPassword_TextChanged);
            // 
            // checkBoxRemmberPsd
            // 
            this.checkBoxRemmberPsd.AutoSize = true;
            this.checkBoxRemmberPsd.Location = new System.Drawing.Point(281, 252);
            this.checkBoxRemmberPsd.Name = "checkBoxRemmberPsd";
            this.checkBoxRemmberPsd.Size = new System.Drawing.Size(72, 16);
            this.checkBoxRemmberPsd.TabIndex = 2;
            this.checkBoxRemmberPsd.Text = "记住密码";
            this.checkBoxRemmberPsd.UseVisualStyleBackColor = true;
            // 
            // buttonLogin
            // 
            this.buttonLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.buttonLogin.ForeColor = System.Drawing.Color.White;
            this.buttonLogin.Location = new System.Drawing.Point(281, 274);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(165, 34);
            this.buttonLogin.TabIndex = 3;
            this.buttonLogin.Text = "登陆";
            this.buttonLogin.UseVisualStyleBackColor = false;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // pictureBoxUserNameTip
            // 
            this.pictureBoxUserNameTip.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxUserNameTip.Image")));
            this.pictureBoxUserNameTip.Location = new System.Drawing.Point(451, 196);
            this.pictureBoxUserNameTip.Name = "pictureBoxUserNameTip";
            this.pictureBoxUserNameTip.Size = new System.Drawing.Size(20, 20);
            this.pictureBoxUserNameTip.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxUserNameTip.TabIndex = 5;
            this.pictureBoxUserNameTip.TabStop = false;
            // 
            // pictureBoxPsdTip
            // 
            this.pictureBoxPsdTip.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxPsdTip.Image")));
            this.pictureBoxPsdTip.Location = new System.Drawing.Point(451, 225);
            this.pictureBoxPsdTip.Name = "pictureBoxPsdTip";
            this.pictureBoxPsdTip.Size = new System.Drawing.Size(20, 20);
            this.pictureBoxPsdTip.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxPsdTip.TabIndex = 6;
            this.pictureBoxPsdTip.TabStop = false;
            // 
            // labelRegist
            // 
            this.labelRegist.AutoSize = true;
            this.labelRegist.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelRegist.ForeColor = System.Drawing.Color.DodgerBlue;
            this.labelRegist.Location = new System.Drawing.Point(478, 200);
            this.labelRegist.Name = "labelRegist";
            this.labelRegist.Size = new System.Drawing.Size(53, 12);
            this.labelRegist.TabIndex = 7;
            this.labelRegist.Text = "注册账号";
            this.labelRegist.Click += new System.EventHandler(this.labelRegist_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(212, 34);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(388, 127);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // labelOpreationResult
            // 
            this.labelOpreationResult.AutoSize = true;
            this.labelOpreationResult.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelOpreationResult.ForeColor = System.Drawing.Color.Red;
            this.labelOpreationResult.Location = new System.Drawing.Point(284, 214);
            this.labelOpreationResult.Name = "labelOpreationResult";
            this.labelOpreationResult.Size = new System.Drawing.Size(97, 14);
            this.labelOpreationResult.TabIndex = 9;
            this.labelOpreationResult.Text = "操作结果提示";
            // 
            // timerOpreationResult
            // 
            this.timerOpreationResult.Enabled = true;
            this.timerOpreationResult.Interval = 1000;
            this.timerOpreationResult.Tick += new System.EventHandler(this.timerOpreationResult_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "登录叮叮鸟";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.pictureBox2.Location = new System.Drawing.Point(-2, 34);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(213, 306);
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(569, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(28, 28);
            this.button1.TabIndex = 13;
            this.button1.Text = "×";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Orange;
            this.label2.Location = new System.Drawing.Point(12, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 16);
            this.label2.TabIndex = 14;
            this.label2.Text = " 3D装修，就来叮叮鸟！";
            // 
            // labelForget
            // 
            this.labelForget.AutoSize = true;
            this.labelForget.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelForget.ForeColor = System.Drawing.Color.DodgerBlue;
            this.labelForget.Location = new System.Drawing.Point(478, 228);
            this.labelForget.Name = "labelForget";
            this.labelForget.Size = new System.Drawing.Size(53, 12);
            this.labelForget.TabIndex = 15;
            this.labelForget.Text = "找回密码";
            this.labelForget.Click += new System.EventHandler(this.labelForget_Click);
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(600, 340);
            this.Controls.Add(this.labelForget);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.labelOpreationResult);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelRegist);
            this.Controls.Add(this.pictureBoxPsdTip);
            this.Controls.Add(this.pictureBoxUserNameTip);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.checkBoxRemmberPsd);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxUserName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormLogin";
            this.ShowInTaskbar = false;
            this.Text = "登陆";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormLoginClose);
            this.Load += new System.EventHandler(this.FormLogin_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormLogin_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUserNameTip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPsdTip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.CheckBox checkBoxRemmberPsd;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.PictureBox pictureBoxUserNameTip;
        private System.Windows.Forms.PictureBox pictureBoxPsdTip;
        private System.Windows.Forms.Label labelRegist;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelOpreationResult;
        private System.Windows.Forms.Timer timerOpreationResult;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelForget;
    }
}