using Framework.Webdriver;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Threading;

namespace Framework.UI.Pages
{
    public class BookingFlightPage
    {
        public IWebElement FirstFlightTo => DriverFactory.Driver.FindElement(By.XPath("//*[@id='outbound']//flights-table-header"));
        public IWebElement FirstFlightBack => DriverFactory.Driver.FindElement(By.XPath("//*[@id='inbound']//flights-table-header"));
        public IWebElement SelectRegularToButton => DriverFactory.Driver.FindElement(By.XPath("//*[@id='outbound']//div[@class='flights-table-fares__fare standard']//button"));
        public IWebElement SelectRegularBackButton => DriverFactory.Driver.FindElement(By.XPath("//*[@id='inbound']//div[@class='flights-table-fares__fare standard']//button"));
        public IWebElement CantSelectFlightMessage => DriverFactory.Driver.FindElement(By.XPath("//*[@id='inbound']//span[@class='flights-table__notice-message']"));
        public IWebElement FlightField => DriverFactory.Driver.FindElement(By.XPath("//*[contains(@id, 'flight')]"));

        public void SelectRegularTicketTo()
        {
            FirstFlightTo.Click();
            Thread.Sleep(3000);
            SelectRegularToButton.Click();

        }
        public void SelectRegularTicketBack()
        {
            FirstFlightBack.Click();
            Thread.Sleep(3000);
            SelectRegularBackButton.Click();
        }

        public bool IsFirstBackTicketAvailable()
        {
            return CantSelectFlightMessage.Displayed ? false : true;
        }
    }
}
