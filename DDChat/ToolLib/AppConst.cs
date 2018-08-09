


using System.Drawing;
/// <summary>
/// 重要的常量定义
/// </summary>
public class AppConst
    {

    //#if DEBUG
    //        static string ip = "192.168.1.101";
    //#else
    //    static string ip = "211.159.186.78";
    //#endif
    //static string ip = "192.168.133.50";
    static string ip = "211.159.186.78";
    public static string SocketUrl = ip;//叮叮鸟主程序IP
    public static int SocketPort = 10103;//叮叮鸟主程序端口
    public static string WebUrl = "http://" + SocketUrl + ":5677/";

    public static string WinPicPath = "C:/Users/Public/DDN/win/face/";//win图片保存位置                                                                      //public static string StandaloneDBPath = "C:/Users/Public/standalone.db";//单机模式数据库位置
    public static int maxReceiveSize = 4000;
    public static string APP_VERSION = "2_3_0x";//版本号[0]主版本，[1]数据库版本，[2]功能代号


    //      public const bool UpdateMode = true;                       //更新模式-默认关闭 

    public static Color panelColor = Color.FromArgb(64, 64, 64);

  




}
