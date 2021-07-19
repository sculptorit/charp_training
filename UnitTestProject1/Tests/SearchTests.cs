using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AddressBookWebTests
{
    [TestFixture]
    public class SearchTests : AuthTestBase
    {
        [Test]
        public void TestSearch()
        {
            int contactsCount = app.Contacts.GetContactList().Count;

            int searchContactsResult = app.Contacts.GetNumberOfSearchResults();

            Assert.AreEqual(searchContactsResult, contactsCount);
            System.Console.Out.Write(app.Contacts.GetNumberOfSearchResults());
        }

    }
}
