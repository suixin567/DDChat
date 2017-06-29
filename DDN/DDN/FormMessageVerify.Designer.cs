namespace DDN
{
    partial class FormMessageVerify
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMessageVerify));
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.labelMsgAmount = new System.Windows.Forms.Label();
            this.labelOpreationResult = new System.Windows.Forms.Label();
            this.timerOpreationResult = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel.Location = new System.Drawing.Point(3, 37);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.flowLayoutPanel.Size = new System.Drawing.Size(628, 408);
            this.flowLayoutPanel.TabIndex = 1;
            // 
            // labelMsgAmount
            // 
            this.labelMsgAmount.AutoSize = true;
            this.labelMsgAmount.Location = new System.Drawing.Point(4, 13);
            this.labelMsgAmount.Name = "labelMsgAmount";
            this.labelMsgAmount.Size = new System.Drawing.Size(65, 12);
            this.labelMsgAmount.TabIndex = 2;
            this.labelMsgAmount.Text = "消息验证：";
            // 
            // labelOpreationResult
            // 
            this.labelOpreationResult.AutoSize = true;
            this.labelOpreationResult.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelOpreationResult.ForeColor = System.Drawing.Color.Red;
            this.labelOpreationResult.Location = new System.Drawing.Point(130, 13);
            this.labelOpreationResult.Name = "labelOpreationResult";
            this.labelOpreationResult.Size = new System.Drawing.Size(127, 14);
            this.labelOpreationResult.TabIndex = 3;
            this.labelOpreationResult.Text = "这里展示操作结果";
            // 
            // timerOpreationResult
            // 
            this.timerOpreationResult.Enabled = true;
            this.timerOpreationResult.Interval = 1000;
            this.timerOpreationResult.Tick += new System.EventHandler(this.timerOpreationResult_Tick);
            // 
            // FormMessageVerify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 446);
            this.Controls.Add(this.labelOpreationResult);
            this.Controls.Add(this.labelMsgAmount);
            this.Controls.Add(this.flowLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormMessageVerify";
            this.Text = "消息验证";
            this.Load += new System.EventHandler(this.FormMessageVerify_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.Label labelMsgAmount;
        private System.Windows.Forms.Label labelOpreationResult;
        private System.Windows.Forms.Timer timerOpreationResult;
    }
}