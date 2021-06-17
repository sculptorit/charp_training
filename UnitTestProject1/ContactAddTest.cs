using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace AddressBookWebTests
{
    [TestFixture]
    public class ContactAddTest : TestBase
    {
        [Test]
        public void TheContactCreationTest()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            ContactData contact = new ContactData("TestName", "TestLastName");
            InputContactData(contact);
            SubmitContactData();
            GoToHomePage();
            Logout();
        }
    }
}
