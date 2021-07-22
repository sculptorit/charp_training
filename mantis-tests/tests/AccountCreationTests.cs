using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class AccountCreationTests : TestBase
    {
       /* [TestFixtureSetUp]

        public void setUpConfig()
        {
            app.Ftp.BackupFile("/config_inc.php");
            using (Stream localFile = File.Open("/config_inc.php", FileMode.Open))
            {
                app.Ftp.Upload(" / config_inc.php", null);
            }
        }

        [Test]
        public void TestAccountRegistration()
        {
            AccountData account = new AccountData()
            {
                Username = "testuser",
                Password = "password",
                Email = "testuser@localhost.localdomain"
            };

            app.Registration.Register(account);   
        }

        [TestFixtureTearDown]

        public void restoreConfig()
        {
            app.Ftp.RestoreBackupFile("/config_defaults_inc.php");
        }*/
    }
}
