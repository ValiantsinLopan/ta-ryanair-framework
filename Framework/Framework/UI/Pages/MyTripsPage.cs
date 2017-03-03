using Framework.Webdriver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.UI.Pages
{
    public class MyTripsPage
    {
        public const string Url = "https://www.ryanair.com/gb/en/mytrips/summary";
        public IWebElement NumberOfSavedTripsFld => DriverFactory.Driver.FindElement(By.XPath("//span[(contains(text(), 'Saved trips '))]//span[@class='value-span']"));

        public void NavigateToSavedTrips()
        {
            DriverFactory.Driver.Navigate().GoToUrl(Url);
        }

        public int GetNumberOfSavedTrips()
        {
            return Int32.Parse(NumberOfSavedTripsFld.Text);
        }
    }
}
