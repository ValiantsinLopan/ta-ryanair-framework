using System;
using Framework.Steps;
using Framework.UI.Pages;
using Framework.Webdriver;
using NUnit.Framework;

namespace NUnitTests
{
    [TestFixture, Parallelizable(ParallelScope.Fixtures)]
    public class LowestFareTest : BaseTest
    {
        [Test]
        public void LowestFare()
        {
            DriverFactory.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            LowestFareSteps.GoToMainPage();
            MainPage.OpenCheapFlight();
            CheapFlightPage.ClickViewByMonth();
            Assert.True(LowestFareSteps.CheckIfLowestFairCompliesTheLowestPrice());
        }
    }
}
