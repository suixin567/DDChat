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
        ConcurrentDictionary<int, GroupInfoModel> groupDic = new ConcurrentDictionary<int, GroupInfoModel>();
        List<int> invalidGroup = new List<int>();//无效的群信息
        //群资料已过时事件
        public delegate void DeprecatedGroupInfo(int gid);
        public event DeprecatedGroupInfo deprecatedGroupInfoEvent;
        //群资料已更新事件
        public delegate void UpdateGroupInfo(int gid, GroupInfoModel newMode);
        public event UpdateGroupInfo updateGroupInfoEvent;
        //个人资料修改事件
        //public delegate void ModifyPersonalInfo(string username);
        //public event ModifyPersonalInfo modifyPersonalInfoEvent;
        #endregion


        //异步获取一个人的信息
        public delegate void RequestPersonalInfoEvent(PersonalInfoModel callback);
        public void getPersonalByID(string personalId, RequestPersonalInfoEvent callBack) {
            if (personalId == string.Empty || personalId == null)
            {
                if (callBack != null)
                {
                    callBack(new PersonalInfoModel());
                }
                return;
            }
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
        public void getGroupByID(int groupId, RequestGroupInfoEvent callBack)
        {
            if (groupDic.ContainsKey(groupId))
            {
                //判断有效性，这样可以保证拉取信息的地方，总可以获得最新的数据

                if (invalidGroup.Contains(groupId))//已过时，去更新，返回最新数据。
                {
                    HttpReqHelper.requestSync(AppConst.WebUrl + "groupBaseInfo?protocol=" + HttpGroupProtocol.GROUP_BASE_INFO + "&gid=" + groupId, delegate (string info)
                    {
                        try
                        {
                            GroupInfoModel newmodel = Coding<GroupInfoModel>.decode(info);
                            if (groupDic.ContainsKey(groupId))
                            {
                                groupDic[groupId] = newmodel;
                            }                         
                            //发送数据已更新的事件
                            if (updateGroupInfoEvent != null)
                            {
                                updateGroupInfoEvent(groupId, newmodel);
                            }
                            //移除无效列表
                            invalidGroup.Remove(groupId);
                            //返回最新数据
                            if (callBack != null)
                            {
                                callBack(groupDic[groupId]);
                            }
                        }
                        catch (Exception err)
                        {
                            Debug.Print("!!!DataMgr.modifyGroupInfo失败" + err.ToString());
                        }
                    });



                }
                else {//有效数据直接返回
                    if (callBack != null)
                    {
                        callBack(groupDic[groupId]);
                    }
                }              
            }
            else//还没有这条数据
            {
                HttpReqHelper.requestSync(AppConst.WebUrl + "groupBaseInfo?protocol="+HttpGroupProtocol.GROUP_BASE_INFO+"&gid=" + groupId, delegate (string info) {
                    try
                    {                     
                        GroupInfoModel model = Coding<GroupInfoModel>.decode(info);
                      //  Debug.Print("收到信息"+ groupId+"  " + model.Name+ model.Master+"|||"+model.Createdtime+model.Verifymode);
                        groupDic.TryAdd(groupId, model);
                        //返回结果
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
   




        //得知一个群的模型信息过时弃用，那么需要把数据标记为无效。
        //需要立即更新的模块才需要注册这个事件，不需要立即更新的模块，等需要时再去更新。
        public void markGroupInfoInvalid(int groupId) {
            invalidGroup.Add(groupId);
            if (deprecatedGroupInfoEvent!=null)
            {
                deprecatedGroupInfoEvent(groupId);
            }
        }


        //强制更新一个群的数据
        private void forceUpdateGroupInfo(int gid)
        {
            HttpReqHelper.requestSync(AppConst.WebUrl + "groupBaseInfo?protocol=" + HttpGroupProtocol.GROUP_BASE_INFO + "&gid=" + gid, delegate (string info)
            {
                try
                {
                    GroupInfoModel model = Coding<GroupInfoModel>.decode(info);
                    if (groupDic.ContainsKey(gid))
                    {
                        groupDic[gid] = model;
                    }
                    else
                    {
                        groupDic.TryAdd(gid, model);
                    }
                    //发送事件
                    if (updateGroupInfoEvent != null)
                    {
                        updateGroupInfoEvent(gid, model);
                    }
                    //移除无效列表
                    invalidGroup.Remove(gid);
                }
                catch (Exception err)
                {
                    Debug.Print("!!!DataMgr.modifyGroupInfo失败" + err.ToString());
                }
            });
        }


        ////修改一个人的数据
        //public void modifyPersonalInfo(PersonalInfoModel mode)
        //{
        //    if (this.personalDic.ContainsKey(mode.Username))
        //    {
        //        this.personalDic[mode.Username] = mode;
        //        if (modifyPersonalInfoEvent != null)
        //        {
        //            modifyPersonalInfoEvent(mode.Username);
        //        }
        //    }
        //}
    }
}

