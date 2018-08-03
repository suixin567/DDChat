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
    //static string ip = "192.168.1.101";
    static string ip = "211.159.186.78";
    public static string SocketUrl = ip;//叮叮鸟主程序IP
    public static int SocketPort = 10103;//叮叮鸟主程序端口
    public static string WebUrl = "http://" + SocketUrl + ":5677/";

    public static string WinPicPath = "C:/Users/Public/DDN/win/face/";//win图片保存位置                                                                      //public static string StandaloneDBPath = "C:/Users/Public/standalone.db";//单机模式数据库位置
    public static int maxReceiveSize = 4000;
    public static string APP_VERSION = "2_3_0x";//版本号[0]主版本，[1]数据库版本，[2]功能代号

    //      public const int maxSocketSize = 5000;
    //      public const bool UpdateMode = true;                       //更新模式-默认关闭 
    //      public const int GameFrameRate = 30;                       //游戏帧频
    //      public const bool UsePbc = true;                           //PBC
    //      public const bool UseLpeg = true;                          //LPEG
    //      public const bool UsePbLua = true;                         //Protobuff-lua-gen
    //      public const bool UseCJson = true;                         //CJson
    //      public const bool UseSproto = true;                        //Sproto
    //      public const bool LuaEncode = false;                        //使用LUA编码
    //      public const string AppName = "SimpleFramework";           //应用程序名称
    //      public const string AppPrefix = AppName + "_";             //应用程序前缀
    //      public const string ExtName = ".assetbundle";              //素材扩展名
    //      public const string AssetDirname = "StreamingAssets";      //素材目录 
    //      public static string UserId = string.Empty;                 //用户ID
    //      public static int SocketPort = 0;                           //Socket服务器端口
    //      public static string SocketAddress = string.Empty;          //Socket服务器地址
}
