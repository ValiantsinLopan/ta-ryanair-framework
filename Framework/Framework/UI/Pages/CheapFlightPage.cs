using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using Framework.Webdriver;
using Framework.Tools;

namespace Framework.UI.Pages
{
    public class CheapFlightPage
    {
        private const string LowestFareXPath = "//div[@class='calendar-content']//span[(contains(text(), 'Lowest Fare'))]//ancestor::*[position()=2]//p[@class='calendar-price']";

        public static List<IWebElement> CalendarPrices => DriverFactory.Driver.FindElements(By.ClassName("calendar-price")).ToList();
        public static IWebElement ViewByMonthBtn => DriverFactory.Driver.FindElement(By.XPath("//span[(contains(text(), 'View by month'))]"));

        public static void ClickViewByMonth()
        {
            ViewByMonthBtn.Click();
        }

        public static double GetPriceOfDayLabeledLowestFare()
        {
            IWebElement dateOdElementWithLowestFare = DriverFactory.Driver.FindElement(By.XPath(LowestFareXPath));
            return PriceParser.ParsePrice(dateOdElementWithLowestFare.Text);
        }
    }
}
