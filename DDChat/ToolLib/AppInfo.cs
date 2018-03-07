using System.Collections.Generic;
using System.Drawing;

public class AppInfo
    {
  
    public static string USER_NAME = "";
    public static string PASS_WORD = "";

    //当个人信息发生变化事件
    public delegate void PersonalInfoModelChange();    
    public static event PersonalInfoModelChange onPersonalInfoModelChanged;

    //个人数据模型
    private static PersonalInfoModel personal_info = new PersonalInfoModel();
    public static PersonalInfoModel PERSONAL_INFO {
        get {
            return personal_info;
        }
        set {
            personal_info = value;
            if (onPersonalInfoModelChanged != null)
            {
                onPersonalInfoModelChanged();
            }
        }
    }
    //当个人头像发生变化事件
    public delegate void PersonalFaceChange();
    public static event PersonalFaceChange onPersonalFaceChanged;
    //个人头像
    private static Image self_Face;
    public static Image SELF_FACE
    {
        get
        {
            return self_Face;
        }
        set
        {
            self_Face = value;
            if (onPersonalFaceChanged != null)
            {
                onPersonalFaceChanged();
            }
        }
    }

    //我的好友列表
    private static List<string>  myFriendList=new List<string>();
    public static List<string> MyFriendList {
        get {
            return myFriendList;
        }set {
            myFriendList = value;
        }
    }

}

