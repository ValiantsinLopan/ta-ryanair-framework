using Framework.Webdriver;
using OpenQA.Selenium;

namespace Framework.UI.Pages
{
    public class MainPage
    {
        public const string Url = "https://www.ryanair.com/gb/en/";
        public const string SearchContainerXPath = "//div[@id='search-container']";

        public static IWebElement CheapFlightBtn => DriverFactory.Driver.FindElement(By.XPath("//*[@class='farefinder-card ']"));
        public IWebElement ContinueButton => DriverFactory.Driver.FindElement(By.XPath("//*[@class='core-input ng-pristine ng-valid ng-not-empty ng-touched']"));
        public IWebElement FlightsFrom => DriverFactory.Driver.FindElement(By.XPath(".//*[@id='search-container']/div[1]/div/form/div[2]/div/div/div[1]/div[2]/div[2]/div/div[1]/input"));

        public static void Open()
        {
            DriverFactory.Driver.Navigate().GoToUrl(Url);
        }

        public static void OpenCheapFlight()
        {
            CheapFlightBtn.Click();
        }

        /// <summary>
        /// Finds elements with name of airport
        /// </summary>
        /// <returns> element with name of airport </returns>
        public IWebElement GetAirportName(string nameOfAirport)
        {
            return DriverFactory.Driver.FindElement(By.XPath($"{SearchContainerXPath}//*[text()=\"{nameOfAirport}\"]"));
        }

    }
}
