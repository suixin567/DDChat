namespace DDN
{
    partial class TopInfoPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TopInfoPanel));
            this.labelSelfNickName = new System.Windows.Forms.Label();
            this.pictureBoxTopFace = new System.Windows.Forms.PictureBox();
            this.labelSelfDescription = new System.Windows.Forms.Label();
            this.labelOnlineState = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTopFace)).BeginInit();
            this.SuspendLayout();
            // 
            // labelSelfNickName
            // 
            this.labelSelfNickName.AutoSize = true;
            this.labelSelfNickName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelSelfNickName.ForeColor = System.Drawing.Color.White;
            this.labelSelfNickName.Location = new System.Drawing.Point(86, 11);
            this.labelSelfNickName.Name = "labelSelfNickName";
            this.labelSelfNickName.Size = new System.Drawing.Size(76, 16);
            this.labelSelfNickName.TabIndex = 1;
            this.labelSelfNickName.Text = "惠佳科技";
            // 
            // pictureBoxTopFace
            // 
            this.pictureBoxTopFace.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxTopFace.Image")));
            this.pictureBoxTopFace.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxTopFace.Name = "pictureBoxTopFace";
            this.pictureBoxTopFace.Size = new System.Drawing.Size(75, 75);
            this.pictureBoxTopFace.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxTopFace.TabIndex = 2;
            this.pictureBoxTopFace.TabStop = false;
            // 
            // labelSelfDescription
            // 
            this.labelSelfDescription.AutoSize = true;
            this.labelSelfDescription.Location = new System.Drawing.Point(86, 40);
            this.labelSelfDescription.Name = "labelSelfDescription";
            this.labelSelfDescription.Size = new System.Drawing.Size(125, 12);
            this.labelSelfDescription.TabIndex = 3;
            this.labelSelfDescription.Text = "今天是个好天气！~~~~";
            // 
            // labelOnlineState
            // 
            this.labelOnlineState.AutoSize = true;
            this.labelOnlineState.ForeColor = System.Drawing.Color.Lime;
            this.labelOnlineState.Location = new System.Drawing.Point(168, 15);
            this.labelOnlineState.Name = "labelOnlineState";
            this.labelOnlineState.Size = new System.Drawing.Size(29, 12);
            this.labelOnlineState.TabIndex = 4;
            this.labelOnlineState.Text = "状态";
            // 
            // TopInfoPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.labelOnlineState);
            this.Controls.Add(this.labelSelfDescription);
            this.Controls.Add(this.pictureBoxTopFace);
            this.Controls.Add(this.labelSelfNickName);
            this.Name = "TopInfoPanel";
            this.Size = new System.Drawing.Size(230, 80);
            this.Load += new System.EventHandler(this.TopInfoPanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTopFace)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelSelfNickName;
        private System.Windows.Forms.PictureBox pictureBoxTopFace;
        private System.Windows.Forms.Label labelSelfDescription;
        private System.Windows.Forms.Label labelOnlineState;
    }
}
