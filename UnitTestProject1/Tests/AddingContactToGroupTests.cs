using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AddressBookWebTests
{
    public class AddingContactToGroupTests : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {
            ContactData contactdata = new ContactData("ToGroupFirsttName", "ToGroupLastName");
            GroupData groupdata = new GroupData("TestGroupName");
            groupdata.Header = "aaa";
            groupdata.Footer = "123";

            app.Contacts.ContactPresCheck(contactdata);
            app.Groups.GroupPresCheck(groupdata);

            GroupData group = GroupData.GetAll()[0];

            if ((ContactData.GetAll().Except(group.GetContacts())).Any() != true)
            {
                app.Contacts.Create(contactdata);
            }

            List<ContactData> oldList = group.GetContacts();
            ContactData contact = ContactData.GetAll().Except(oldList).First();

            app.Contacts.AddContactToGroup(contact, group);

            List<ContactData> newList = group.GetContacts();

            oldList.Add(contact);
            oldList.Sort();
            newList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }
}
