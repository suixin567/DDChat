namespace Dialog
{
    partial class ChatPop
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
            this.panelPop = new System.Windows.Forms.Panel();
            this.richTextBoxEx1 = new Dialog.RichTextBoxEx();
            this.labelNameAndTime = new System.Windows.Forms.Label();
            this.panelPop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelPop
            // 
            this.panelPop.AutoSize = true;
            this.panelPop.Controls.Add(this.richTextBoxEx1);
            this.panelPop.Location = new System.Drawing.Point(6, 19);
            this.panelPop.Name = "panelPop";
            this.panelPop.Size = new System.Drawing.Size(44, 40);
            this.panelPop.TabIndex = 0;
            // 
            // richTextBoxEx1
            // 
            this.richTextBoxEx1.Location = new System.Drawing.Point(3, 3);
            this.richTextBoxEx1.Name = "richTextBoxEx1";
            this.richTextBoxEx1.Size = new System.Drawing.Size(35, 34);
            this.richTextBoxEx1.TabIndex = 0;
            this.richTextBoxEx1.Text = "";
            // 
            // labelNameAndTime
            // 
            this.labelNameAndTime.AutoSize = true;
            this.labelNameAndTime.Location = new System.Drawing.Point(6, 4);
            this.labelNameAndTime.Name = "labelNameAndTime";
            this.labelNameAndTime.Size = new System.Drawing.Size(161, 12);
            this.labelNameAndTime.TabIndex = 1;
            this.labelNameAndTime.Text = "某某某  2017/8/18 11:41:49";
            // 
            // ChatPop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.labelNameAndTime);
            this.Controls.Add(this.panelPop);
            this.Name = "ChatPop";
            this.Size = new System.Drawing.Size(170, 62);
            this.Load += new System.EventHandler(this.ChatPop_Load);
            this.panelPop.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelPop;
        private RichTextBoxEx richTextBoxEx1;
        private System.Windows.Forms.Label labelNameAndTime;
    }
}
