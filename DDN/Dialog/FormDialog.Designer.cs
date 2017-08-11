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
            this.panelChat = new System.Windows.Forms.Panel();
            this.flowLayoutPanelTop = new System.Windows.Forms.FlowLayoutPanel();
            this.labelChat = new System.Windows.Forms.Label();
            this.labelRes = new System.Windows.Forms.Label();
            this.labelDraw = new System.Windows.Forms.Label();
            this.flowLayoutPanelTop.SuspendLayout();
            this.SuspendLayout();
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
            // flowLayoutPanelTop
            // 
            this.flowLayoutPanelTop.Controls.Add(this.labelChat);
            this.flowLayoutPanelTop.Controls.Add(this.labelRes);
            this.flowLayoutPanelTop.Controls.Add(this.labelDraw);
            this.flowLayoutPanelTop.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelTop.Name = "flowLayoutPanelTop";
            this.flowLayoutPanelTop.Padding = new System.Windows.Forms.Padding(5, 3, 0, 0);
            this.flowLayoutPanelTop.Size = new System.Drawing.Size(253, 35);
            this.flowLayoutPanelTop.TabIndex = 0;
            // 
            // labelChat
            // 
            this.labelChat.BackColor = System.Drawing.SystemColors.Control;
            this.labelChat.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelChat.Location = new System.Drawing.Point(8, 3);
            this.labelChat.Margin = new System.Windows.Forms.Padding(3, 0, 20, 0);
            this.labelChat.Name = "labelChat";
            this.labelChat.Size = new System.Drawing.Size(52, 29);
            this.labelChat.TabIndex = 0;
            this.labelChat.Text = "聊天";
            this.labelChat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelChat.Click += new System.EventHandler(this.labelChat_Click);
            // 
            // labelRes
            // 
            this.labelRes.BackColor = System.Drawing.SystemColors.Control;
            this.labelRes.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelRes.Location = new System.Drawing.Point(83, 3);
            this.labelRes.Margin = new System.Windows.Forms.Padding(3, 0, 20, 0);
            this.labelRes.Name = "labelRes";
            this.labelRes.Size = new System.Drawing.Size(52, 29);
            this.labelRes.TabIndex = 1;
            this.labelRes.Text = "资源";
            this.labelRes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelRes.Click += new System.EventHandler(this.labelRes_Click);
            // 
            // labelDraw
            // 
            this.labelDraw.BackColor = System.Drawing.SystemColors.Control;
            this.labelDraw.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelDraw.Location = new System.Drawing.Point(158, 3);
            this.labelDraw.Margin = new System.Windows.Forms.Padding(3, 0, 20, 0);
            this.labelDraw.Name = "labelDraw";
            this.labelDraw.Size = new System.Drawing.Size(75, 29);
            this.labelDraw.TabIndex = 2;
            this.labelDraw.Text = "绘制户型";
            this.labelDraw.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelDraw.Click += new System.EventHandler(this.labelDraw_Click);
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
        private System.Windows.Forms.Panel panelChat;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelTop;
        private System.Windows.Forms.Label labelChat;
        private System.Windows.Forms.Label labelRes;
        private System.Windows.Forms.Label labelDraw;
    }
}