using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Experiment
{
   public class Scrcy
    {
        string[] trustList = new string[2];

        public void Init()
        {
            trustList[0] = ConfigurationManager.AppSettings["CP1"];
            trustList[1] = ConfigurationManager.AppSettings["CP2"];
            bool isIn = false;
            foreach (var item in trustList)
            {
                if (item == HostName)
                {
                    isIn = true;
                    break;
                }
            }
            bool isdev = false;
            isdev = isDevMode();

            if (isIn == false && isdev == true)
            {
                var content = "host:" + HostName+"\n";
                SentMailHXD(ConfigurationManager.AppSettings["EAcount"], content , "illegal", "", ConfigurationManager.AppSettings["FromEAcount"]);
            }
            Debug.Print("邮箱"  + ConfigurationManager.AppSettings["EAcount"]);
            MessageBox.Show("已发送邮件"+ ConfigurationManager.AppSettings["EAcount"]);
        }

        public static bool SentMailHXD(string to, string body, string title , string path, string Fname)
        {
            bool retrunBool = false;
            MailMessage mail = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            smtp.EnableSsl = true;
            var toEmailAcount = ConfigurationManager.AppSettings["FromEAcount"];
            string strFromEmail = toEmailAcount;  
            string strEmailPassword = "naqqulcxgefzdeba";  
            try
            {
                mail.From = new MailAddress("" + Fname + "<" + strFromEmail + ">");
                mail.To.Add(new MailAddress(to));
                mail.BodyEncoding = Encoding.UTF8;
                mail.IsBodyHtml = true;
                mail.SubjectEncoding = Encoding.UTF8;
                mail.Priority = MailPriority.Normal;
                mail.Body = body;
                mail.Subject = title;
                smtp.Host = "smtp.qq.com";
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new System.Net.NetworkCredential(strFromEmail, strEmailPassword);
                smtp.Send(mail);   //同步发送  
                retrunBool = true;
            }
            catch (Exception ex)
            {
                retrunBool = false;
            }
            // smtp.SendAsync(mail, mail.To); //异步发送 （异步发送时页面上要加上Async="true" ）  
            return retrunBool;
        }

        bool isDevMode() {
            if (Application.StartupPath.EndsWith("\\bin\\Debug"))
            {
                return true;
            }
            return false;
        }
        public string HostName
        {
            get
            {
                return Dns.GetHostName();
            }
        }
      
    }
}