namespace MainProgram
{
    partial class FormAddFriend
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddFriend));
            this.textBoxFindFriend = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxFindCompany = new System.Windows.Forms.TextBox();
            this.buttonFindFriend = new System.Windows.Forms.Button();
            this.buttonFindCompany = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanelStrangers = new System.Windows.Forms.FlowLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.labelOpreationResult = new System.Windows.Forms.Label();
            this.timerOpreationResult = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxFindFriend
            // 
            this.textBoxFindFriend.Location = new System.Drawing.Point(37, 49);
            this.textBoxFindFriend.MaxLength = 20;
            this.textBoxFindFriend.Name = "textBoxFindFriend";
            this.textBoxFindFriend.Size = new System.Drawing.Size(182, 21);
            this.textBoxFindFriend.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(5, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "找人";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(374, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "找公司";
            // 
            // textBoxFindCompany
            // 
            this.textBoxFindCompany.Location = new System.Drawing.Point(422, 49);
            this.textBoxFindCompany.MaxLength = 20;
            this.textBoxFindCompany.Name = "textBoxFindCompany";
            this.textBoxFindCompany.Size = new System.Drawing.Size(181, 21);
            this.textBoxFindCompany.TabIndex = 3;
            // 
            // buttonFindFriend
            // 
            this.buttonFindFriend.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttonFindFriend.Location = new System.Drawing.Point(252, 41);
            this.buttonFindFriend.Name = "buttonFindFriend";
            this.buttonFindFriend.Size = new System.Drawing.Size(90, 35);
            this.buttonFindFriend.TabIndex = 4;
            this.buttonFindFriend.Text = "查找";
            this.buttonFindFriend.UseVisualStyleBackColor = false;
            this.buttonFindFriend.Click += new System.EventHandler(this.buttonFindFriend_Click);
            // 
            // buttonFindCompany
            // 
            this.buttonFindCompany.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttonFindCompany.Location = new System.Drawing.Point(639, 41);
            this.buttonFindCompany.Name = "buttonFindCompany";
            this.buttonFindCompany.Size = new System.Drawing.Size(79, 35);
            this.buttonFindCompany.TabIndex = 5;
            this.buttonFindCompany.Text = "查找";
            this.buttonFindCompany.UseVisualStyleBackColor = false;
            this.buttonFindCompany.Click += new System.EventHandler(this.buttonFindCompany_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "请输入对方账号或昵称";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(420, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "请输入想查找的公司ID";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlText;
            this.pictureBox1.Location = new System.Drawing.Point(-6, 83);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(767, 2);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // flowLayoutPanelStrangers
            // 
            this.flowLayoutPanelStrangers.AutoScroll = true;
            this.flowLayoutPanelStrangers.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.flowLayoutPanelStrangers.Location = new System.Drawing.Point(11, 111);
            this.flowLayoutPanelStrangers.Name = "flowLayoutPanelStrangers";
            this.flowLayoutPanelStrangers.Padding = new System.Windows.Forms.Padding(5, 3, 0, 0);
            this.flowLayoutPanelStrangers.Size = new System.Drawing.Size(732, 299);
            this.flowLayoutPanelStrangers.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "查找结果：";
            // 
            // labelOpreationResult
            // 
            this.labelOpreationResult.AutoSize = true;
            this.labelOpreationResult.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelOpreationResult.ForeColor = System.Drawing.Color.Red;
            this.labelOpreationResult.Location = new System.Drawing.Point(82, 92);
            this.labelOpreationResult.Name = "labelOpreationResult";
            this.labelOpreationResult.Size = new System.Drawing.Size(127, 14);
            this.labelOpreationResult.TabIndex = 11;
            this.labelOpreationResult.Text = "这里展示操作结果";
            // 
            // timerOpreationResult
            // 
            this.timerOpreationResult.Enabled = true;
            this.timerOpreationResult.Interval = 1000;
            this.timerOpreationResult.Tick += new System.EventHandler(this.timerOpreationResult_Tick);
            // 
            // FormAddFriend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 421);
            this.Controls.Add(this.labelOpreationResult);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.flowLayoutPanelStrangers);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonFindCompany);
            this.Controls.Add(this.buttonFindFriend);
            this.Controls.Add(this.textBoxFindCompany);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxFindFriend);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormAddFriend";
            this.Text = "添加好友";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.closed);
            this.Load += new System.EventHandler(this.FormAddFriend_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxFindFriend;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxFindCompany;
        private System.Windows.Forms.Button buttonFindFriend;
        private System.Windows.Forms.Button buttonFindCompany;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.FlowLayoutPanel flowLayoutPanelStrangers;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelOpreationResult;
        private System.Windows.Forms.Timer timerOpreationResult;
    }
}