﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//个人信息
        public struct PersonalInfoModel
        {
            public string Username;
            public string Nickname;
            public string Face;
            public string Description;

        }
//创建群数据结构
public class CreateGroupModel
{
    public string Groupname;
    public int VerifyModel;
}

//我的群数据结构
public class MyGroupModel {

    public int GroupID;
    public int ReceiveModel;
}
//群信息
public struct GroupInfoModel
{
    public int Gid;
    public string Name;
    public string Face;
    public int Level;
    public string Master;
    public string Manager;
    public string Member;
    public int Verifymode;
    public string Createdtime;

}


public class MsgModel
{
    public int MsgType;
    public string From;
    public string To;
    public string Content;
    public string Time;

    public MsgModel() { }

    public MsgModel(int type, string from, string to, string content, string time)
    {
        this.MsgType = type;
        this.From = from;
        this.To = to;
        this.Content = content;
        this.Time = time;
    }
}
