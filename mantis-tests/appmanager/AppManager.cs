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
using NUnit.Framework;


namespace mantis_tests
{
    public class AppManager
    {
        //public RegistrationHelper Registration { get; set; }
        //public FtpHelper Ftp { get; set; }
        public LoginHelper Auth { get; set; }
        public NavigationHelper Navigator { get; set; }
        public ProjectHelper Project { get; set; }


        protected IWebDriver driver;
        protected string baseURL;
        protected StringBuilder verificationErrors;

        private static ThreadLocal<AppManager> app = new ThreadLocal<AppManager>();

        private AppManager()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost/addressbook/";
            //Registration = new RegistrationHelper(this);
            //Ftp = new FtpHelper(this);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            verificationErrors = new StringBuilder();
            Auth = new LoginHelper(this);
            Navigator = new NavigationHelper(this);
            Project = new ProjectHelper(this);
        }

       ~AppManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        public static AppManager GetInstance()
        {
            if (! app.IsValueCreated)
            {
                AppManager newInstance = new AppManager();
                newInstance.driver.Url = "http://localhost/mantisbt-2.25.2/login_page.php";
                app.Value = newInstance;
            }
            return app.Value;
        }
        public IWebDriver Driver 
        { 
            get
            {
                return driver;
            }
        }

        [SetUp]
        public void Start()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost/addressbook";
        }
    }
}
