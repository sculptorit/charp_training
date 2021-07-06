using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace AddressBookWebTests

{
    [TestFixture]
    public class GroupModificationTests : TestBase
    {
        [Test]
        public void TheGroupModificationTest()
        {
            GroupData newData = new GroupData("ModifiedName");
            newData.Header = "mod";
            newData.Footer = "cha";

            app.Groups.Modify(1, newData);
        }


    }
}
