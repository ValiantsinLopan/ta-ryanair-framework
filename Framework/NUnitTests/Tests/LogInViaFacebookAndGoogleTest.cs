using Framework.Config;
using Framework.Webdriver;
using NUnit.Framework;

using Framework.Steps;
namespace NUnitTests.Tests
{
    [TestFixture]
    class LogInViaFacebookAndGoogleTest:BaseTest
    {
        private Steps steps = new Steps();
        private const string FACEBOOK_USERNAME ="John";
        private const string GOOGLE_USERNAME = "John";

        [Test]
        public void OneLogInViaFacebook()
        {
            Assert.Equals(FACEBOOK_USERNAME, steps.LogInWithFacebook);
        }

        [Test]
        public void OneLohInViaGoogle()
        {
            Assert.Equals(GOOGLE_USERNAME, steps.LogInWithGoogle());
        }
    }
}
