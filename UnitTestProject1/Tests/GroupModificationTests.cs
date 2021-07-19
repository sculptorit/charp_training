using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;

namespace AddressBookWebTests

{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void TheGroupModificationTest()
        {
            GroupData group = new GroupData("TestGroupName");
            group.Header = "aaa";
            group.Footer = "123";

            GroupData newData = new GroupData("ModifiedName");
            newData.Header = null;
            newData.Footer = null;

            app.Groups.GroupPresCheck(group);

            List<GroupData> oldGroups = app.Groups.GetGroupList();
            GroupData oldData = oldGroups[0];

            app.Groups.Modify(0, newData);

            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups.Count, newGroups.Count);

            foreach (GroupData groupelement in newGroups)
            {
                if (groupelement.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Name, groupelement.Name);
                }
            }
        }


    }
}
