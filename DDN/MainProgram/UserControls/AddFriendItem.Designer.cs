namespace MainProgram.UserControls
{
    partial class AddFriendItem
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddFriendItem));
            this.pictureBoxFace = new System.Windows.Forms.PictureBox();
            this.labelNickName = new System.Windows.Forms.Label();
            this.labelUsername = new System.Windows.Forms.Label();
            this.buttonAddFriend = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFace)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxFace
            // 
            this.pictureBoxFace.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxFace.Image")));
            this.pictureBoxFace.Location = new System.Drawing.Point(5, 6);
            this.pictureBoxFace.Name = "pictureBoxFace";
            this.pictureBoxFace.Size = new System.Drawing.Size(70, 70);
            this.pictureBoxFace.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxFace.TabIndex = 0;
            this.pictureBoxFace.TabStop = false;
            // 
            // labelNickName
            // 
            this.labelNickName.AutoSize = true;
            this.labelNickName.Location = new System.Drawing.Point(83, 12);
            this.labelNickName.Name = "labelNickName";
            this.labelNickName.Size = new System.Drawing.Size(53, 12);
            this.labelNickName.TabIndex = 1;
            this.labelNickName.Text = "他的昵称";
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.ForeColor = System.Drawing.Color.Red;
            this.labelUsername.Location = new System.Drawing.Point(83, 28);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(53, 12);
            this.labelUsername.TabIndex = 2;
            this.labelUsername.Text = "(tttttt)";
            // 
            // buttonAddFriend
            // 
            this.buttonAddFriend.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttonAddFriend.Location = new System.Drawing.Point(100, 54);
            this.buttonAddFriend.Name = "buttonAddFriend";
            this.buttonAddFriend.Size = new System.Drawing.Size(69, 25);
            this.buttonAddFriend.TabIndex = 3;
            this.buttonAddFriend.Text = "十 好友";
            this.buttonAddFriend.UseVisualStyleBackColor = false;
            this.buttonAddFriend.Click += new System.EventHandler(this.buttonAddFriend_Click);
            // 
            // AddFriendItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Controls.Add(this.buttonAddFriend);
            this.Controls.Add(this.labelUsername);
            this.Controls.Add(this.labelNickName);
            this.Controls.Add(this.pictureBoxFace);
            this.Name = "AddFriendItem";
            this.Size = new System.Drawing.Size(170, 80);
            this.Load += new System.EventHandler(this.AddFriendItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFace)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxFace;
        private System.Windows.Forms.Label labelNickName;
        public System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Button buttonAddFriend;
    }
}
