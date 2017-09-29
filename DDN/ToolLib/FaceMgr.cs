using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;

namespace ToolLib
{
    public class FaceMgr
    {

        #region 单例
        private static FaceMgr instance;
        public static FaceMgr Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FaceMgr();
                }
                return instance;
            }
        }
        #endregion

        #region 属性
        ConcurrentDictionary<string, Image> faceDic = new ConcurrentDictionary<string, Image>();
     
        public delegate void ModifyFace(int gid);
        public event ModifyFace modifyFaceEvent;
        #endregion



        //修改一个群的头像
        public void modifyFace(int gid)
        {
            if (modifyFaceEvent != null)
            {
                modifyFaceEvent(gid);
            }
        }
    }
}
