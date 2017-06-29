namespace DDN
{
    partial class FormCreateGroup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCreateGroup));
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxGroupName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.radioButtonNoVerify = new System.Windows.Forms.RadioButton();
            this.radioButtonVerify = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonCreateGroup = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.labelTip = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "公司名称：";
            // 
            // textBoxGroupName
            // 
            this.textBoxGroupName.AccessibleDescription = "";
            this.textBoxGroupName.Location = new System.Drawing.Point(134, 87);
            this.textBoxGroupName.MaxLength = 10;
            this.textBoxGroupName.Name = "textBoxGroupName";
            this.textBoxGroupName.Size = new System.Drawing.Size(191, 21);
            this.textBoxGroupName.TabIndex = 1;
            this.textBoxGroupName.Tag = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(75, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "公司规模：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(134, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "200人";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(77, 199);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "验证方式：";
            // 
            // radioButtonNoVerify
            // 
            this.radioButtonNoVerify.AutoSize = true;
            this.radioButtonNoVerify.Checked = true;
            this.radioButtonNoVerify.Location = new System.Drawing.Point(153, 197);
            this.radioButtonNoVerify.Name = "radioButtonNoVerify";
            this.radioButtonNoVerify.Size = new System.Drawing.Size(83, 16);
            this.radioButtonNoVerify.TabIndex = 5;
            this.radioButtonNoVerify.TabStop = true;
            this.radioButtonNoVerify.Text = "允许任何人";
            this.radioButtonNoVerify.UseVisualStyleBackColor = true;
            // 
            // radioButtonVerify
            // 
            this.radioButtonVerify.AutoSize = true;
            this.radioButtonVerify.Location = new System.Drawing.Point(249, 197);
            this.radioButtonVerify.Name = "radioButtonVerify";
            this.radioButtonVerify.Size = new System.Drawing.Size(83, 16);
            this.radioButtonVerify.TabIndex = 6;
            this.radioButtonVerify.Text = "需身份验证";
            this.radioButtonVerify.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.buttonCreateGroup);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Location = new System.Drawing.Point(-2, 376);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(539, 36);
            this.panel1.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label6.Location = new System.Drawing.Point(337, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 12);
            this.label6.TabIndex = 3;
            this.label6.Text = "查看建公司资格";
            // 
            // buttonCreateGroup
            // 
            this.buttonCreateGroup.BackColor = System.Drawing.SystemColors.Highlight;
            this.buttonCreateGroup.Location = new System.Drawing.Point(436, 3);
            this.buttonCreateGroup.Name = "buttonCreateGroup";
            this.buttonCreateGroup.Size = new System.Drawing.Size(88, 30);
            this.buttonCreateGroup.TabIndex = 2;
            this.buttonCreateGroup.Text = "完成创建";
            this.buttonCreateGroup.UseVisualStyleBackColor = false;
            this.buttonCreateGroup.Click += new System.EventHandler(this.buttonCreateGroup_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label5.Location = new System.Drawing.Point(105, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "叮叮鸟公司服务协议";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Enabled = false;
            this.checkBox1.Location = new System.Drawing.Point(14, 10);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(96, 16);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "已阅读并同意";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // labelTip
            // 
            this.labelTip.AutoSize = true;
            this.labelTip.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTip.ForeColor = System.Drawing.Color.Red;
            this.labelTip.Location = new System.Drawing.Point(79, 33);
            this.labelTip.Name = "labelTip";
            this.labelTip.Size = new System.Drawing.Size(67, 14);
            this.labelTip.TabIndex = 8;
            this.labelTip.Text = "操作结果";
            // 
            // FormCreateGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 411);
            this.Controls.Add(this.labelTip);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.radioButtonVerify);
            this.Controls.Add(this.radioButtonNoVerify);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxGroupName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormCreateGroup";
            this.Text = "创建公司";
            this.Load += new System.EventHandler(this.FormCreateGroup_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxGroupName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton radioButtonNoVerify;
        private System.Windows.Forms.RadioButton radioButtonVerify;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button buttonCreateGroup;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelTip;
    }
}