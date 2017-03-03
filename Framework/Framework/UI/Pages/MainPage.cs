using Framework.Webdriver;
using OpenQA.Selenium;

namespace Framework.UI.Pages
{
    public class MainPage
    {
        public const string Url = "https://www.ryanair.com/gb/en/";
        public static IWebElement CheapFlightBtn => DriverFactory.Driver.FindElement(By.XPath("//*[@class='farefinder-card ']"));
        public IWebElement ContinueButton => DriverFactory.Driver.FindElement(By.XPath("//*[@class='core-input ng-pristine ng-valid ng-not-empty ng-touched']"));
        public IWebElement LeavingDateInput => DriverFactory.Driver.FindElement(By.XPath(".//*[@class='container-from']//div[@class='disabled-wrap date-input']/input[1]"));
        public IWebElement ArrivalDateInput => DriverFactory.Driver.FindElement(By.XPath("//*[@class='container-to']//div[@class='disabled-wrap date-input']/input[1]"));

        public static void Open()
        {
            DriverFactory.Driver.Navigate().GoToUrl(Url);
        }

        public static void OpenCheapFlight()
        {
            CheapFlightBtn.Click();
        }

        public void SelectLeavingArrivalDate(string leavingDay, string arrivalDay)
        {
            ContinueButton.Click();
            LeavingDateInput.SendKeys(leavingDay);
            ArrivalDateInput.SendKeys(arrivalDay);
        }
    }
}
