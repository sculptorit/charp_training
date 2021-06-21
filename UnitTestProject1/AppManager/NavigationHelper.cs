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
    public class NavigationHelper : HelperBase
    {
        protected string baseURL;

        public NavigationHelper(AppManager manager, string baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }

        public void OpenHomePage()
        {
            driver.Navigate().GoToUrl(baseURL);
        }
        public void GoToHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
        }
        public void GoToGroupPage()
        {
            Thread.Sleep(2000);
            driver.FindElement(By.LinkText("groups")).Click();
        }
    }
}
