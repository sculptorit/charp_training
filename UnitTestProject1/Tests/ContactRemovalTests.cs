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
    public class ContactRemovalTests : ContactTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            ContactData contact = new ContactData("TestFirstName","TestLastName");

            app.Contacts.ContactPresCheck(contact);

            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData ToBeRemoved = oldContacts[0];

            app.Contacts.Remove(ToBeRemoved);

            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactCount());

            List<ContactData> newContacts = ContactData.GetAll();

            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contactelement in newContacts)
            {
                Assert.AreNotEqual(contactelement.Id, ToBeRemoved.Id);
            }
        }
    }
}