using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SimpleBrowser.WebDriver;


namespace mantis_tests
{
    public class APIHelper : HelperBase
    {

        public APIHelper(AppManager manager) : base(manager) 
        {

        }

        public void CheckProjectExist(AccountData account, ProjectData projectData)
        {
            if (GetProjectList(account).Count() == 0)
            {
                CreateProject(account, projectData);
            }
        }
        public List<ProjectData> GetProjectList(AccountData account)
        {
            List<ProjectData> projects = new List<ProjectData>();

            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData[] elements = client.mc_projects_get_user_accessible(account.Username, account.Password);

            foreach (Mantis.ProjectData element in elements)
            {
                ProjectData project = new ProjectData();
                project.ProjectName = element.name;
                project.ProjectDescribe = element.description;
                projects.Add(project);
            }
            return projects;
        }

        public void CreateProject(AccountData account, ProjectData projectData)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData project = new Mantis.ProjectData();
            project.name = projectData.ProjectName;
            project.description = projectData.ProjectDescribe;
            client.mc_project_add(account.Username, account.Password, project);
        }

        /*public void CreateNewIssue(AccountData account, ProjectData project, IssueData issueData)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.IssueData issue = new Mantis.IssueData();
            issue.summary = issueData.Summary;
            issue.description = issueData.Description;
            issue.category = issueData.Category;
            issue.project = new Mantis.ObjectRef();
            issue.project.id = project.Id;
            client.mc_issue_add(account.Username, account.Password, issue);
        }
        */
    }
}
