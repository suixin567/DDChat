namespace DDN.UserControls
{
    partial class AddGroupItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddGroupItem));
            this.pictureBoxFace = new System.Windows.Forms.PictureBox();
            this.labelName = new System.Windows.Forms.Label();
            this.labelGid = new System.Windows.Forms.Label();
            this.buttonJoin = new System.Windows.Forms.Button();
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
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(81, 12);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(59, 12);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "拉取中...";
            // 
            // labelGid
            // 
            this.labelGid.AutoSize = true;
            this.labelGid.ForeColor = System.Drawing.Color.Red;
            this.labelGid.Location = new System.Drawing.Point(81, 33);
            this.labelGid.Name = "labelGid";
            this.labelGid.Size = new System.Drawing.Size(59, 12);
            this.labelGid.TabIndex = 2;
            this.labelGid.Text = "拉取中...";
            // 
            // buttonJoin
            // 
            this.buttonJoin.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttonJoin.Location = new System.Drawing.Point(95, 54);
            this.buttonJoin.Name = "buttonJoin";
            this.buttonJoin.Size = new System.Drawing.Size(69, 25);
            this.buttonJoin.TabIndex = 3;
            this.buttonJoin.Text = "加入";
            this.buttonJoin.UseVisualStyleBackColor = false;
            this.buttonJoin.Click += new System.EventHandler(this.buttonJoin_Click);
            // 
            // AddGroupItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonJoin);
            this.Controls.Add(this.labelGid);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.pictureBoxFace);
            this.Name = "AddGroupItem";
            this.Size = new System.Drawing.Size(170, 80);
            this.Load += new System.EventHandler(this.AddGroupItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFace)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxFace;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelGid;
        private System.Windows.Forms.Button buttonJoin;
    }
}
