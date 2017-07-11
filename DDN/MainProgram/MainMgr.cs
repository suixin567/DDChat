using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public PersonalInfoModel BaseInfo;
        #endregion

        public void Init() {
           msgMgr = new MsgMgr();
            UnityControl.ServerForUnity.Instance.Start();
           formMain = new FormMain();
           formMain.Show();
       }
    }
}
