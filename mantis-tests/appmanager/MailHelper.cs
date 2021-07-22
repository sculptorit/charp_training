using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpaqueMail.Net;

namespace mantis_tests
{
    public class MailHelper : HelperBase
    {
        public MailHelper(AppManager manager) : base(manager) { }

        public String GetLastMail(AccountData account)
        {
            for (int i = 0; i < 20; i++)
            {
                Pop3Client pop3 = new Pop3Client("localhost", 110, account.Username, account.Password, false);
                pop3.Connect();
                pop3.Authenticate();
                if (pop3.GetMessageCount() > 0)
                {
                    ReadOnlyMailMessage message = pop3.GetMessage(1);
                    string body = message.Body;
                    pop3.DeleteMessage(1);
                    pop3.LogOut();
                    return body;
                }
                else
                {
                    System.Threading.Thread.Sleep(3000);
                }
            }
            return null;
        }

    }
}