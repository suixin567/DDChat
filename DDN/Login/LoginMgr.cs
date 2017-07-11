using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
   public class LoginMgr
    {
        private static LoginMgr instance;
        public static LoginMgr Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LoginMgr();
                }
                return instance;
            }
        }

        public FormLogin formLogin;

        public void Init() {
            formLogin = new FormLogin();
            formLogin.Show();
        }

    }
}
