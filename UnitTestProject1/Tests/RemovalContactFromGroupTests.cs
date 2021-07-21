using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AddressBookWebTests
{
    public class RemovalContactFromGroupTests : AuthTestBase
    {
        [Test]
        public void TestRemovalContactFromGroup()
        {
            ContactData contactdata = new ContactData("ToGroupFirsttName", "ToGroupLastName");
            GroupData groupdata = new GroupData("TestGroupName");
            groupdata.Header = "aaa";
            groupdata.Footer = "123";

            app.Contacts.ContactPresCheck(contactdata);
            app.Groups.GroupPresCheck(groupdata);

            GroupData group = GroupData.GetAll()[0];

            if (group.GetContacts().Any() != true)
            {
                app.Contacts.Create(contactdata);
                ContactData addedContact = ContactData.GetAll().Except(group.GetContacts()).First();
                app.Contacts.AddContactToGroup(addedContact, group);
            }

            List<ContactData> oldList = group.GetContacts();
            ContactData contact = oldList.First();

            app.Contacts.RemoveContactFromGroup(contact, group);

            List<ContactData> newList = group.GetContacts();

            oldList.Remove(contact);
            oldList.Sort();
            newList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }
}
