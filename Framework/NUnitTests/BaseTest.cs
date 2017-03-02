using Framework.Config;
using Framework.Webdriver;
using NUnit.Framework;
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
