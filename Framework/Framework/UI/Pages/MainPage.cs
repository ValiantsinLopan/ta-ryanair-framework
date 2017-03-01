using Framework.Webdriver;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;


namespace Framework.UI.Pages
{
    public class MainPage
    {
        public const string Url = "https://www.ryanair.com/gb/en/";

        public IWebElement ContinueButton => DriverFactory.Driver.FindElement(By.XPath("//*[@id='search-container']/div[1]/div/form/div[4]/button[2]"));
        public IWebElement AirportSelectorFrom => DriverFactory.Driver.FindElement(By.XPath("//*[@id='label-airport-selector-from']"));
        public IWebElement AirportSelectorTo => DriverFactory.Driver.FindElement(By.XPath(".//*[@id='label-airport-selector-to']"));
        public IWebElement FromInput => DriverFactory.Driver.FindElement(By.XPath(".//*[@id='search-container']/div[1]/div/form/div[2]/div/div/div[1]/div[2]/div[2]/div/div[1]/input"));
        public IWebElement ToInput => DriverFactory.Driver.FindElement(By.XPath("//*[@id='search-container']/div[1]/div/form/div[2]/div/div/div[2]/div[2]/div[2]/div/div[1]/input"));
        public IWebElement LeavingDateInput => DriverFactory.Driver.FindElement(By.XPath("//*[@id='row-dates-pax']/div[1]/div/div[1]/div/div[2]/div[2]/div/input[1]"));
        public IWebElement ArrivalDateInput => DriverFactory.Driver.FindElement(By.XPath("//*[@id='row-dates-pax']/div[1]/div/div[2]/div/div[2]/div[2]/div/input[1]"));

        //Actions action = new Actions(DriverFactory.Driver);

        public void Open()
        {
            DriverFactory.Driver.Navigate().GoToUrl(Url);
        }

        public void SelectDepatureDestination(string depature, string destination)
        {
            AirportSelectorFrom.Click();
            FromInput.SendKeys(depature);
            AirportSelectorTo.Click();
            ToInput.SendKeys(destination);
            DriverFactory.Driver.FindElement(By.XPath($"//div[@id='search-container']//*[text()=\"{destination}\"]")).Click();

        }

        public void SelectLeavingArrivalDate(string leavingDay, string arrivalDay)
        {
            LeavingDateInput.SendKeys(leavingDay);
           // action.SendKeys("Enter");
            ArrivalDateInput.SendKeys(arrivalDay);
            //action.SendKeys("Enter");
        }
    }
}
