using System.Collections;
using System.Collections.Generic;

//***************************
//保存一些重要的数据
//*****************************
namespace DDN
{
    public class GameInfo
    {

        public static string ACC_ID = "";    //保存账号
        public static string ACC_PSD = "";    //保存密码

        public static PersonalInfoModel BaseInfo = new PersonalInfoModel();
        //     public static string ACC_LEVEL = ""; //保存用户级别
        //    public static string PROVIDER = "";  //如果是企业用户的话，保存企业用户的名字
        //    public static int IS_SETUP = 0;      //程序是否正常启动
        //    public static bool IS_INPUT_PANEL_STATE = false;//是否存在可输入面板。

        public static string APP_VERSION = "1_3_0.7";//版本号[0]主版本，[1]数据库版本，[2]功能代号
        public static int IS_LOGIN = 0;//是否已经登陆
        public static int LOGIN_MODEL = 0;//登陆模式，0表示正常网络登陆； 1表示单机版登陆
    }
}