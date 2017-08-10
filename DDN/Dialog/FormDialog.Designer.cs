namespace Dialog
{
    partial class FormDialog
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
            this.buttonSetting = new System.Windows.Forms.Button();
            this.buttonRes = new System.Windows.Forms.Button();
            this.buttonChat = new System.Windows.Forms.Button();
            this.panelChat = new System.Windows.Forms.Panel();
            this.buttonDraw = new System.Windows.Forms.Button();
            this.flowLayoutPanelTop = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSetting
            // 
            this.buttonSetting.Location = new System.Drawing.Point(251, 6);
            this.buttonSetting.Name = "buttonSetting";
            this.buttonSetting.Size = new System.Drawing.Size(75, 23);
            this.buttonSetting.TabIndex = 2;
            this.buttonSetting.Text = "群设置";
            this.buttonSetting.UseVisualStyleBackColor = true;
            // 
            // buttonRes
            // 
            this.buttonRes.Location = new System.Drawing.Point(89, 6);
            this.buttonRes.Name = "buttonRes";
            this.buttonRes.Size = new System.Drawing.Size(75, 23);
            this.buttonRes.TabIndex = 1;
            this.buttonRes.Text = "资源";
            this.buttonRes.UseVisualStyleBackColor = true;
            this.buttonRes.Click += new System.EventHandler(this.buttonRes_Click);
            // 
            // buttonChat
            // 
            this.buttonChat.Location = new System.Drawing.Point(8, 6);
            this.buttonChat.Name = "buttonChat";
            this.buttonChat.Size = new System.Drawing.Size(75, 23);
            this.buttonChat.TabIndex = 0;
            this.buttonChat.Text = "聊天";
            this.buttonChat.UseVisualStyleBackColor = true;
            this.buttonChat.Click += new System.EventHandler(this.buttonChat_Click);
            // 
            // panelChat
            // 
            this.panelChat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelChat.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelChat.Location = new System.Drawing.Point(0, 35);
            this.panelChat.Name = "panelChat";
            this.panelChat.Size = new System.Drawing.Size(701, 566);
            this.panelChat.TabIndex = 5;
            // 
            // buttonDraw
            // 
            this.buttonDraw.Location = new System.Drawing.Point(170, 6);
            this.buttonDraw.Name = "buttonDraw";
            this.buttonDraw.Size = new System.Drawing.Size(75, 23);
            this.buttonDraw.TabIndex = 3;
            this.buttonDraw.Text = "绘制户型";
            this.buttonDraw.UseVisualStyleBackColor = true;
            this.buttonDraw.Click += new System.EventHandler(this.buttonDraw_Click);
            // 
            // flowLayoutPanelTop
            // 
            this.flowLayoutPanelTop.Controls.Add(this.buttonChat);
            this.flowLayoutPanelTop.Controls.Add(this.buttonRes);
            this.flowLayoutPanelTop.Controls.Add(this.buttonDraw);
            this.flowLayoutPanelTop.Controls.Add(this.buttonSetting);
            this.flowLayoutPanelTop.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelTop.Name = "flowLayoutPanelTop";
            this.flowLayoutPanelTop.Padding = new System.Windows.Forms.Padding(5, 3, 0, 0);
            this.flowLayoutPanelTop.Size = new System.Drawing.Size(338, 35);
            this.flowLayoutPanelTop.TabIndex = 0;
            // 
            // FormDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(700, 600);
            this.Controls.Add(this.flowLayoutPanelTop);
            this.Controls.Add(this.panelChat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormDialog";
            this.ShowInTaskbar = false;
            this.Text = "FormDialog";
            this.Load += new System.EventHandler(this.FormDialog_Load);
            this.VisibleChanged += new System.EventHandler(this.FormDialog_VisibleChanged);
            this.flowLayoutPanelTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonRes;
        private System.Windows.Forms.Button buttonChat;
        private System.Windows.Forms.Panel panelChat;
        private System.Windows.Forms.Button buttonSetting;
        private System.Windows.Forms.Button buttonDraw;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelTop;
    }
}