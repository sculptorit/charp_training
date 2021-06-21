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
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("TestName", "TestLastName");

            app.Contacts.Create(contact);
            app.Navigator.GoToHomePage();
            app.Auth.Logout();
        }

        [Test]
        public void EmptyContactCreationTest()
        {
            ContactData contact = new ContactData("", "");

            app.Contacts.Create(contact);
            app.Navigator.GoToHomePage();
            app.Auth.Logout();
        }
    }
}
