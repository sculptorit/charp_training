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

            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();

            GroupData ToBeRemoved = oldGroups[0];
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);

            foreach(GroupData groupelement in newGroups)
            {
                Assert.AreNotEqual(groupelement.Id, ToBeRemoved.Id);
            }
        }
    }
}
