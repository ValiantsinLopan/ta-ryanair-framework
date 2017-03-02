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
            LowestFareSteps.GoToMainPage();
            MainPage.OpenCheapFlight();
            LowestFareSteps.CheckIfLowestFairCompliesTheLowestPrice();
        }
    }
}
