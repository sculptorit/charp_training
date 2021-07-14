using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Text.RegularExpressions;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace AddressBookWebTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(AppManager manager) : base(manager)
        {
        }

        public ContactHelper Create(ContactData contact)
        {
            InitContactCreation();
            InputContactData(contact);
            SubmitContactData();
            return this;
        }
        public ContactHelper Modify(int v, ContactData newData)
        {
            StartEditContactPage(v, newData);
            InputContactData(newData);
            SubmitContactMod();
            return this;
        }

        public ContactHelper Remove(int v, ContactData contact)
        {
            SelectContact(v, contact);
            RemoveContact();
            return this;
        }

        //Методы, относящиеся к созданию контактов
        public ContactHelper InitContactCreation()
        {
            Thread.Sleep(2000);
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

            public ContactHelper InputContactData(ContactData contact)
        {
            TypeData(By.Name("firstname"), contact.FirstName);
            TypeData(By.Name("lastname"), contact.LastName);
            return this;
        }
        public ContactHelper SubmitContactData()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
            return this;
        }

        //Методы, относящиеся к удалению контактов
        public ContactHelper SelectContact(int index, ContactData contact)
        {
            Thread.Sleep(2000);
            if (!IsContactPresent())
            {
                Create(contact);
            }
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            return this;
        }
        public ContactHelper RemoveContact()
        {
            acceptNextAlert = true;
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(), "^Delete 1 addresses[\\s\\S]$"));
            return this;
        }
         public string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }

        //Методы, относящиеся к изменению контактов

        public bool IsContactPresent()
        {
            Thread.Sleep(2000);
            return IsElementPresent(By.Name("selected[]"));
        }

        public void StartEditContactPage(int index, ContactData contact)
        {
            if (!IsContactPresent())
            {
                Create(contact);
            }
            Thread.Sleep(2000);
            driver.Navigate().GoToUrl("http://localhost/addressbook/edit.php?id=" + index + "");
        }
        public ContactHelper SubmitContactMod()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[22]")).Click();
            return this;
        }
    }
}

