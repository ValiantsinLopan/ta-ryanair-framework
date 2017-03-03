using Framework.Webdriver;
using Framework.UI.Elements;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Interactions;


namespace Framework.UI.Pages
{
    public class MainPage
    {
        public const string Url = "https://www.ryanair.com/gb/en/";
        LogInForm LoginForm = new LogInForm();

        public IWebElement ContinueButton => DriverFactory.Driver.FindElement(By.XPath("//*[@class='core-btn-primary core-btn-block core-btn-big']"));
        public IWebElement AirportSelectorFrom => DriverFactory.Driver.FindElement(By.XPath("//*[@id='label-airport-selector-from']"));
        public IWebElement AirportSelectorTo => DriverFactory.Driver.FindElement(By.XPath(".//*[@id='label-airport-selector-to']"));
        public IWebElement FromInput => DriverFactory.Driver.FindElement(By.XPath(".//*[@class='col-departure-airport']//div[@class='disabled-wrap']/input"));
        public IWebElement ToInput => DriverFactory.Driver.FindElement(By.XPath("//*[@class='col-destination-airport']//div[@class='disabled-wrap']/input"));
        public IWebElement LeavingDateInput => DriverFactory.Driver.FindElement(By.XPath(".//*[@class='container-from']//div[@class='disabled-wrap date-input']/input[1]"));
        public IWebElement ArrivalDateInput => DriverFactory.Driver.FindElement(By.XPath("//*[@class='container-to']//div[@class='disabled-wrap date-input']/input[1]"));

        public static IWebElement CheapFlightBtn => DriverFactory.Driver.FindElement(By.XPath("//*[@class='farefinder-card ']"));
        
        public IWebElement LogInButton => DriverFactory.Driver.FindElement(By.XPath("//*[@id='myryanair-auth-login']"));
        
        public const string SearchContainerXPath = "//div[@id='search-container']";

        public IWebElement FlightsFrom => DriverFactory.Driver.FindElement(By.XPath(".//*[@class='col-departure-airport']//div[@class='disabled-wrap']/input"));

        public static void Open()
        {
            DriverFactory.Driver.Navigate().GoToUrl(Url);
        }
        public void Login(string login,string password)
        {
            LogInButton.Click();
            LoginForm.LogInRyanair(login,password);
        }

        public void SelectDepatureDestination(string depature, string destination)
        {
            AirportSelectorFrom.Click();
            FromInput.SendKeys(depature);
            AirportSelectorTo.Click();
            ToInput.SendKeys(destination);
            ContinueButton.Click();
        }

        public void SelectLeavingArrivalDate(string leavingDay, string arrivalDay)
        {
            ContinueButton.Click();
            LeavingDateInput.SendKeys(leavingDay);
            ArrivalDateInput.SendKeys(arrivalDay);
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
