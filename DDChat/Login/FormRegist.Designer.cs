namespace Login
{
    partial class FormRegist
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRegist));
            this.textBoxRegistUserName = new System.Windows.Forms.TextBox();
            this.textBoxRegistPsd = new System.Windows.Forms.TextBox();
            this.textBoxRegistPhone = new System.Windows.Forms.TextBox();
            this.buttonRegistCommit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBoxUserNameTip = new System.Windows.Forms.PictureBox();
            this.pictureBoxPsdTip = new System.Windows.Forms.PictureBox();
            this.pictureBoxPhoneTip = new System.Windows.Forms.PictureBox();
            this.labelregistResult = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxPhoneCode = new System.Windows.Forms.TextBox();
            this.buttonGetPhoneCode = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUserNameTip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPsdTip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPhoneTip)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxRegistUserName
            // 
            this.textBoxRegistUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxRegistUserName.Location = new System.Drawing.Point(180, 63);
            this.textBoxRegistUserName.MaxLength = 10;
            this.textBoxRegistUserName.Name = "textBoxRegistUserName";
            this.textBoxRegistUserName.Size = new System.Drawing.Size(159, 21);
            this.textBoxRegistUserName.TabIndex = 0;
            this.textBoxRegistUserName.TextChanged += new System.EventHandler(this.onUserNameChanged);
            // 
            // textBoxRegistPsd
            // 
            this.textBoxRegistPsd.Location = new System.Drawing.Point(180, 115);
            this.textBoxRegistPsd.MaxLength = 13;
            this.textBoxRegistPsd.Name = "textBoxRegistPsd";
            this.textBoxRegistPsd.Size = new System.Drawing.Size(159, 21);
            this.textBoxRegistPsd.TabIndex = 1;
            this.textBoxRegistPsd.TextChanged += new System.EventHandler(this.onPsdChanged);
            // 
            // textBoxRegistPhone
            // 
            this.textBoxRegistPhone.Location = new System.Drawing.Point(180, 164);
            this.textBoxRegistPhone.MaxLength = 11;
            this.textBoxRegistPhone.Name = "textBoxRegistPhone";
            this.textBoxRegistPhone.Size = new System.Drawing.Size(159, 21);
            this.textBoxRegistPhone.TabIndex = 2;
            this.textBoxRegistPhone.TextChanged += new System.EventHandler(this.onPhoneChanged);
            // 
            // buttonRegistCommit
            // 
            this.buttonRegistCommit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.buttonRegistCommit.ForeColor = System.Drawing.Color.White;
            this.buttonRegistCommit.Location = new System.Drawing.Point(180, 253);
            this.buttonRegistCommit.Name = "buttonRegistCommit";
            this.buttonRegistCommit.Size = new System.Drawing.Size(159, 31);
            this.buttonRegistCommit.TabIndex = 3;
            this.buttonRegistCommit.Text = "立即注册";
            this.buttonRegistCommit.UseVisualStyleBackColor = false;
            this.buttonRegistCommit.Click += new System.EventHandler(this.buttonRegistCommit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(90, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "注册账号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(90, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "注册密码";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(90, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "手机号码";
            // 
            // pictureBoxUserNameTip
            // 
            this.pictureBoxUserNameTip.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxUserNameTip.Image")));
            this.pictureBoxUserNameTip.Location = new System.Drawing.Point(343, 64);
            this.pictureBoxUserNameTip.Name = "pictureBoxUserNameTip";
            this.pictureBoxUserNameTip.Size = new System.Drawing.Size(20, 20);
            this.pictureBoxUserNameTip.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxUserNameTip.TabIndex = 8;
            this.pictureBoxUserNameTip.TabStop = false;
            // 
            // pictureBoxPsdTip
            // 
            this.pictureBoxPsdTip.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxPsdTip.Image")));
            this.pictureBoxPsdTip.Location = new System.Drawing.Point(344, 116);
            this.pictureBoxPsdTip.Name = "pictureBoxPsdTip";
            this.pictureBoxPsdTip.Size = new System.Drawing.Size(20, 20);
            this.pictureBoxPsdTip.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxPsdTip.TabIndex = 9;
            this.pictureBoxPsdTip.TabStop = false;
            // 
            // pictureBoxPhoneTip
            // 
            this.pictureBoxPhoneTip.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxPhoneTip.Image")));
            this.pictureBoxPhoneTip.Location = new System.Drawing.Point(344, 164);
            this.pictureBoxPhoneTip.Name = "pictureBoxPhoneTip";
            this.pictureBoxPhoneTip.Size = new System.Drawing.Size(20, 20);
            this.pictureBoxPhoneTip.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxPhoneTip.TabIndex = 10;
            this.pictureBoxPhoneTip.TabStop = false;
            // 
            // labelregistResult
            // 
            this.labelregistResult.AutoSize = true;
            this.labelregistResult.ForeColor = System.Drawing.Color.Red;
            this.labelregistResult.Location = new System.Drawing.Point(369, 67);
            this.labelregistResult.Name = "labelregistResult";
            this.labelregistResult.Size = new System.Drawing.Size(53, 12);
            this.labelregistResult.TabIndex = 11;
            this.labelregistResult.Text = "注册结果";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(180, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(215, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "账号仅能包含6-10位数字(不能以0开头)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(180, 98);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(173, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "密码仅能包含6-13位字母、数字";
            // 
            // textBoxPhoneCode
            // 
            this.textBoxPhoneCode.Location = new System.Drawing.Point(180, 211);
            this.textBoxPhoneCode.MaxLength = 11;
            this.textBoxPhoneCode.Name = "textBoxPhoneCode";
            this.textBoxPhoneCode.Size = new System.Drawing.Size(159, 21);
            this.textBoxPhoneCode.TabIndex = 14;
            this.textBoxPhoneCode.Tag = "";
            // 
            // buttonGetPhoneCode
            // 
            this.buttonGetPhoneCode.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonGetPhoneCode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonGetPhoneCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.buttonGetPhoneCode.Location = new System.Drawing.Point(349, 209);
            this.buttonGetPhoneCode.Name = "buttonGetPhoneCode";
            this.buttonGetPhoneCode.Size = new System.Drawing.Size(103, 23);
            this.buttonGetPhoneCode.TabIndex = 16;
            this.buttonGetPhoneCode.Text = "获取短信验证码";
            this.buttonGetPhoneCode.UseVisualStyleBackColor = true;
            this.buttonGetPhoneCode.Click += new System.EventHandler(this.buttonGetPhoneCode_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(90, 214);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 17;
            this.label4.Text = "短信验证码";
            // 
            // buttonClose
            // 
            this.buttonClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonClose.ForeColor = System.Drawing.Color.White;
            this.buttonClose.Location = new System.Drawing.Point(476, 5);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(28, 28);
            this.buttonClose.TabIndex = 18;
            this.buttonClose.Text = "×";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(7, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 19;
            this.label7.Text = "注册叮叮鸟";
            // 
            // FormRegist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(509, 311);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonGetPhoneCode);
            this.Controls.Add(this.textBoxPhoneCode);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelregistResult);
            this.Controls.Add(this.pictureBoxPhoneTip);
            this.Controls.Add(this.pictureBoxPsdTip);
            this.Controls.Add(this.pictureBoxUserNameTip);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonRegistCommit);
            this.Controls.Add(this.textBoxRegistPhone);
            this.Controls.Add(this.textBoxRegistPsd);
            this.Controls.Add(this.textBoxRegistUserName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormRegist";
            this.ShowInTaskbar = false;
            this.Text = "注册叮叮鸟";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormRegist_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormRegist_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUserNameTip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPsdTip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPhoneTip)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxRegistUserName;
        private System.Windows.Forms.TextBox textBoxRegistPsd;
        private System.Windows.Forms.TextBox textBoxRegistPhone;
        private System.Windows.Forms.Button buttonRegistCommit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBoxUserNameTip;
        private System.Windows.Forms.PictureBox pictureBoxPsdTip;
        private System.Windows.Forms.PictureBox pictureBoxPhoneTip;
        public System.Windows.Forms.Label labelregistResult;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxPhoneCode;
        private System.Windows.Forms.Button buttonGetPhoneCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label label7;
    }
}