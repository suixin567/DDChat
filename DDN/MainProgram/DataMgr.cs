using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProgram
{
    //数据的管理类，一个人或者群的基本信息都缓储存在这里。
    //例如：根据一个id获取这个人的昵称和头像。
    //根据一个id获取一个群的昵称和头像。
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
        Dictionary<string, PersonalInfoModel> personalDic = new Dictionary<string, PersonalInfoModel>();
        Dictionary<string, GroupInfoModel> groupDic = new Dictionary<string, GroupInfoModel>();
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
                HttpReqHelper.requestSync(AppConst.WebUrl + "baseInfo?username=" + personalId, delegate (string personalInfo) {
                    try
                    {
                        PersonalInfoModel model = Coding<PersonalInfoModel>.decode(personalInfo);
                        personalDic.Add(personalId,model);
                        if (callBack != null)
                        {
                            callBack(personalDic[personalId]);
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
                HttpReqHelper.requestSync(AppConst.WebUrl + "groupBaseInfo?gid=" + groupId, delegate (string info) {
                    try
                    {
                        GroupInfoModel model = Coding<GroupInfoModel>.decode(info);
                        groupDic.Add(groupId, model);
                        if (callBack != null)
                        {
                            callBack(groupDic[groupId]);
                        }
                    }
                    catch (Exception err)
                    {
                        Debug.Print("DataMgr.getGroupByID解析失败" + err.ToString());
                        if (callBack != null)
                        {
                            callBack(default(GroupInfoModel));
                        }
                    }
                });
            }
        }
    }
}
//一个人的信息被改变后怎么办？ 可以不理会。下载加载时自然会更新的。

