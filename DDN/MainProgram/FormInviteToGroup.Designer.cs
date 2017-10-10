namespace MainProgram
{
    partial class FormInviteToGroup
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.buttonYes = new System.Windows.Forms.Button();
            this.buttonNo = new System.Windows.Forms.Button();
            this.flowLayoutPanelFriends = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanelSelected = new System.Windows.Forms.FlowLayoutPanel();
            this.labelTip = new System.Windows.Forms.Label();
            this.timerOpreationResult = new System.Windows.Forms.Timer(this.components);
            this.inviteItem1 = new MainProgram.UserControls.InviteItem();
            this.inviteItem2 = new MainProgram.UserControls.InviteItem();
            this.inviteItem3 = new MainProgram.UserControls.InviteItem();
            this.inviteItem4 = new MainProgram.UserControls.InviteItem();
            this.inviteItem5 = new MainProgram.UserControls.InviteItem();
            this.inviteItem6 = new MainProgram.UserControls.InviteItem();
            this.inviteItem7 = new MainProgram.UserControls.InviteItem();
            this.inviteItem8 = new MainProgram.UserControls.InviteItem();
            this.inviteItem9 = new MainProgram.UserControls.InviteItem();
            this.inviteItem10 = new MainProgram.UserControls.InviteItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.flowLayoutPanelFriends.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.SteelBlue;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(503, 30);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormInviteToGroup_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(7, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "邀请好友加群";
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonClose.ForeColor = System.Drawing.Color.White;
            this.buttonClose.Location = new System.Drawing.Point(470, 0);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(30, 30);
            this.buttonClose.TabIndex = 2;
            this.buttonClose.Text = "×";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "请选择好友";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(281, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "已选联系人:";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Gainsboro;
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pictureBox2.Location = new System.Drawing.Point(0, 370);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(500, 30);
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormInviteToGroup_MouseDown);
            // 
            // buttonYes
            // 
            this.buttonYes.BackColor = System.Drawing.Color.White;
            this.buttonYes.Enabled = false;
            this.buttonYes.Location = new System.Drawing.Point(341, 372);
            this.buttonYes.Name = "buttonYes";
            this.buttonYes.Size = new System.Drawing.Size(66, 25);
            this.buttonYes.TabIndex = 6;
            this.buttonYes.Text = "确定";
            this.buttonYes.UseVisualStyleBackColor = false;
            this.buttonYes.Click += new System.EventHandler(this.buttonYes_Click);
            // 
            // buttonNo
            // 
            this.buttonNo.BackColor = System.Drawing.Color.White;
            this.buttonNo.Location = new System.Drawing.Point(422, 372);
            this.buttonNo.Name = "buttonNo";
            this.buttonNo.Size = new System.Drawing.Size(66, 25);
            this.buttonNo.TabIndex = 7;
            this.buttonNo.Text = "取消";
            this.buttonNo.UseVisualStyleBackColor = false;
            this.buttonNo.Click += new System.EventHandler(this.buttonNo_Click);
            // 
            // flowLayoutPanelFriends
            // 
            this.flowLayoutPanelFriends.AutoScroll = true;
            this.flowLayoutPanelFriends.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.flowLayoutPanelFriends.Controls.Add(this.inviteItem1);
            this.flowLayoutPanelFriends.Controls.Add(this.inviteItem2);
            this.flowLayoutPanelFriends.Controls.Add(this.inviteItem3);
            this.flowLayoutPanelFriends.Controls.Add(this.inviteItem4);
            this.flowLayoutPanelFriends.Controls.Add(this.inviteItem5);
            this.flowLayoutPanelFriends.Controls.Add(this.inviteItem6);
            this.flowLayoutPanelFriends.Controls.Add(this.inviteItem7);
            this.flowLayoutPanelFriends.Controls.Add(this.inviteItem8);
            this.flowLayoutPanelFriends.Controls.Add(this.inviteItem9);
            this.flowLayoutPanelFriends.Controls.Add(this.inviteItem10);
            this.flowLayoutPanelFriends.Location = new System.Drawing.Point(15, 64);
            this.flowLayoutPanelFriends.Name = "flowLayoutPanelFriends";
            this.flowLayoutPanelFriends.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.flowLayoutPanelFriends.Size = new System.Drawing.Size(200, 300);
            this.flowLayoutPanelFriends.TabIndex = 8;
            // 
            // flowLayoutPanelSelected
            // 
            this.flowLayoutPanelSelected.AutoScroll = true;
            this.flowLayoutPanelSelected.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.flowLayoutPanelSelected.Location = new System.Drawing.Point(283, 64);
            this.flowLayoutPanelSelected.Name = "flowLayoutPanelSelected";
            this.flowLayoutPanelSelected.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.flowLayoutPanelSelected.Size = new System.Drawing.Size(200, 300);
            this.flowLayoutPanelSelected.TabIndex = 9;
            this.flowLayoutPanelSelected.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.flowLayoutPanelSelected_ControlAdded);
            this.flowLayoutPanelSelected.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.flowLayoutPanelSelected_ControlRemoved);
            // 
            // labelTip
            // 
            this.labelTip.AutoSize = true;
            this.labelTip.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTip.ForeColor = System.Drawing.Color.Red;
            this.labelTip.Location = new System.Drawing.Point(77, 46);
            this.labelTip.Name = "labelTip";
            this.labelTip.Size = new System.Drawing.Size(122, 12);
            this.labelTip.TabIndex = 10;
            this.labelTip.Text = "此好友已经是群成员";
            // 
            // timerOpreationResult
            // 
            this.timerOpreationResult.Enabled = true;
            this.timerOpreationResult.Interval = 1000;
            this.timerOpreationResult.Tick += new System.EventHandler(this.timerOpreationResult_Tick);
            // 
            // inviteItem1
            // 
            this.inviteItem1.BackColor = System.Drawing.Color.White;
            this.inviteItem1.Location = new System.Drawing.Point(3, 3);
            this.inviteItem1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.inviteItem1.Name = "inviteItem1";
            this.inviteItem1.Size = new System.Drawing.Size(170, 30);
            this.inviteItem1.TabIndex = 0;
            // 
            // inviteItem2
            // 
            this.inviteItem2.BackColor = System.Drawing.Color.White;
            this.inviteItem2.Location = new System.Drawing.Point(3, 36);
            this.inviteItem2.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.inviteItem2.Name = "inviteItem2";
            this.inviteItem2.Size = new System.Drawing.Size(170, 30);
            this.inviteItem2.TabIndex = 1;
            // 
            // inviteItem3
            // 
            this.inviteItem3.BackColor = System.Drawing.Color.White;
            this.inviteItem3.Location = new System.Drawing.Point(3, 69);
            this.inviteItem3.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.inviteItem3.Name = "inviteItem3";
            this.inviteItem3.Size = new System.Drawing.Size(170, 30);
            this.inviteItem3.TabIndex = 2;
            // 
            // inviteItem4
            // 
            this.inviteItem4.BackColor = System.Drawing.Color.White;
            this.inviteItem4.Location = new System.Drawing.Point(3, 102);
            this.inviteItem4.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.inviteItem4.Name = "inviteItem4";
            this.inviteItem4.Size = new System.Drawing.Size(170, 30);
            this.inviteItem4.TabIndex = 3;
            // 
            // inviteItem5
            // 
            this.inviteItem5.BackColor = System.Drawing.Color.White;
            this.inviteItem5.Location = new System.Drawing.Point(3, 135);
            this.inviteItem5.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.inviteItem5.Name = "inviteItem5";
            this.inviteItem5.Size = new System.Drawing.Size(170, 30);
            this.inviteItem5.TabIndex = 4;
            // 
            // inviteItem6
            // 
            this.inviteItem6.BackColor = System.Drawing.Color.White;
            this.inviteItem6.Location = new System.Drawing.Point(3, 168);
            this.inviteItem6.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.inviteItem6.Name = "inviteItem6";
            this.inviteItem6.Size = new System.Drawing.Size(170, 30);
            this.inviteItem6.TabIndex = 5;
            // 
            // inviteItem7
            // 
            this.inviteItem7.BackColor = System.Drawing.Color.White;
            this.inviteItem7.Location = new System.Drawing.Point(3, 201);
            this.inviteItem7.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.inviteItem7.Name = "inviteItem7";
            this.inviteItem7.Size = new System.Drawing.Size(170, 30);
            this.inviteItem7.TabIndex = 6;
            // 
            // inviteItem8
            // 
            this.inviteItem8.BackColor = System.Drawing.Color.White;
            this.inviteItem8.Location = new System.Drawing.Point(3, 234);
            this.inviteItem8.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.inviteItem8.Name = "inviteItem8";
            this.inviteItem8.Size = new System.Drawing.Size(170, 30);
            this.inviteItem8.TabIndex = 7;
            // 
            // inviteItem9
            // 
            this.inviteItem9.BackColor = System.Drawing.Color.White;
            this.inviteItem9.Location = new System.Drawing.Point(3, 267);
            this.inviteItem9.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.inviteItem9.Name = "inviteItem9";
            this.inviteItem9.Size = new System.Drawing.Size(170, 30);
            this.inviteItem9.TabIndex = 8;
            // 
            // inviteItem10
            // 
            this.inviteItem10.BackColor = System.Drawing.Color.White;
            this.inviteItem10.Location = new System.Drawing.Point(3, 300);
            this.inviteItem10.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.inviteItem10.Name = "inviteItem10";
            this.inviteItem10.Size = new System.Drawing.Size(170, 30);
            this.inviteItem10.TabIndex = 9;
            // 
            // FormInviteToGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 400);
            this.Controls.Add(this.labelTip);
            this.Controls.Add(this.flowLayoutPanelSelected);
            this.Controls.Add(this.flowLayoutPanelFriends);
            this.Controls.Add(this.buttonNo);
            this.Controls.Add(this.buttonYes);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormInviteToGroup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormInviteToGroup";
            this.Load += new System.EventHandler(this.FormInviteToGroup_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormInviteToGroup_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.flowLayoutPanelFriends.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button buttonYes;
        private System.Windows.Forms.Button buttonNo;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelFriends;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelSelected;
        private UserControls.InviteItem inviteItem1;
        private UserControls.InviteItem inviteItem2;
        private UserControls.InviteItem inviteItem3;
        private UserControls.InviteItem inviteItem4;
        private UserControls.InviteItem inviteItem5;
        private UserControls.InviteItem inviteItem6;
        private UserControls.InviteItem inviteItem7;
        private UserControls.InviteItem inviteItem8;
        private UserControls.InviteItem inviteItem9;
        private UserControls.InviteItem inviteItem10;
        private System.Windows.Forms.Label labelTip;
        private System.Windows.Forms.Timer timerOpreationResult;
    }
}