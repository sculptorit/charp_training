using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class NavigationHelper : HelperBase
    {
        public NavigationHelper(AppManager manager) : base(manager) { }
        public void OpenMainPage()
        {
            manager.Driver.Url = @"http://localhost/mantisbt-2.25.2/login_page.php";
        }

        public void GoToProjManagmentPage()
        {
            driver.FindElement(By.LinkText("Управление проектами")).Click();
        }
        public void GoToManagmentPage()
        {
            driver.FindElement(By.ClassName("manage-menu-link")).Click();
        }
    }
}