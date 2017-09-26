namespace MainProgram
{
    partial class FormShowPersonalInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormShowPersonalInfo));
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonMin = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelUsername = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelDisc = new System.Windows.Forms.Label();
            this.pictureBoxFace = new System.Windows.Forms.PictureBox();
            this.labelNickName = new System.Windows.Forms.Label();
            this.labelModify = new System.Windows.Forms.Label();
            this.labelChangeFace = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFace)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonClose.Location = new System.Drawing.Point(670, 0);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(30, 30);
            this.buttonClose.TabIndex = 0;
            this.buttonClose.Text = "×";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonMin
            // 
            this.buttonMin.FlatAppearance.BorderSize = 0;
            this.buttonMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMin.Location = new System.Drawing.Point(640, 0);
            this.buttonMin.Name = "buttonMin";
            this.buttonMin.Size = new System.Drawing.Size(30, 30);
            this.buttonMin.TabIndex = 1;
            this.buttonMin.Text = "-";
            this.buttonMin.UseVisualStyleBackColor = true;
            this.buttonMin.Click += new System.EventHandler(this.buttonMin_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(350, 520);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormModifyPersonalInfo_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(366, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "账号：";
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Location = new System.Drawing.Point(401, 128);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(41, 12);
            this.labelUsername.TabIndex = 4;
            this.labelUsername.Text = "123456";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(366, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "个人签名：";
            // 
            // labelDisc
            // 
            this.labelDisc.AutoSize = true;
            this.labelDisc.Location = new System.Drawing.Point(425, 157);
            this.labelDisc.Name = "labelDisc";
            this.labelDisc.Size = new System.Drawing.Size(101, 12);
            this.labelDisc.TabIndex = 6;
            this.labelDisc.Text = "我还没有个人签名";
            // 
            // pictureBoxFace
            // 
            this.pictureBoxFace.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxFace.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxFace.Image")));
            this.pictureBoxFace.Location = new System.Drawing.Point(369, 19);
            this.pictureBoxFace.Name = "pictureBoxFace";
            this.pictureBoxFace.Size = new System.Drawing.Size(70, 70);
            this.pictureBoxFace.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxFace.TabIndex = 7;
            this.pictureBoxFace.TabStop = false;
            this.pictureBoxFace.Click += new System.EventHandler(this.pictureBoxFace_Click);
            // 
            // labelNickName
            // 
            this.labelNickName.AutoSize = true;
            this.labelNickName.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelNickName.Location = new System.Drawing.Point(450, 44);
            this.labelNickName.Name = "labelNickName";
            this.labelNickName.Size = new System.Drawing.Size(47, 19);
            this.labelNickName.TabIndex = 8;
            this.labelNickName.Text = "昵称";
            // 
            // labelModify
            // 
            this.labelModify.AutoSize = true;
            this.labelModify.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelModify.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelModify.ForeColor = System.Drawing.Color.SteelBlue;
            this.labelModify.Location = new System.Drawing.Point(613, 45);
            this.labelModify.Name = "labelModify";
            this.labelModify.Size = new System.Drawing.Size(63, 14);
            this.labelModify.TabIndex = 9;
            this.labelModify.Text = "编辑资料";
            this.labelModify.Click += new System.EventHandler(this.labelModify_Click);
            // 
            // labelChangeFace
            // 
            this.labelChangeFace.AutoSize = true;
            this.labelChangeFace.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelChangeFace.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelChangeFace.ForeColor = System.Drawing.Color.Blue;
            this.labelChangeFace.Location = new System.Drawing.Point(367, 92);
            this.labelChangeFace.Name = "labelChangeFace";
            this.labelChangeFace.Size = new System.Drawing.Size(77, 12);
            this.labelChangeFace.TabIndex = 10;
            this.labelChangeFace.Text = "点击更换头像";
            this.labelChangeFace.Click += new System.EventHandler(this.labelChangeFace_Click);
            // 
            // FormShowPersonalInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 520);
            this.Controls.Add(this.labelChangeFace);
            this.Controls.Add(this.labelModify);
            this.Controls.Add(this.labelNickName);
            this.Controls.Add(this.pictureBoxFace);
            this.Controls.Add(this.labelDisc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelUsername);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonMin);
            this.Controls.Add(this.buttonClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormShowPersonalInfo";
            this.Text = "FormModifyPersonalInfo";
            this.Load += new System.EventHandler(this.FormModifyPersonalInfo_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormModifyPersonalInfo_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFace)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonMin;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelDisc;
        private System.Windows.Forms.PictureBox pictureBoxFace;
        private System.Windows.Forms.Label labelNickName;
        private System.Windows.Forms.Label labelModify;
        private System.Windows.Forms.Label labelChangeFace;
    }
}