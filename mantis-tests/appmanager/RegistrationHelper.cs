using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace mantis_tests
{
    public class RegistrationHelper : HelperBase
    {
        public RegistrationHelper(AppManager manager) : base(manager) { }

        public void Register(AccountData account)
        {
            OpenMainPage();
            OpenRegForm();
            FillRegForm(account);
            SubmitRegistration();
        }

        private void OpenRegForm()
        {
            driver.FindElements(By.CssSelector("span.bracket-link"))[0].Click();
        }

        public void SubmitRegistration()
        {
            throw new NotImplementedException();
        }

        public void FillRegForm(AccountData account)
        {
            driver.FindElement(By.Name("username")).SendKeys(account.Username);
            driver.FindElement(By.Name("email")).SendKeys(account.Email);

        }

        public void OpenMainPage()
        {
            manager.Driver.Url = "http://localhost/mantisbt-2.25.2/login_page.php";
        }
    }
}
