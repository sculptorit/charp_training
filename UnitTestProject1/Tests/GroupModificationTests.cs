using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

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

            app.Groups.Modify(1, newData);
        }


    }
}
