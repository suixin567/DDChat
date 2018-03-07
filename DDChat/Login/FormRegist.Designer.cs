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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUserNameTip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPsdTip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPhoneTip)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxRegistUserName
            // 
            this.textBoxRegistUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxRegistUserName.Location = new System.Drawing.Point(152, 60);
            this.textBoxRegistUserName.MaxLength = 10;
            this.textBoxRegistUserName.Name = "textBoxRegistUserName";
            this.textBoxRegistUserName.Size = new System.Drawing.Size(159, 21);
            this.textBoxRegistUserName.TabIndex = 0;
            this.textBoxRegistUserName.TextChanged += new System.EventHandler(this.onUserNameChanged);
            // 
            // textBoxRegistPsd
            // 
            this.textBoxRegistPsd.Location = new System.Drawing.Point(152, 112);
            this.textBoxRegistPsd.MaxLength = 13;
            this.textBoxRegistPsd.Name = "textBoxRegistPsd";
            this.textBoxRegistPsd.Size = new System.Drawing.Size(159, 21);
            this.textBoxRegistPsd.TabIndex = 1;
            this.textBoxRegistPsd.TextChanged += new System.EventHandler(this.onPsdChanged);
            // 
            // textBoxRegistPhone
            // 
            this.textBoxRegistPhone.Location = new System.Drawing.Point(152, 166);
            this.textBoxRegistPhone.MaxLength = 11;
            this.textBoxRegistPhone.Name = "textBoxRegistPhone";
            this.textBoxRegistPhone.Size = new System.Drawing.Size(159, 21);
            this.textBoxRegistPhone.TabIndex = 2;
            this.textBoxRegistPhone.TextChanged += new System.EventHandler(this.onPhoneChanged);
            // 
            // buttonRegistCommit
            // 
            this.buttonRegistCommit.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttonRegistCommit.Location = new System.Drawing.Point(152, 247);
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
            this.label1.Location = new System.Drawing.Point(62, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "注册账号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "注册密码";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(62, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "手机号码";
            // 
            // pictureBoxUserNameTip
            // 
            this.pictureBoxUserNameTip.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxUserNameTip.Image")));
            this.pictureBoxUserNameTip.Location = new System.Drawing.Point(315, 60);
            this.pictureBoxUserNameTip.Name = "pictureBoxUserNameTip";
            this.pictureBoxUserNameTip.Size = new System.Drawing.Size(20, 20);
            this.pictureBoxUserNameTip.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxUserNameTip.TabIndex = 8;
            this.pictureBoxUserNameTip.TabStop = false;
            // 
            // pictureBoxPsdTip
            // 
            this.pictureBoxPsdTip.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxPsdTip.Image")));
            this.pictureBoxPsdTip.Location = new System.Drawing.Point(316, 113);
            this.pictureBoxPsdTip.Name = "pictureBoxPsdTip";
            this.pictureBoxPsdTip.Size = new System.Drawing.Size(20, 20);
            this.pictureBoxPsdTip.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxPsdTip.TabIndex = 9;
            this.pictureBoxPsdTip.TabStop = false;
            // 
            // pictureBoxPhoneTip
            // 
            this.pictureBoxPhoneTip.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxPhoneTip.Image")));
            this.pictureBoxPhoneTip.Location = new System.Drawing.Point(316, 167);
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
            this.labelregistResult.Location = new System.Drawing.Point(337, 64);
            this.labelregistResult.Name = "labelregistResult";
            this.labelregistResult.Size = new System.Drawing.Size(53, 12);
            this.labelregistResult.TabIndex = 11;
            this.labelregistResult.Text = "注册结果";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(152, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(215, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "账号仅能包含6-10位数字(不能以0开头)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(152, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(173, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "密码仅能包含6-13位字母、数字";
            // 
            // FormRegist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 311);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormRegist";
            this.ShowInTaskbar = false;
            this.Text = "注册叮叮鸟";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormRegist_Load);
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
    }
}