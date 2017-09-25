using System.Drawing;
using UnityModule;

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
        public MsgTip msgTip = null;


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
            msgTip = new MsgTip();
            msgMgr = new MsgMgr();//这个必须立即实例化，其实目前就有bug
           ServerForUnity.Instance.Start();          
           formMain = new FormMain();
           formMain.Show();                    
        }
    }
}
