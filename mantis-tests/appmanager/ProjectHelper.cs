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
    public class ProjectHelper : HelperBase
    {
        public ProjectHelper(AppManager manager) : base(manager) 
        { 
        
        }

        public List<ProjectData> GetProjectList()
        {
            List<ProjectData> projects = new List<ProjectData>();
            manager.Navigator.GoToManagmentPage();
            manager.Navigator.GoToProjManagmentPage();
            ICollection<IWebElement> elements = driver
                .FindElements(By.XPath("//div[@id='content']/div[2]/table/tbody/tr"));
            foreach (IWebElement element in elements)
            {
                ProjectData project = new ProjectData();
                project.ProjectName = element.FindElement(By.TagName("a")).Text;
                project.ProjectDescribe = element.FindElements(By.TagName("td"))[4].Text;
                projects.Add(project);
            }
            return projects;
        }

        public void CreateProject(ProjectData project)
        {
            manager.Navigator.GoToManagmentPage();
            manager.Navigator.GoToProjManagmentPage();

            StartProjCreation();
            FillProjForm(project);
            ConfirmProjCreation();
        }

        public void DeleteProject(int index)
        {
            manager.Navigator.GoToManagmentPage();
            manager.Navigator.GoToProjManagmentPage();

            SelectProject(index);
            PushProjectDelete();
            ConfirmProjectDeletion();
        }

        private void SelectProject(int index)
        {
            driver.FindElement(By.XPath("//div[@id='content']/div[2]/table/tbody/tr[" + (index+1) + "]/td/a"))
                .Click();
        }
        private void StartProjCreation()
        {
            driver.FindElement(By.XPath("//input[@value='создать новый проект']")).Click();
        }

        private void FillProjForm(ProjectData project)
        {
            driver.FindElement(By.Id("project-name")).SendKeys(project.ProjectName);
            driver.FindElement(By.Id("project-description")).SendKeys(project.ProjectDescribe);
        }

        private void ConfirmProjCreation()
        {
            driver.FindElement(By.XPath("//input[@value='Добавить проект']")).Click();
        }

        private void ConfirmProjectDeletion()
        {
            driver.FindElement(By.XPath("//input[@value='Удалить проект']")).Click();
        }

        private void PushProjectDelete()
        {
            driver.FindElement(By.XPath("//input[@value='Удалить проект']")).Click();
        }
        public void CheckProjectExist(ProjectData project)
        {
            manager.Navigator.GoToManagmentPage();
            manager.Navigator.GoToProjManagmentPage();

            ICollection<IWebElement> elements = driver.FindElements(By
                .XPath("//div[@id='content']/div[2]/table/tbody/tr/td"));

            if (elements.Count() > 0)
            {
                return;
            }

            CreateProject(project);
        }
    }
}