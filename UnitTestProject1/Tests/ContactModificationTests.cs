using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;

namespace AddressBookWebTests

{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void TheContactModificationTest()
        {
            ContactData contact = new ContactData("TestName", "TestLastName");
            ContactData newData = new ContactData("NewName","NewLastName");

            app.Contacts.ContactPresCheck(contact);

            List<ContactData> oldContacts = app.Contacts.GetContactList();
            ContactData oldData = oldContacts[0];

            app.Contacts.Modify(0, newData);

            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts[0].FirstName = newData.FirstName;
            oldContacts[0].LastName = newData.LastName;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contactelement in newContacts)
            {
                if (contactelement.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.FirstName, contactelement.FirstName);
                    Assert.AreEqual(newData.LastName, contactelement.LastName);
                }
            }
        }
    }
}
