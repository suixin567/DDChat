namespace MainProgram.UserControls
{
    partial class GroupManageMemberItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GroupManageMemberItem));
            this.labelMemberLevel = new System.Windows.Forms.Label();
            this.labelNickName = new System.Windows.Forms.Label();
            this.buttonInfo = new System.Windows.Forms.Button();
            this.pictureBoxFace = new System.Windows.Forms.PictureBox();
            this.buttonRemove = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFace)).BeginInit();
            this.SuspendLayout();
            // 
            // labelMemberLevel
            // 
            this.labelMemberLevel.AutoSize = true;
            this.labelMemberLevel.Location = new System.Drawing.Point(3, 10);
            this.labelMemberLevel.Name = "labelMemberLevel";
            this.labelMemberLevel.Size = new System.Drawing.Size(23, 12);
            this.labelMemberLevel.TabIndex = 1;
            this.labelMemberLevel.Text = "...";
            // 
            // labelNickName
            // 
            this.labelNickName.AutoSize = true;
            this.labelNickName.Location = new System.Drawing.Point(62, 10);
            this.labelNickName.Name = "labelNickName";
            this.labelNickName.Size = new System.Drawing.Size(23, 12);
            this.labelNickName.TabIndex = 2;
            this.labelNickName.Text = "...";
            // 
            // buttonInfo
            // 
            this.buttonInfo.Location = new System.Drawing.Point(251, 5);
            this.buttonInfo.Name = "buttonInfo";
            this.buttonInfo.Size = new System.Drawing.Size(62, 22);
            this.buttonInfo.TabIndex = 3;
            this.buttonInfo.Text = "查看资料";
            this.buttonInfo.UseVisualStyleBackColor = true;
            this.buttonInfo.Click += new System.EventHandler(this.buttonInfo_Click);
            // 
            // pictureBoxFace
            // 
            this.pictureBoxFace.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxFace.Image")));
            this.pictureBoxFace.Location = new System.Drawing.Point(32, 2);
            this.pictureBoxFace.Name = "pictureBoxFace";
            this.pictureBoxFace.Size = new System.Drawing.Size(26, 26);
            this.pictureBoxFace.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxFace.TabIndex = 0;
            this.pictureBoxFace.TabStop = false;
            // 
            // buttonRemove
            // 
            this.buttonRemove.Location = new System.Drawing.Point(318, 5);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(38, 22);
            this.buttonRemove.TabIndex = 4;
            this.buttonRemove.Text = "移除";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // GroupManageMemberItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.buttonInfo);
            this.Controls.Add(this.labelNickName);
            this.Controls.Add(this.labelMemberLevel);
            this.Controls.Add(this.pictureBoxFace);
            this.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.Name = "GroupManageMemberItem";
            this.Size = new System.Drawing.Size(390, 30);
            this.Load += new System.EventHandler(this.GroupManageMemberItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFace)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxFace;
        private System.Windows.Forms.Label labelMemberLevel;
        private System.Windows.Forms.Label labelNickName;
        private System.Windows.Forms.Button buttonInfo;
        private System.Windows.Forms.Button buttonRemove;
    }
}
