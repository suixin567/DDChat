namespace Login
{
    partial class FormForget2
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
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonGetPhoneCode = new System.Windows.Forms.Button();
            this.textBoxPhoneCode = new System.Windows.Forms.TextBox();
            this.textBoxPhone = new System.Windows.Forms.TextBox();
            this.labelHponeTip = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonNext
            // 
            this.buttonNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.buttonNext.ForeColor = System.Drawing.Color.White;
            this.buttonNext.Location = new System.Drawing.Point(186, 230);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(111, 27);
            this.buttonNext.TabIndex = 32;
            this.buttonNext.Text = "下一步";
            this.buttonNext.UseVisualStyleBackColor = false;
            this.buttonNext.Click += new System.EventHandler(this.ButtonNext_Click);
            // 
            // buttonGetPhoneCode
            // 
            this.buttonGetPhoneCode.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonGetPhoneCode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonGetPhoneCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.buttonGetPhoneCode.Location = new System.Drawing.Point(344, 183);
            this.buttonGetPhoneCode.Name = "buttonGetPhoneCode";
            this.buttonGetPhoneCode.Size = new System.Drawing.Size(103, 23);
            this.buttonGetPhoneCode.TabIndex = 31;
            this.buttonGetPhoneCode.Text = "获取短信验证码";
            this.buttonGetPhoneCode.UseVisualStyleBackColor = true;
            this.buttonGetPhoneCode.Click += new System.EventHandler(this.ButtonGetPhoneCode_Click);
            // 
            // textBoxPhoneCode
            // 
            this.textBoxPhoneCode.Location = new System.Drawing.Point(163, 185);
            this.textBoxPhoneCode.MaxLength = 4;
            this.textBoxPhoneCode.Name = "textBoxPhoneCode";
            this.textBoxPhoneCode.Size = new System.Drawing.Size(159, 21);
            this.textBoxPhoneCode.TabIndex = 30;
            // 
            // textBoxPhone
            // 
            this.textBoxPhone.Location = new System.Drawing.Point(163, 142);
            this.textBoxPhone.Name = "textBoxPhone";
            this.textBoxPhone.Size = new System.Drawing.Size(159, 21);
            this.textBoxPhone.TabIndex = 29;
            this.textBoxPhone.TextChanged += new System.EventHandler(this.TextBoxPhone_TextChanged);
            // 
            // labelHponeTip
            // 
            this.labelHponeTip.AutoSize = true;
            this.labelHponeTip.Location = new System.Drawing.Point(161, 108);
            this.labelHponeTip.Name = "labelHponeTip";
            this.labelHponeTip.Size = new System.Drawing.Size(107, 12);
            this.labelHponeTip.TabIndex = 28;
            this.labelHponeTip.Text = "提示：157********";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(161, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 12);
            this.label4.TabIndex = 27;
            this.label4.Text = "请输入此账号关联的手机号：";
            // 
            // buttonClose
            // 
            this.buttonClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonClose.ForeColor = System.Drawing.Color.White;
            this.buttonClose.Location = new System.Drawing.Point(468, 4);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(28, 28);
            this.buttonClose.TabIndex = 34;
            this.buttonClose.Text = "×";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 12);
            this.label1.TabIndex = 33;
            this.label1.Text = "第2步：手机短信验证";
            // 
            // FormForget2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(500, 300);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.buttonGetPhoneCode);
            this.Controls.Add(this.textBoxPhoneCode);
            this.Controls.Add(this.textBoxPhone);
            this.Controls.Add(this.labelHponeTip);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormForget2";
            this.ShowInTaskbar = false;
            this.Text = "FormForget2";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormForget2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Button buttonGetPhoneCode;
        private System.Windows.Forms.TextBox textBoxPhoneCode;
        private System.Windows.Forms.TextBox textBoxPhone;
        private System.Windows.Forms.Label labelHponeTip;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label label1;
    }
}