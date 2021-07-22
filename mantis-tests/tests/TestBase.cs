using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using NUnit.Framework;
using System.IO;

namespace mantis_tests
{
    public class TestBase
    {
        public static bool PERFORM_LONG_UI_CHECKS = false;

        protected AppManager app;

        [TestFixtureSetUp]
        public void SetupAppManager()
        {
            app = AppManager.GetInstance();
        }

        public static Random rnd = new Random();

        public static string GenerateRandomNumber(int min, int max)
        {
            int value = rnd.Next(min, max);

            return value.ToString();
        }

        public static string GenerateRandomString(int max)
        {
            int l = Convert.ToInt32(rnd.NextDouble() * max);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < l; i++)
            {
                builder.Append(Convert.ToChar(32 + Convert.ToInt32(rnd.NextDouble() * 65)));
            }
            return builder.ToString();
        }

        [TestFixtureTearDown]
        public void Logout()
        {
            app.Auth.Logout();
        }
    }
}
