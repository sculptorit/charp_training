using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Reflection;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class AddNewIssueTests : TestBase
    {
        [Test]
        public void AddNewIssue()
        {
            AccountData account = new AccountData()
            {
                Username = "administrator",
                Password = "root"
            };

            IssueData issue = new IssueData()
            {
                Summary = "some short text",
                Description = "some long text",
                Category = "General"
            };

            ProjectData project = new ProjectData()
            {
                Id = "1"
            };

            app.API.CreateNewIssue(account, project, issue);

        }
    }
}