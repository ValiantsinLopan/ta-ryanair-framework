using Framework.Webdriver;
using OpenQA.Selenium;

namespace Framework.UI.Pages
{
    public class MainPage
    {
        public const string Url = "https://www.ryanair.com/gb/en/";
        public static IWebElement CheapFlightBtn => DriverFactory.Driver.FindElement(By.XPath("//*[@class='farefinder-card ']"));
        public IWebElement ContinueButton => DriverFactory.Driver.FindElement(By.XPath("//*[@class='core-input ng-pristine ng-valid ng-not-empty ng-touched']"));
        public static IWebElement RecommendedBtn => DriverFactory.Driver.FindElement(By.XPath("//span[@class='Recommended ']"));

        public static void Open()
        {
            DriverFactory.Driver.Navigate().GoToUrl(Url);
        }

        public static void OpenCheapFlight()
        {
            CheapFlightBtn.Click();
        }

        public static void GoToRecommended()
        {
            RecommendedBtn.Click();
        }
    }
}
