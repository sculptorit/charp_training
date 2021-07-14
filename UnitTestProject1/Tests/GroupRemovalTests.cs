using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AddressBookWebTests
{
    [TestFixture]
    public class GroupRemovalTest : AuthTestBase
    {
        [Test]
        public void TheGroupRemovalTest()
        {
            GroupData group = new GroupData("TestGroupName");
            app.Groups.Remove(1, group);
        }
    }
}
