using Framework.Webdriver;
using OpenQA.Selenium;

namespace Framework.UI.Pages
{
    public class MainPage
    {
        public const string Url = "https://www.ryanair.com/gb/en/";
        static public IWebElement CheapFlightBtn => DriverFactory.Driver.FindElement(By.ClassName("farefinder-card "));
        public IWebElement ContinueButton => DriverFactory.Driver.FindElement(By.XPath("//*[@class='core-input ng-pristine ng-valid ng-not-empty ng-touched']"));

        public static void Open()
        {
            DriverFactory.Driver.Navigate().GoToUrl(Url);
        }

        public static void OpenCheapFlight()
        {
            CheapFlightBtn.Click();
        }
    }
}
