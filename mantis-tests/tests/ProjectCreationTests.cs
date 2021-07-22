using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using NUnit.Framework;
using System.Threading.Tasks;
using System.Threading;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectCreationTests : AuthTestBase
    {
        [Test]
        public void ProjectCreationTest()
        {
            string projectName = GenerateRandomString(10);
            string projectDescribe = GenerateRandomString(100);

            ProjectData proj = new ProjectData()
            {
                ProjectName = projectName,
                ProjectDescribe = projectDescribe
            };

            List<ProjectData> oldProjects = app.Project.GetProjectList();

            app.Project.CreateProject(proj);

            List<ProjectData> newProjects = app.Project.GetProjectList();

            oldProjects.Add(proj);
            oldProjects.Sort();
            newProjects.Sort();

            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}
