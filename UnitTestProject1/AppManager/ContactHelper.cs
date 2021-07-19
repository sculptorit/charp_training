﻿using System;
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
            manager.Navigator.GoToHomePage();
            InitContactCreation();
            InputContactData(contact);
            SubmitContactData();
            manager.Navigator.GoToHomePage();
            return this;
        }

        private List<ContactData> contactCache = null;

        public List<ContactData> GetContactList()
        {
            if(contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Navigator.GoToHomePage();
                Thread.Sleep(2000);
                ICollection<IWebElement> elements = driver.FindElements(By.Name("entry"));
                foreach (IWebElement element in elements)
                {
                    IList<IWebElement> cells = element.FindElements(By.TagName("td"));
                    contactCache.Add(new ContactData(cells[2].Text, cells[1].Text){
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                });
                }
            }

            return new List<ContactData>(contactCache);
        }
        public int GetContactCount()
        {
            return driver.FindElements(By.Name("entry")).Count;
        }

        public ContactHelper Modify(int v, ContactData newData)
        {
            manager.Navigator.GoToHomePage();
            StartEditContactPage(v, newData);
            InputContactData(newData);
            SubmitContactMod();
            manager.Navigator.GoToHomePage();
            return this;
        }

        public ContactHelper Remove(int v, ContactData contact)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(v, contact);
            RemoveContact();
            manager.Navigator.GoToHomePage();
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
            contactCache = null;
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
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index+1) + "]")).Click();
            return this;
        }
        public ContactHelper RemoveContact()
        {
            acceptNextAlert = true;
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(), "^Delete 1 addresses[\\s\\S]$"));
            Thread.Sleep(2000);
            contactCache = null;
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

        public ContactHelper ContactPresCheck(ContactData contact)
        {
            if (!IsContactPresent())
            {
                Create(contact);
            }
            return this;
        }
        public void StartEditContactPage(int index, ContactData contact)
        {
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//img[@alt='Edit'][" + (index+1) + "]")).Click();
        }
        public ContactHelper SubmitContactMod()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCache = null;
            return this;
        }
    }
}

