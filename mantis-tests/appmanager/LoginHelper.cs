﻿using System;
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
    public class LoginHelper : HelperBase
    {
        public LoginHelper(AppManager manager) : base(manager) 
        { 
        
        }

        public void Login(AccountData account)
        {
            manager.Navigator.OpenMainPage();
            if (IsLoggedIn())
            {
                if (IsLoggedIn(account))
                {
                    return;
                }

                Logout();
            }

            Type(By.Name("user"), account.Username);
            Type(By.Name("pass"), account.Password);
            driver.FindElement(By.CssSelector("input[value='Войти']")).Click();
        }

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.CssSelector("logged-in-user"));
        }

        public void Logout()
        {
            if (IsLoggedIn())
            {
                driver.FindElement(By.Id("logout-link")).Click();
                WebDriverWait waiter = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                IWebElement webelement = waiter.Until(ExpectedConditions.
                    ElementIsVisible(By.CssSelector("input[value = 'Войти']")));
            }
        }
        public bool IsLoggedIn(AccountData account)
        {
            return IsLoggedIn()
                && driver.FindElement(By.CssSelector("logged-in-user"))
                .Text == account.Username;
        }
    }
}