



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

  

}

