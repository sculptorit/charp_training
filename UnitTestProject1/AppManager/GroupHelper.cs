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
    public class GroupHelper : HelperBase
    {
        protected string baseURL;
        public GroupHelper(AppManager manager) : base(manager)
        {
        }

        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupPage();

            NewGroupCreation();
            FillGroupForms(group);
            SubmitGroupCreation();
            ReturnToGroupPage();
            return this;
        }

        private List<GroupData> groupCache = null;

        public List<GroupData> GetGroupList()
        {
            if (groupCache == null)
            {
                groupCache = new List<GroupData>();
                manager.Navigator.GoToGroupPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {
                    groupCache.Add(new GroupData(element.Text)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });
                }
            }

            return new List<GroupData>(groupCache);
        }

        public int GetGroupCount()
        {
           return driver.FindElements(By.CssSelector("span.group")).Count;
        }


        public GroupHelper Modify(int v, GroupData newData)
        {
            manager.Navigator.GoToGroupPage();

            SelectGroup(v, newData);
            InitGroupMod();
            FillGroupForms(newData);
            SubmitGroupMod();
            ReturnToGroupPage();
            return this;
        }

        public GroupHelper Modify(GroupData oldData, GroupData newData)
        {
            manager.Navigator.GoToGroupPage();

            SelectGroup(oldData.Id);
            InitGroupMod();
            FillGroupForms(newData);
            SubmitGroupMod();
            ReturnToGroupPage();
            return this;
        }



        public GroupHelper Remove(int v, GroupData newData)
        {
            manager.Navigator.GoToGroupPage();

            SelectGroup(v, newData);
            RemoveGroup();
            ReturnToGroupPage();
            return this;
        }

        public GroupHelper Remove(GroupData group)
        {
            manager.Navigator.GoToGroupPage();
            SelectGroup(group.Id);
            RemoveGroup();
            ReturnToGroupPage();
            return this;
        }

        //Методы, относящиеся к созданию новой группы
        public GroupHelper NewGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }
        public GroupHelper FillGroupForms(GroupData group)
        {
            TypeData(By.Name("group_name"), group.Name);
            TypeData(By.Name("group_header"), group.Header);
            TypeData(By.Name("group_footer"), group.Footer);
            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            groupCache = null;
            return this;
        }
        public GroupHelper ReturnToGroupPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }

        public GroupHelper SelectGroup(int index, GroupData group)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index+1) + "]")).Click();
            return this;
        }

        public GroupHelper SelectGroup(String id)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value='"+id+"'])")).Click();
            return this;
        }
        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            groupCache = null;
            return this;
        }


        public GroupHelper InitGroupMod()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }
        public GroupHelper SubmitGroupMod()
        {
            driver.FindElement(By.Name("update")).Click();
            groupCache = null;

            return this;
        }

        public GroupHelper GroupPresCheck(GroupData group)
        {
            manager.Navigator.GoToGroupPage();
            if (!IsGroupPresent())
            {
                Create(group);
            }
            return this;
        }

        public bool IsGroupPresent()
        {
            Thread.Sleep(2000);
            return IsElementPresent(By.Name("selected[]"));
        }
    }
}
