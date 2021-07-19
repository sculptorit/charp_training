using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace AddressBookWebTests
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper (AppManager manager) : base(manager)
        {
        }

        public void Login(AccountData account)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(account))
                {
                    return;
                }

                Logout();
            }

            TypeData(By.Name("user"), account.Username);
            TypeData(By.Name("pass"), account.Password);
            driver.FindElement(By.Id("LoginForm")).Submit();
        }
        public void Logout()
        {
            if (IsLoggedIn())
            {
            driver.FindElement(By.LinkText("Logout")).Click();
            }
        }
        public bool IsLoggedIn()
        {
            return IsElementPresent(By.Name("logout"));
        }
        public bool IsLoggedIn(AccountData account)
        {
            Thread.Sleep(1000);
            return IsLoggedIn()
                && GetLoggedUserName() == account.Username;
        }

        private string GetLoggedUserName()
        {
         string text = driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text;
         return text.Substring(1, text.Length - 2);
        }
    }
}
