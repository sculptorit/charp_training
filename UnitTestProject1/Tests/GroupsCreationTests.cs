using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace AddressBookWebTests
{
    [TestFixture]
    public class GroupsCreationTests : AuthTestBase
    {
        [Test]
        public void GroupsCreationTest()
        {
            GroupData group = new GroupData("TestGroupName");
            group.Header = "aaa";
            group.Footer = "123";

            app.Groups.Create(group);
        }

        [Test]
        public void EmptyGroupsCreationTest()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            app.Groups.Create(group);
        }
    }
}
