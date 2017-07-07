namespace DDN
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUserNameTip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPsdTip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Location = new System.Drawing.Point(134, 155);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(165, 21);
            this.textBoxUserName.TabIndex = 0;
            this.textBoxUserName.TextChanged += new System.EventHandler(this.textBoxUserName_TextChanged);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(134, 185);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(165, 21);
            this.textBoxPassword.TabIndex = 1;
            this.textBoxPassword.TextChanged += new System.EventHandler(this.textBoxPassword_TextChanged);
            // 
            // checkBoxRemmberPsd
            // 
            this.checkBoxRemmberPsd.AutoSize = true;
            this.checkBoxRemmberPsd.Location = new System.Drawing.Point(134, 212);
            this.checkBoxRemmberPsd.Name = "checkBoxRemmberPsd";
            this.checkBoxRemmberPsd.Size = new System.Drawing.Size(72, 16);
            this.checkBoxRemmberPsd.TabIndex = 2;
            this.checkBoxRemmberPsd.Text = "记住密码";
            this.checkBoxRemmberPsd.UseVisualStyleBackColor = true;
            // 
            // buttonLogin
            // 
            this.buttonLogin.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttonLogin.Location = new System.Drawing.Point(134, 234);
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
            this.pictureBoxUserNameTip.Location = new System.Drawing.Point(304, 156);
            this.pictureBoxUserNameTip.Name = "pictureBoxUserNameTip";
            this.pictureBoxUserNameTip.Size = new System.Drawing.Size(20, 20);
            this.pictureBoxUserNameTip.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxUserNameTip.TabIndex = 5;
            this.pictureBoxUserNameTip.TabStop = false;
            // 
            // pictureBoxPsdTip
            // 
            this.pictureBoxPsdTip.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxPsdTip.Image")));
            this.pictureBoxPsdTip.Location = new System.Drawing.Point(304, 185);
            this.pictureBoxPsdTip.Name = "pictureBoxPsdTip";
            this.pictureBoxPsdTip.Size = new System.Drawing.Size(20, 20);
            this.pictureBoxPsdTip.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxPsdTip.TabIndex = 6;
            this.pictureBoxPsdTip.TabStop = false;
            // 
            // labelRegist
            // 
            this.labelRegist.AutoSize = true;
            this.labelRegist.ForeColor = System.Drawing.Color.DodgerBlue;
            this.labelRegist.Location = new System.Drawing.Point(331, 160);
            this.labelRegist.Name = "labelRegist";
            this.labelRegist.Size = new System.Drawing.Size(53, 12);
            this.labelRegist.TabIndex = 7;
            this.labelRegist.Text = "注册账号";
            this.labelRegist.Click += new System.EventHandler(this.labelRegist_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-1, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(425, 148);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // labelOpreationResult
            // 
            this.labelOpreationResult.AutoSize = true;
            this.labelOpreationResult.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelOpreationResult.ForeColor = System.Drawing.Color.Red;
            this.labelOpreationResult.Location = new System.Drawing.Point(137, 174);
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
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 273);
            this.Controls.Add(this.labelOpreationResult);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelRegist);
            this.Controls.Add(this.pictureBoxPsdTip);
            this.Controls.Add(this.pictureBoxUserNameTip);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.checkBoxRemmberPsd);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxUserName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormLogin";
            this.ShowInTaskbar = false;
            this.Text = "登陆叮叮鸟";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormLoginClose);
            this.Load += new System.EventHandler(this.FormLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUserNameTip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPsdTip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
    }
}