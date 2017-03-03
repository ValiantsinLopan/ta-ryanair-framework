using System;
using Framework.Steps;
using Framework.UI.Pages;
using Framework.Webdriver;
using NUnit.Framework;


namespace NUnitTests
{
    [TestFixture, Parallelizable(ParallelScope.Fixtures)]
    public class SaveTripTest : BaseTest
    {

        [Test]
        public void SaveTrip()
        {
            DriverFactory.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            SaveTripSteps.GoToMainPage();
            //LogIn
            SaveTripSteps.NavigateToSavedTrips();
            var startNumberOfSavedTrips = SaveTripSteps.CheckNumberOfNewSavedTrip();
            SaveTripSteps.GoToMainPage();
            MainPage.GoToRecommended();
            MainPage.OpenCheapFlight();
            CheapFlightPage.SelectPossibleRace();
            CheapFlightPage.SelectPrice();
            CheapFlightPage.ClickContinue();
            CheapFlightPage.SaveTrip();
            SaveTripSteps.NavigateToSavedTrips();
            var finalNumberOfSavedTrips = SaveTripSteps.CheckNumberOfNewSavedTrip();
            Assert.AreEqual(startNumberOfSavedTrips+1, finalNumberOfSavedTrips);
        }
    }
}
