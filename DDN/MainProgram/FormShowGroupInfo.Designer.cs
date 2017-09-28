﻿namespace MainProgram
{
    partial class FormShowGroupInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormShowGroupInfo));
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonMin = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelAcc = new System.Windows.Forms.Label();
            this.labelUsername = new System.Windows.Forms.Label();
            this.labelDescription = new System.Windows.Forms.Label();
            this.pictureBoxFace = new System.Windows.Forms.PictureBox();
            this.labelNickName = new System.Windows.Forms.Label();
            this.labelModify = new System.Windows.Forms.Label();
            this.labelChangeFace = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.info = new System.Windows.Forms.TabPage();
            this.labelCreatedtime = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.member = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.setting = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkBoxVerifymode2 = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonOpenDialogue = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.labelMemberAmount = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBoxMasterFace = new System.Windows.Forms.PictureBox();
            this.labelMaster = new System.Windows.Forms.Label();
            this.labelVerifymode = new System.Windows.Forms.Label();
            this.checkBoxVerifymode1 = new System.Windows.Forms.CheckBox();
            this.groupManageMemberItem1 = new MainProgram.UserControls.GroupManageMemberItem();
            this.groupManageMemberItem2 = new MainProgram.UserControls.GroupManageMemberItem();
            this.groupManageMemberItem3 = new MainProgram.UserControls.GroupManageMemberItem();
            this.groupManageMemberItem4 = new MainProgram.UserControls.GroupManageMemberItem();
            this.groupManageMemberItem5 = new MainProgram.UserControls.GroupManageMemberItem();
            this.groupManageMemberItem6 = new MainProgram.UserControls.GroupManageMemberItem();
            this.groupManageMemberItem7 = new MainProgram.UserControls.GroupManageMemberItem();
            this.groupManageMemberItem11 = new MainProgram.UserControls.GroupManageMemberItem();
            this.groupManageMemberItem12 = new MainProgram.UserControls.GroupManageMemberItem();
            this.groupManageMemberItem13 = new MainProgram.UserControls.GroupManageMemberItem();
            this.groupManageMemberItem14 = new MainProgram.UserControls.GroupManageMemberItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFace)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.info.SuspendLayout();
            this.member.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.setting.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMasterFace)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonClose.Location = new System.Drawing.Point(670, 0);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(30, 30);
            this.buttonClose.TabIndex = 0;
            this.buttonClose.Text = "×";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonMin
            // 
            this.buttonMin.FlatAppearance.BorderSize = 0;
            this.buttonMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMin.Location = new System.Drawing.Point(640, 0);
            this.buttonMin.Name = "buttonMin";
            this.buttonMin.Size = new System.Drawing.Size(30, 30);
            this.buttonMin.TabIndex = 1;
            this.buttonMin.Text = "-";
            this.buttonMin.UseVisualStyleBackColor = true;
            this.buttonMin.Click += new System.EventHandler(this.buttonMin_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(253, 520);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormModifyPersonalInfo_MouseDown);
            // 
            // labelAcc
            // 
            this.labelAcc.AutoSize = true;
            this.labelAcc.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelAcc.Location = new System.Drawing.Point(26, 143);
            this.labelAcc.Name = "labelAcc";
            this.labelAcc.Size = new System.Drawing.Size(41, 12);
            this.labelAcc.TabIndex = 3;
            this.labelAcc.Text = "群号：";
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelUsername.Location = new System.Drawing.Point(73, 143);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(29, 12);
            this.labelUsername.TabIndex = 4;
            this.labelUsername.Text = "0000";
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelDescription.Location = new System.Drawing.Point(26, 251);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(53, 12);
            this.labelDescription.TabIndex = 5;
            this.labelDescription.Text = "群介绍：";
            // 
            // pictureBoxFace
            // 
            this.pictureBoxFace.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxFace.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxFace.Image")));
            this.pictureBoxFace.Location = new System.Drawing.Point(22, 24);
            this.pictureBoxFace.Name = "pictureBoxFace";
            this.pictureBoxFace.Size = new System.Drawing.Size(70, 70);
            this.pictureBoxFace.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxFace.TabIndex = 7;
            this.pictureBoxFace.TabStop = false;
            this.pictureBoxFace.Click += new System.EventHandler(this.pictureBoxFace_Click);
            // 
            // labelNickName
            // 
            this.labelNickName.AutoSize = true;
            this.labelNickName.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelNickName.Location = new System.Drawing.Point(108, 50);
            this.labelNickName.Name = "labelNickName";
            this.labelNickName.Size = new System.Drawing.Size(66, 19);
            this.labelNickName.TabIndex = 8;
            this.labelNickName.Text = "群名称";
            // 
            // labelModify
            // 
            this.labelModify.AutoSize = true;
            this.labelModify.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelModify.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelModify.ForeColor = System.Drawing.Color.SteelBlue;
            this.labelModify.Location = new System.Drawing.Point(347, 24);
            this.labelModify.Name = "labelModify";
            this.labelModify.Size = new System.Drawing.Size(77, 14);
            this.labelModify.TabIndex = 9;
            this.labelModify.Text = "编辑群资料";
            this.labelModify.Click += new System.EventHandler(this.labelModify_Click);
            // 
            // labelChangeFace
            // 
            this.labelChangeFace.AutoSize = true;
            this.labelChangeFace.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelChangeFace.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelChangeFace.ForeColor = System.Drawing.Color.SteelBlue;
            this.labelChangeFace.Location = new System.Drawing.Point(20, 97);
            this.labelChangeFace.Name = "labelChangeFace";
            this.labelChangeFace.Size = new System.Drawing.Size(89, 12);
            this.labelChangeFace.TabIndex = 10;
            this.labelChangeFace.Text = "点击更换群头像";
            this.labelChangeFace.Click += new System.EventHandler(this.labelChangeFace_Click);
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxDescription.Location = new System.Drawing.Point(6, 273);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.ReadOnly = true;
            this.textBoxDescription.Size = new System.Drawing.Size(422, 186);
            this.textBoxDescription.TabIndex = 11;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.info);
            this.tabControl1.Controls.Add(this.member);
            this.tabControl1.Controls.Add(this.setting);
            this.tabControl1.Location = new System.Drawing.Point(257, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(443, 493);
            this.tabControl1.TabIndex = 12;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // info
            // 
            this.info.BackColor = System.Drawing.Color.LightBlue;
            this.info.Controls.Add(this.labelMaster);
            this.info.Controls.Add(this.pictureBoxMasterFace);
            this.info.Controls.Add(this.label8);
            this.info.Controls.Add(this.labelMemberAmount);
            this.info.Controls.Add(this.label7);
            this.info.Controls.Add(this.labelCreatedtime);
            this.info.Controls.Add(this.label6);
            this.info.Controls.Add(this.pictureBoxFace);
            this.info.Controls.Add(this.textBoxDescription);
            this.info.Controls.Add(this.labelAcc);
            this.info.Controls.Add(this.labelChangeFace);
            this.info.Controls.Add(this.labelUsername);
            this.info.Controls.Add(this.labelModify);
            this.info.Controls.Add(this.labelDescription);
            this.info.Controls.Add(this.labelNickName);
            this.info.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.info.Location = new System.Drawing.Point(4, 22);
            this.info.Name = "info";
            this.info.Padding = new System.Windows.Forms.Padding(3);
            this.info.Size = new System.Drawing.Size(435, 467);
            this.info.TabIndex = 0;
            this.info.Text = "资料";
            // 
            // labelCreatedtime
            // 
            this.labelCreatedtime.AutoSize = true;
            this.labelCreatedtime.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelCreatedtime.Location = new System.Drawing.Point(97, 227);
            this.labelCreatedtime.Name = "labelCreatedtime";
            this.labelCreatedtime.Size = new System.Drawing.Size(53, 12);
            this.labelCreatedtime.TabIndex = 13;
            this.labelCreatedtime.Text = "00-00-00";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(26, 227);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "创建时间：";
            // 
            // member
            // 
            this.member.BackColor = System.Drawing.SystemColors.Control;
            this.member.Controls.Add(this.button1);
            this.member.Controls.Add(this.flowLayoutPanel1);
            this.member.Controls.Add(this.panel1);
            this.member.Controls.Add(this.label1);
            this.member.Location = new System.Drawing.Point(4, 22);
            this.member.Name = "member";
            this.member.Padding = new System.Windows.Forms.Padding(3);
            this.member.Size = new System.Drawing.Size(435, 467);
            this.member.TabIndex = 1;
            this.member.Text = "成员";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightBlue;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Location = new System.Drawing.Point(333, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "邀请新成员";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.groupManageMemberItem1);
            this.flowLayoutPanel1.Controls.Add(this.groupManageMemberItem2);
            this.flowLayoutPanel1.Controls.Add(this.groupManageMemberItem3);
            this.flowLayoutPanel1.Controls.Add(this.groupManageMemberItem4);
            this.flowLayoutPanel1.Controls.Add(this.groupManageMemberItem5);
            this.flowLayoutPanel1.Controls.Add(this.groupManageMemberItem6);
            this.flowLayoutPanel1.Controls.Add(this.groupManageMemberItem7);
            this.flowLayoutPanel1.Controls.Add(this.groupManageMemberItem11);
            this.flowLayoutPanel1.Controls.Add(this.groupManageMemberItem12);
            this.flowLayoutPanel1.Controls.Add(this.groupManageMemberItem13);
            this.flowLayoutPanel1.Controls.Add(this.groupManageMemberItem14);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(8, 61);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(419, 398);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightBlue;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(8, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 26);
            this.panel1.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(253, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "操作";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(138, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "最后发言";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "成员";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "群成员 0/200";
            // 
            // setting
            // 
            this.setting.BackColor = System.Drawing.SystemColors.Control;
            this.setting.Controls.Add(this.panel2);
            this.setting.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.setting.Location = new System.Drawing.Point(4, 22);
            this.setting.Name = "setting";
            this.setting.Size = new System.Drawing.Size(435, 467);
            this.setting.TabIndex = 2;
            this.setting.Text = "设置";
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BackColor = System.Drawing.Color.LightBlue;
            this.panel2.Controls.Add(this.checkBoxVerifymode1);
            this.panel2.Controls.Add(this.labelVerifymode);
            this.panel2.Controls.Add(this.checkBoxVerifymode2);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(11, 11);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(413, 446);
            this.panel2.TabIndex = 0;
            // 
            // checkBoxVerifymode2
            // 
            this.checkBoxVerifymode2.AutoSize = true;
            this.checkBoxVerifymode2.Location = new System.Drawing.Point(71, 40);
            this.checkBoxVerifymode2.Name = "checkBoxVerifymode2";
            this.checkBoxVerifymode2.Size = new System.Drawing.Size(96, 16);
            this.checkBoxVerifymode2.TabIndex = 2;
            this.checkBoxVerifymode2.Text = "需要群主验证";
            this.checkBoxVerifymode2.UseVisualStyleBackColor = true;
            this.checkBoxVerifymode2.Click += new System.EventHandler(this.checkBoxVerifymode2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "加群方式：";
            // 
            // buttonOpenDialogue
            // 
            this.buttonOpenDialogue.Location = new System.Drawing.Point(70, 392);
            this.buttonOpenDialogue.Name = "buttonOpenDialogue";
            this.buttonOpenDialogue.Size = new System.Drawing.Size(119, 32);
            this.buttonOpenDialogue.TabIndex = 14;
            this.buttonOpenDialogue.Text = "发消息";
            this.buttonOpenDialogue.UseVisualStyleBackColor = true;
            this.buttonOpenDialogue.Click += new System.EventHandler(this.buttonOpenDialogue_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(26, 203);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 14;
            this.label7.Text = "成员数：";
            // 
            // labelMemberAmount
            // 
            this.labelMemberAmount.AutoSize = true;
            this.labelMemberAmount.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelMemberAmount.Location = new System.Drawing.Point(73, 203);
            this.labelMemberAmount.Name = "labelMemberAmount";
            this.labelMemberAmount.Size = new System.Drawing.Size(11, 12);
            this.labelMemberAmount.TabIndex = 15;
            this.labelMemberAmount.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(27, 173);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 16;
            this.label8.Text = "群主：";
            // 
            // pictureBoxMasterFace
            // 
            this.pictureBoxMasterFace.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxMasterFace.Image")));
            this.pictureBoxMasterFace.Location = new System.Drawing.Point(70, 164);
            this.pictureBoxMasterFace.Name = "pictureBoxMasterFace";
            this.pictureBoxMasterFace.Size = new System.Drawing.Size(30, 30);
            this.pictureBoxMasterFace.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxMasterFace.TabIndex = 17;
            this.pictureBoxMasterFace.TabStop = false;
            // 
            // labelMaster
            // 
            this.labelMaster.AutoSize = true;
            this.labelMaster.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelMaster.Location = new System.Drawing.Point(106, 173);
            this.labelMaster.Name = "labelMaster";
            this.labelMaster.Size = new System.Drawing.Size(23, 12);
            this.labelMaster.TabIndex = 18;
            this.labelMaster.Text = "...";
            // 
            // labelVerifymode
            // 
            this.labelVerifymode.AutoSize = true;
            this.labelVerifymode.Location = new System.Drawing.Point(196, 19);
            this.labelVerifymode.Name = "labelVerifymode";
            this.labelVerifymode.Size = new System.Drawing.Size(89, 12);
            this.labelVerifymode.TabIndex = 3;
            this.labelVerifymode.Text = "允许任何人加入";
            // 
            // checkBoxVerifymode1
            // 
            this.checkBoxVerifymode1.AutoSize = true;
            this.checkBoxVerifymode1.Location = new System.Drawing.Point(71, 18);
            this.checkBoxVerifymode1.Name = "checkBoxVerifymode1";
            this.checkBoxVerifymode1.Size = new System.Drawing.Size(108, 16);
            this.checkBoxVerifymode1.TabIndex = 4;
            this.checkBoxVerifymode1.Text = "允许任何人加入";
            this.checkBoxVerifymode1.UseVisualStyleBackColor = true;
            this.checkBoxVerifymode1.Click += new System.EventHandler(this.checkBoxVerifymode1_Click);
            // 
            // groupManageMemberItem1
            // 
            this.groupManageMemberItem1.BackColor = System.Drawing.Color.LightBlue;
            this.groupManageMemberItem1.Location = new System.Drawing.Point(0, 0);
            this.groupManageMemberItem1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.groupManageMemberItem1.Name = "groupManageMemberItem1";
            this.groupManageMemberItem1.Size = new System.Drawing.Size(400, 30);
            this.groupManageMemberItem1.TabIndex = 0;
            // 
            // groupManageMemberItem2
            // 
            this.groupManageMemberItem2.BackColor = System.Drawing.Color.LightBlue;
            this.groupManageMemberItem2.Location = new System.Drawing.Point(0, 32);
            this.groupManageMemberItem2.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.groupManageMemberItem2.Name = "groupManageMemberItem2";
            this.groupManageMemberItem2.Size = new System.Drawing.Size(400, 30);
            this.groupManageMemberItem2.TabIndex = 1;
            // 
            // groupManageMemberItem3
            // 
            this.groupManageMemberItem3.BackColor = System.Drawing.Color.LightBlue;
            this.groupManageMemberItem3.Location = new System.Drawing.Point(0, 64);
            this.groupManageMemberItem3.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.groupManageMemberItem3.Name = "groupManageMemberItem3";
            this.groupManageMemberItem3.Size = new System.Drawing.Size(400, 30);
            this.groupManageMemberItem3.TabIndex = 2;
            // 
            // groupManageMemberItem4
            // 
            this.groupManageMemberItem4.BackColor = System.Drawing.Color.LightBlue;
            this.groupManageMemberItem4.Location = new System.Drawing.Point(0, 96);
            this.groupManageMemberItem4.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.groupManageMemberItem4.Name = "groupManageMemberItem4";
            this.groupManageMemberItem4.Size = new System.Drawing.Size(400, 30);
            this.groupManageMemberItem4.TabIndex = 3;
            // 
            // groupManageMemberItem5
            // 
            this.groupManageMemberItem5.BackColor = System.Drawing.Color.LightBlue;
            this.groupManageMemberItem5.Location = new System.Drawing.Point(0, 128);
            this.groupManageMemberItem5.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.groupManageMemberItem5.Name = "groupManageMemberItem5";
            this.groupManageMemberItem5.Size = new System.Drawing.Size(400, 30);
            this.groupManageMemberItem5.TabIndex = 4;
            // 
            // groupManageMemberItem6
            // 
            this.groupManageMemberItem6.BackColor = System.Drawing.Color.LightBlue;
            this.groupManageMemberItem6.Location = new System.Drawing.Point(0, 160);
            this.groupManageMemberItem6.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.groupManageMemberItem6.Name = "groupManageMemberItem6";
            this.groupManageMemberItem6.Size = new System.Drawing.Size(400, 30);
            this.groupManageMemberItem6.TabIndex = 5;
            // 
            // groupManageMemberItem7
            // 
            this.groupManageMemberItem7.BackColor = System.Drawing.Color.LightBlue;
            this.groupManageMemberItem7.Location = new System.Drawing.Point(0, 192);
            this.groupManageMemberItem7.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.groupManageMemberItem7.Name = "groupManageMemberItem7";
            this.groupManageMemberItem7.Size = new System.Drawing.Size(400, 30);
            this.groupManageMemberItem7.TabIndex = 6;
            // 
            // groupManageMemberItem11
            // 
            this.groupManageMemberItem11.BackColor = System.Drawing.Color.LightBlue;
            this.groupManageMemberItem11.Location = new System.Drawing.Point(0, 224);
            this.groupManageMemberItem11.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.groupManageMemberItem11.Name = "groupManageMemberItem11";
            this.groupManageMemberItem11.Size = new System.Drawing.Size(400, 30);
            this.groupManageMemberItem11.TabIndex = 10;
            // 
            // groupManageMemberItem12
            // 
            this.groupManageMemberItem12.BackColor = System.Drawing.Color.LightBlue;
            this.groupManageMemberItem12.Location = new System.Drawing.Point(0, 256);
            this.groupManageMemberItem12.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.groupManageMemberItem12.Name = "groupManageMemberItem12";
            this.groupManageMemberItem12.Size = new System.Drawing.Size(400, 30);
            this.groupManageMemberItem12.TabIndex = 11;
            // 
            // groupManageMemberItem13
            // 
            this.groupManageMemberItem13.BackColor = System.Drawing.Color.LightBlue;
            this.groupManageMemberItem13.Location = new System.Drawing.Point(0, 288);
            this.groupManageMemberItem13.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.groupManageMemberItem13.Name = "groupManageMemberItem13";
            this.groupManageMemberItem13.Size = new System.Drawing.Size(400, 30);
            this.groupManageMemberItem13.TabIndex = 12;
            // 
            // groupManageMemberItem14
            // 
            this.groupManageMemberItem14.BackColor = System.Drawing.Color.LightBlue;
            this.groupManageMemberItem14.Location = new System.Drawing.Point(0, 320);
            this.groupManageMemberItem14.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.groupManageMemberItem14.Name = "groupManageMemberItem14";
            this.groupManageMemberItem14.Size = new System.Drawing.Size(400, 30);
            this.groupManageMemberItem14.TabIndex = 13;
            // 
            // FormShowGroupInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 520);
            this.Controls.Add(this.buttonOpenDialogue);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonMin);
            this.Controls.Add(this.buttonClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormShowGroupInfo";
            this.Text = "FormModifyPersonalInfo";
            this.Load += new System.EventHandler(this.FormModifyPersonalInfo_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormModifyPersonalInfo_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFace)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.info.ResumeLayout(false);
            this.info.PerformLayout();
            this.member.ResumeLayout(false);
            this.member.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.setting.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMasterFace)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonMin;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelAcc;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.PictureBox pictureBoxFace;
        private System.Windows.Forms.Label labelNickName;
        private System.Windows.Forms.Label labelModify;
        private System.Windows.Forms.Label labelChangeFace;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage info;
        private System.Windows.Forms.TabPage member;
        private System.Windows.Forms.TabPage setting;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBoxVerifymode2;
        private System.Windows.Forms.Button buttonOpenDialogue;
        private System.Windows.Forms.Label labelCreatedtime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private UserControls.GroupManageMemberItem groupManageMemberItem1;
        private UserControls.GroupManageMemberItem groupManageMemberItem2;
        private UserControls.GroupManageMemberItem groupManageMemberItem3;
        private UserControls.GroupManageMemberItem groupManageMemberItem4;
        private UserControls.GroupManageMemberItem groupManageMemberItem5;
        private UserControls.GroupManageMemberItem groupManageMemberItem6;
        private UserControls.GroupManageMemberItem groupManageMemberItem7;
        private UserControls.GroupManageMemberItem groupManageMemberItem11;
        private UserControls.GroupManageMemberItem groupManageMemberItem12;
        private UserControls.GroupManageMemberItem groupManageMemberItem13;
        private UserControls.GroupManageMemberItem groupManageMemberItem14;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelMemberAmount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelMaster;
        private System.Windows.Forms.PictureBox pictureBoxMasterFace;
        private System.Windows.Forms.Label labelVerifymode;
        private System.Windows.Forms.CheckBox checkBoxVerifymode1;
    }
}