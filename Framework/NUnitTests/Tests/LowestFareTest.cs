using System;
using Framework.Steps;
using Framework.UI.Pages;
using Framework.Webdriver;
using NUnit.Framework;

namespace NUnitTests.Tests
{
    [TestFixture, Parallelizable(ParallelScope.Fixtures)]
    public class LowestFareTest : BaseTest
    {

        [SetUp]
        public void SetUp()
        {
            DriverFactory.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
        }

        [Test]
        public void LowestFare()
        {
            LowestFareSteps.GoToMainPage();
            MainPage.OpenCheapFlight();
            CheapFlightPage.ClickViewByMonth();
            LowestFareSteps.CheckIfLowestFairCompliesTheLowestPrice();
        }
    }
}
