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
    public class ProjectRemovalTests : AuthTestBase
    {
        [Test]
        public void ProjectRemovalTest()
        {
            string projectName = GenerateRandomString(10);
            string projectDescribe = GenerateRandomString(100);

            ProjectData proj = new ProjectData()
            {
                ProjectName = projectName,
                ProjectDescribe = projectDescribe
            };

            app.Project.CheckProjectExist(proj);

            List<ProjectData> oldProjects = app.Project.GetProjectList();

            app.Project.DeleteProject(0);

            List<ProjectData> newProjects = app.Project.GetProjectList();

            oldProjects.RemoveAt(0);
            oldProjects.Sort();
            newProjects.Sort();

            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}
