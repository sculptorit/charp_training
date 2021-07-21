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
    public class GroupRemovalTest : GroupTestBase
    {
        [Test]
        public void TheGroupRemovalTest()
        {
            GroupData group = new GroupData("TestGroupName");

            app.Groups.GroupPresCheck(group);

            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData toBeRemoved = oldGroups[0];

            app.Groups.Remove(toBeRemoved);

            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();

            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);

            foreach(GroupData groupelement in newGroups)
            {
                Assert.AreNotEqual(groupelement.Id, toBeRemoved.Id);
            }
        }
    }
}
