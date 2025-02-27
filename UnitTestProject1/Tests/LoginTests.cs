﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AddressBookWebTests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        public void LoginWithValidCreds()
        {
            //preparation
            app.Auth.Logout();

            //action - login
            AccountData account = new AccountData("admin", "secret");
            app.Auth.Login(account);

            //verification
            Assert.IsTrue(app.Auth.IsLoggedIn(account));
        }

        [Test]
        public void LoginWithInvalidCreds()
        {
            //preparation
            app.Auth.Logout();

            //action - login
            AccountData account = new AccountData("admin", "123456");
            app.Auth.Login(account);

            //verification
            Assert.IsFalse(app.Auth.IsLoggedIn(account));
        }
    }
}
