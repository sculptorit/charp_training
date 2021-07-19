using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AddressBookWebTests
{
    [TestFixture]
    public class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void TestContactInformationEditPage()
        {
            ContactData contact = new ContactData("", "");

            ContactData fromTable = app.Contacts.GetContactInfoFromTable(0);
            ContactData fromForm = app.Contacts.GetContactInfoFromEditForm(0, contact);

            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
        }

        [Test]
        public void TestContactInformationDetailsPage()
        {
            ContactData contact = new ContactData("", "");

            ContactData fromForm = app.Contacts.GetContactInfoFromEditForm(0, contact);
            string fromDetais = app.Contacts.GetContactInformationFromDetailsPage(0);

            Assert.AreEqual(fromDetais, fromForm.AllPageData);
        }
    }
}
