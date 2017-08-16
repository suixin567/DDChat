﻿using MainProgram.UserControls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProgram
{
    //验证消息的数据结构，比普通的消息结构多了一个是否已处理的bool标志位
    public class VerifyMsgModel
    {
        public int MsgType;
        public string From;
        public string To;
        public string Content;
        public string Time;
        public bool IsDealed;

        public VerifyMsgModel() { }

        public VerifyMsgModel(int type, string from, string to, string content, string time, bool isDealed)
        {
            this.MsgType = type;
            this.From = from;
            this.To = to;
            this.Content = content;
            this.Time = time;
            this.IsDealed = isDealed;
        }
        public VerifyMsgModel(MsgModel mm)
        {
            this.MsgType = mm.MsgType;
            this.From = mm.From;
            this.To = mm.To;
            this.Content = mm.Content;
            this.Time = mm.Time;
            this.IsDealed = false;
        }
    }

    class VerifyMsgMgr
    {
        #region 单利
        private static VerifyMsgMgr instance;
        public static VerifyMsgMgr Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new VerifyMsgMgr();
                }
                return instance;
            }
        }
        #endregion

        #region 属性
        public VerifyMsgItem verifyMsgItem = null;
        public FormMessageVerify formMessageVerify;//消息管理窗体
        //验证信息列表
        public List<VerifyMsgModel> vmList = new List<VerifyMsgModel>();
        #endregion


        //添加一条验证信息到列表
        public void addOneVerifyMsg(MsgModel mm)
        {
            this.vmList.Add(new VerifyMsgModel(mm));
            //if (verifyMsgItem!=null)
            //{
            //    verifyMsgItem.setContentSafePost(mm.From +":"+ mm.Content);
            //}
        }

        //标记一条申请加我好友的信息为已经被处理  
        public void markProcessed(MsgModel mode) {
            foreach (var item in vmList)
            {
                Debug.Print(item.MsgType + item.From+ item.To+ item.Time);
                Debug.Print(mode.MsgType + mode.From + mode.To + mode.Time);
                if (item.MsgType == MsgProtocol.ONE_ADD_YOU_SRES)
                {
                    if (item.From == mode.To && item.To == mode.From)
                    {
                        item.IsDealed = true;
                    }
                }               
            }
            foreach (var item in formMessageVerify.flowLayoutPanel.Controls)
            {
                MsgVerifyItem mvi =(MsgVerifyItem)item;
                if (mvi.m_MsgModel.MsgType == MsgProtocol.ONE_ADD_YOU_SRES)
                {
                    if (mvi.m_MsgModel.From == mode.To && mvi.m_MsgModel.To == mode.From)
                    {
                        mvi.setProcessedSafePost();
                    }
                }
            }
        }

        //打开验证消息窗体
        public void openFormMesageVerify()
        {
            if (formMessageVerify == null)
            {
                formMessageVerify = new FormMessageVerify();
                formMessageVerify.Show();
            }
            else
            {
                if (formMessageVerify.IsDisposed)
                {
                    formMessageVerify = new FormMessageVerify();
                    formMessageVerify.Show();
                }
            }
            formMessageVerify.Activate();
        }
    }
}