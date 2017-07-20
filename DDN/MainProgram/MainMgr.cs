using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProgram
{
    public class MainMgr
    {
        private static MainMgr instance;
        public static MainMgr Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MainMgr();
                }
                return instance;
            }
        }
        #region 属性
        public FormMain formMain;
        public MsgMgr msgMgr;

        private PersonalInfoModel baseInfo;
        public PersonalInfoModel BaseInfo {
            get {
                return baseInfo;
            }
            set {
                baseInfo = value;
                formMain.notifyIconFormMain.Text = "叮叮鸟：" + MainMgr.Instance.BaseInfo.Nickname + "（" + MainMgr.Instance.BaseInfo.Username + "）";
                formMain.flowLayoutPanelFriendList.InitSelfInfo(baseInfo);
            }
        }
        Image selfFace;
        public Image SelfFace {
            get {
                return selfFace;
            }set {
                selfFace = value;
                formMain.flowLayoutPanelFriendList.InitSelfFace(selfFace);
            }
        }        
        #endregion

        public void Init() {
           msgMgr = new MsgMgr();
            UnityControl.ServerForUnity.Instance.Start();
           formMain = new FormMain();
           formMain.Show();
       }
    }
}
