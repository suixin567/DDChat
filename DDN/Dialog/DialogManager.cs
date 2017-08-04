//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace Dialog
//{
//    public class DialogManager
//    {
//        #region 单例
//        private static DialogManager instance;
//        public static DialogManager Instance
//        {
//            get
//            {
//                if (instance == null)
//                {
//                    instance = new DialogManager();
//                    formDialogManager = new FormDialogManager();
//                }
//                return instance;
//            }
//        }
//        #endregion
//        public FormDialogManager formDialogManager = null;
//        public Dictionary<int, Form> formGroupDictionary = new Dictionary<int, Form>();
//        public Dictionary<int, Form> formFriendDictionary = new Dictionary<int, Form>();
//        public Form formSelf = null;
//        public Form formShop = null;
//        #region 属性


//        //public bool isDialogShow = false;
//        //public int unityMode = 1;//0为编辑器模式
//        //public int resourceMode = 0;//资源模式 0：公开商城1：群资源2：个人资源
//        //public string currentGroup = "";//当前群组
//        //public int sceneIndex = 4;
//        //public bool isUpdateing = false;//是否更新中
//        //public int netMode = 0;//网络模式，0为正常模式，1为离线模式
//        //public IntPtr formMainHandle;
//        //public IntPtr unityHandle;
//        //public FormUnity formUnity = null;
//        #endregion


//        public void openDialog(int dialogType , int id=-1)
//        {
//            switch (dialogType)
//            {
//                case 0://请求打开商城
//                    if (formShop == null)
//                    {
//                        formShop = new FormDialog(dialogType,id);
//                        formShop.Show();
//                    }
//                    break;
//                case 1://请求打开群
//                    if (formGroupDictionary.ContainsKey(id) == false)
//                    {
//                        FormDialog formGroup = new FormDialog(dialogType, id);
//                        formGroup.Show();
//                        formGroupDictionary.Add(id, formGroup);
//                    }
//                    break;
//                case 2://请求打开个人
//                    if (formSelf==null)
//                    {
//                        formSelf = new FormDialog(dialogType, id);
//                        formSelf.Show();
//                    }                   
//                    break;
//                case 3://请求打开朋友
//                    if (formFriendDictionary.ContainsKey(id) ==false)
//                    {
//                        FormDialog formFriend = new FormDialog(dialogType, id);
//                        formFriend.Show();
//                        formFriendDictionary.Add(id, formFriend);
//                    }
//                    break;
//            }         

                                        
//        }

//    }


//}
