using Framework.Webdriver;
using OpenQA.Selenium;

namespace Framework.UI.Pages
{
    public class BookingFlightPage
    {
        public IWebElement FirstFlightTo => DriverFactory.Driver.FindElement(By.XPath("//*[@id='outbound']//div[@class='ranimate - flights - table flights - table__flight first']"));
        public IWebElement FirstFlightBack => DriverFactory.Driver.FindElement(By.XPath("//*[@id='inbound']//div[@class='ranimate - flights - table flights - table__flight first']"));
    }
}
