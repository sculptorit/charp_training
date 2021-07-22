using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Reflection;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class AccountCreationTests : TestBase
    {
       [TestFixtureSetUp]

        public void setUpConfig()
        {
            app.Ftp.BackupFile("/config_inc.php");
            string currentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string myConfigPath = Path.Combine(currentDirectory, "config_inc.php");
            using (Stream localFile = File.OpenRead(myConfigPath))
            {
                app.Ftp.Upload("/config_inc.php", localFile);
            }
        }

        [Test]
        public void TestAccountRegistration()
        {
            AccountData account = new AccountData()
            {
                Username = "testuserrand6",
                Password = "password",
                Email = "testuserrand6@localhost.localdomain"
            };

            List<AccountData> accounts = app.Admin.GetAllAccounts();
            AccountData existingAccount = accounts.Find(x => x.Username == account.Username);

            if (existingAccount != null)
            {
                app.Admin.DeleteAccount(existingAccount);
            }

            app.Registration.Register(account);   
        }

        [TestFixtureTearDown]

        public void restoreConfig()
        {
            app.Ftp.RestoreBackupFile("/config_defaults_inc.php");
        }
    }
}
