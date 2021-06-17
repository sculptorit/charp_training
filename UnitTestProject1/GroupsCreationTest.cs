using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace AddressBookWebTests
{
    [TestFixture]
    public class GroupsCreationTests : TestBase
    {
        [Test]
        public void GroupsCreationTest()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            OpenGroupPage();
            NewGroupCreation();
            GroupData group = new GroupData("TestGroupName");
            group.Header = "aaa";
            group.Footer = "123";
            FeelGroupForms(group);
            SubmitGroupCreation();
            ReturnToGroupPage();
            Logout();
        }
    }
}
