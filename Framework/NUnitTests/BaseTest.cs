using Framework.Config;
using Framework.Webdriver;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    [TestFixture]
    public class BaseTest
    {
        
        [OneTimeSetUp]
        public void BaseFixtureSetUp()
        {
            DriverFactory.InitDriver(Configuration.CurrentBrowserName, Configuration.ChromeBinPath);
        }

                [OneTimeTearDown]
        public void BaseFixtureTearDown()
        {
            DriverFactory.CleanupDriver();
        }

    }
}
