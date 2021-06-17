using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace AddressBookWebTests
{
    [TestFixture]
    public class GroupRemovalTest : TestBase
    {
        [Test]
        public void TheGroupRemovalTest()
        {
            OpenHomePage();
            Login(new AccountData ("admin", "secret"));
            OpenGroupPage();
            SelectGroup(1);
            RemoveGroup();
            ReturnToGroupPage();
            Logout();
        }
    }
}
