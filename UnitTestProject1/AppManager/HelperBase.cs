using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace AddressBookWebTests
{
    public class HelperBase
    {
        protected IWebDriver driver;
        protected AppManager manager;
        protected bool acceptNextAlert = true;

        public HelperBase(AppManager manager)
        {
            this.manager = manager;
            driver = manager.Driver;
        }
    }
}