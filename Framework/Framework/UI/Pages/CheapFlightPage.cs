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
        public static List<IWebElement> CalendarPrices => DriverFactory.Driver.FindElements(By.ClassName("calendar-price")).ToList();
        public IWebElement ViewByMonthBtn => DriverFactory.Driver.FindElement(By.XPath("//span[(contains(text(), 'View by month'))]"));
                        
        public void ClickViewByMonth()
        {
            ViewByMonthBtn.Click();
        }

        public static double GetPriceOfDayLabeledLowestFare()
        {
            IWebElement dateOdElementWithLowestFare = DriverFactory.Driver.FindElement(By.XPath("//div[@class='calendar-content']//span[(contains(text(), 'Lowest Fare'))]//ancestor::*[position()=2]//child::p[@class='calendar-price']"));
            return PriceParser.ParsePrice(dateOdElementWithLowestFare.Text);
        }
    }
}
