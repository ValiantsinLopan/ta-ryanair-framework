using Framework.Webdriver;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Framework.UI.Pages
{
    public class MainPage
    {
        public const string Url = "https://www.ryanair.com/gb/en/";
        public static IWebElement CheapFlightBtn => DriverFactory.Driver.FindElement(By.XPath("//*[@class='farefinder-card ']"));

        [FindsBy(How = How.XPath, Using = "//*[@class='core-input ng-pristine ng-valid ng-not-empty ng-touched']")]
        public IWebElement ContinueButton;

        [FindsBy(How = How.XPath, Using = ".//*[@id='search-container']/div[1]/div/form/div[2]/div/div/div[1]/div[2]/div[2]/div/div[1]/input")]
        public IWebElement FlightsFrom;
        
        public const string  SearchContainerXPath = "//div[@id='search-container']";

        public static void Open()
        {
            DriverFactory.Driver.Navigate().GoToUrl(Url);
        }

        public static void OpenCheapFlight()
        {
            CheapFlightBtn.Click();
        }

        public IWebElement GetAirportName(string nameOfAirport)
        {
            return DriverFactory.Driver.FindElement(By.XPath($"{SearchContainerXPath}//*[text()=\"{nameOfAirport}\"]"));        
        }

    }
}
