namespace MainProgram
{
    partial class FormPersionalInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPersionalInfo));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelNickName = new System.Windows.Forms.Label();
            this.labelDiscription = new System.Windows.Forms.Label();
            this.labelUsername = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(2, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(115, 115);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // labelNickName
            // 
            this.labelNickName.AutoSize = true;
            this.labelNickName.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelNickName.Location = new System.Drawing.Point(130, 14);
            this.labelNickName.Name = "labelNickName";
            this.labelNickName.Size = new System.Drawing.Size(49, 19);
            this.labelNickName.TabIndex = 1;
            this.labelNickName.Text = "昵称";
            // 
            // labelDiscription
            // 
            this.labelDiscription.AutoSize = true;
            this.labelDiscription.Location = new System.Drawing.Point(132, 65);
            this.labelDiscription.Name = "labelDiscription";
            this.labelDiscription.Size = new System.Drawing.Size(101, 12);
            this.labelDiscription.TabIndex = 2;
            this.labelDiscription.Text = "我还没有个性签名";
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Location = new System.Drawing.Point(134, 38);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(35, 12);
            this.labelUsername.TabIndex = 3;
            this.labelUsername.Text = "(...)";
            // 
            // FormPersionalInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 120);
            this.Controls.Add(this.labelUsername);
            this.Controls.Add(this.labelDiscription);
            this.Controls.Add(this.labelNickName);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormPersionalInfo";
            this.ShowInTaskbar = false;
            this.Text = "FormPersionalInfo";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormPersionalInfo_Load);
            this.MouseEnter += new System.EventHandler(this.FormPersionalInfo_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.FormPersionalInfo_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelNickName;
        private System.Windows.Forms.Label labelDiscription;
        private System.Windows.Forms.Label labelUsername;
    }
}