using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace ToolLib
{
    //数据的管理类，一个人或者群的基本信息都缓储存在这里。
    public class DataMgr
    {
        #region 单例
        private static DataMgr instance;
        public static DataMgr Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataMgr();
                }
                return instance;
            }
        }
        #endregion

        #region 属性
        ConcurrentDictionary<string, PersonalInfoModel> personalDic = new ConcurrentDictionary<string, PersonalInfoModel>();
        ConcurrentDictionary<string, GroupInfoModel> groupDic = new ConcurrentDictionary<string, GroupInfoModel>();
        //群资料修改事件
        public delegate void ModifyGroupInfo(int gid);
        public event ModifyGroupInfo modifyGroupInfoEvent;
        //个人资料修改事件
        public delegate void ModifyPersonalInfo(string username);
        public event ModifyPersonalInfo modifyPersonalInfoEvent;
        #endregion


        //异步获取一个人的信息
        public delegate void RequestPersonalInfoEvent(PersonalInfoModel callback);
        public void getPersonalByID(string personalId, RequestPersonalInfoEvent callBack) {
            if (personalDic.ContainsKey(personalId))
            {
                if (callBack != null)
                {
                    callBack(personalDic[personalId]);
                }
            }
            else {//请求这个人的信息，请求完后要更新至字典中。
                HttpReqHelper.requestSync(AppConst.WebUrl + "baseInfo?protocol="+ HttpPersonalProtocol .BASE_INFO+ "&username=" + personalId, delegate (string personalInfo) {
                    try
                    {
                        PersonalInfoModel model = Coding<PersonalInfoModel>.decode(personalInfo);
                        personalDic.TryAdd(personalId,model);
                        if (callBack != null)
                        {
                            callBack(model);
                        }
                    }
                    catch (Exception err)
                    {
                        Debug.Print("DataMgr.getPersonalByID解析失败" + err.ToString());
                        if (callBack != null)
                        {
                            callBack(default(PersonalInfoModel));
                        }
                    }
                });            
            }            
        }



        //异步获取一个群的信息
        public delegate void RequestGroupInfoEvent(GroupInfoModel callback);
        public void getGroupByID(string groupId, RequestGroupInfoEvent callBack)
        {
            if (groupDic.ContainsKey(groupId))
            {
                if (callBack != null)
                {
                    callBack(groupDic[groupId]);
                }
            }
            else
            {//请求这个人的信息，请求完后要更新至字典中。
                HttpReqHelper.requestSync(AppConst.WebUrl + "groupBaseInfo?protocol="+HttpGroupProtocol.GROUP_BASE_INFO+"&gid=" + groupId, delegate (string info) {
                    try
                    {
                     
                        GroupInfoModel model = Coding<GroupInfoModel>.decode(info);
                      //  Debug.Print("收到信息"+ groupId+"  " + model.Name+ model.Master+"|||"+model.Createdtime+model.Verifymode);
                        groupDic.TryAdd(groupId, model);
                        if (callBack != null)
                        {
                            callBack(model);
                        }                       
                    }
                    catch (Exception err)
                    {
                        Debug.Print("!!!DataMgr.getGroupByID解析失败" + err.ToString());
                        if (callBack != null)
                        {
                            callBack(default(GroupInfoModel));
                        }
                    }
                });
            }
        }

        //修改一个人的数据
        public void modifyPersonalInfo(PersonalInfoModel mode)
        {
            if (this.personalDic.ContainsKey(mode.Username))
            {
                this.personalDic[mode.Username] = mode;
                if (modifyPersonalInfoEvent != null)
                {
                    modifyPersonalInfoEvent(mode.Username);
                }
            }
        }

        //修改一个群的数据
        public void modifyGroupInfo(GroupInfoModel mode)
        {
            if (this.groupDic.ContainsKey(mode.Gid.ToString()))
            {
                this.groupDic[mode.Gid.ToString()] = mode;
                if (modifyGroupInfoEvent!=null)
                {
                    modifyGroupInfoEvent(mode.Gid);
                }
            }       
        }
    }
}

