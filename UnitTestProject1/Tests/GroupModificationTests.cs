using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;

namespace AddressBookWebTests

{
    [TestFixture]
    public class GroupModificationTests : ContactTestBase
    {
        [Test]
        public void TheGroupModificationTest()
        {
            GroupData group = new GroupData("TestGroupName");
            group.Header = "aaa";
            group.Footer = "123";

            GroupData newData = new GroupData("NewGroupName");
            newData.Header = "null";
            newData.Footer = "null";

            app.Groups.GroupPresCheck(group);

            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData oldData = oldGroups[0];

            app.Groups.Modify(oldData, newData);

            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData groupelement in newGroups)
            {
                if  (groupelement.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Name, groupelement.Name);
                }
            }
        }
    }
}
