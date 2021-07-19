using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Collections.Generic;

namespace AddressBookWebTests
{
    [TestFixture]
    public class GroupRemovalTest : AuthTestBase
    {
        [Test]
        public void TheGroupRemovalTest()
        {
            GroupData group = new GroupData("TestGroupName");

            app.Groups.GroupPresCheck(group);

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Remove(0, group);

            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups.RemoveAt(0);

            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
