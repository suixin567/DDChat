namespace MainProgram.UserControls
{
    partial class MainTabControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainTabControl));
            this.pictureBoxDia = new System.Windows.Forms.PictureBox();
            this.pictureBoxFriend = new System.Windows.Forms.PictureBox();
            this.pictureBoxGroup = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFriend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGroup)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxDia
            // 
            this.pictureBoxDia.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxDia.Image")));
            this.pictureBoxDia.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxDia.Name = "pictureBoxDia";
            this.pictureBoxDia.Size = new System.Drawing.Size(90, 31);
            this.pictureBoxDia.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxDia.TabIndex = 0;
            this.pictureBoxDia.TabStop = false;
            this.pictureBoxDia.Click += new System.EventHandler(this.pictureBoxDia_Click);
            this.pictureBoxDia.MouseLeave += new System.EventHandler(this.pictureBoxDia_MouseLeave);
            this.pictureBoxDia.MouseHover += new System.EventHandler(this.pictureBoxDia_MouseHover);
            // 
            // pictureBoxFriend
            // 
            this.pictureBoxFriend.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxFriend.Image")));
            this.pictureBoxFriend.Location = new System.Drawing.Point(93, 0);
            this.pictureBoxFriend.Name = "pictureBoxFriend";
            this.pictureBoxFriend.Size = new System.Drawing.Size(90, 31);
            this.pictureBoxFriend.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxFriend.TabIndex = 1;
            this.pictureBoxFriend.TabStop = false;
            this.pictureBoxFriend.Click += new System.EventHandler(this.pictureBoxFriend_Click);
            this.pictureBoxFriend.MouseLeave += new System.EventHandler(this.pictureBoxFriend_MouseLeave);
            this.pictureBoxFriend.MouseHover += new System.EventHandler(this.pictureBoxFriend_MouseHover);
            // 
            // pictureBoxGroup
            // 
            this.pictureBoxGroup.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxGroup.Image")));
            this.pictureBoxGroup.Location = new System.Drawing.Point(186, 0);
            this.pictureBoxGroup.Name = "pictureBoxGroup";
            this.pictureBoxGroup.Size = new System.Drawing.Size(90, 31);
            this.pictureBoxGroup.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxGroup.TabIndex = 2;
            this.pictureBoxGroup.TabStop = false;
            this.pictureBoxGroup.Click += new System.EventHandler(this.pictureBoxGroup_Click);
            this.pictureBoxGroup.MouseLeave += new System.EventHandler(this.pictureBoxGroup_MouseLeave);
            this.pictureBoxGroup.MouseHover += new System.EventHandler(this.pictureBoxGroup_MouseHover);
            // 
            // MainTabControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pictureBoxGroup);
            this.Controls.Add(this.pictureBoxFriend);
            this.Controls.Add(this.pictureBoxDia);
            this.Name = "MainTabControl";
            this.Size = new System.Drawing.Size(272, 31);
            this.Load += new System.EventHandler(this.MainTabControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFriend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGroup)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxDia;
        private System.Windows.Forms.PictureBox pictureBoxFriend;
        private System.Windows.Forms.PictureBox pictureBoxGroup;
    }
}
