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

        /// <summary>
        /// Elements for "Save Trip" TestCase8
        /// </summary>
        public static IWebElement ContinueBtn => DriverFactory.Driver.FindElement(By.XPath("//span[(contains(text(), 'Continue'))]"));
        public static IWebElement SelectRaceBtn => DriverFactory.Driver.FindElement(By.XPath("//button[@id='continue']"));
        public static IWebElement SaveTripBtn => DriverFactory.Driver.FindElement(By.XPath("//button[@class='core-btn save-btn core-btn-wrap']"));
        public static IWebElement ChooseRaceBtn => DriverFactory.Driver.FindElement(By.XPath("//div[@class='flight-header__min-price']"));

        /// <summary>
        /// Elements for "Lowest Fare" TestCase3
        /// </summary>
        public static List<IWebElement> CalendarPrices => DriverFactory.Driver.FindElements(By.ClassName("calendar-price")).ToList();
        public static IWebElement ViewByMonthBtn => DriverFactory.Driver.FindElement(By.XPath("//span[(contains(text(), 'View by month'))]"));

        /// <summary>
        /// Methods for TestCase3
        /// </summary>
        public static void ClickViewByMonth()
        {
            ViewByMonthBtn.Click();
        }

        public static double GetPriceOfDayLabeledLowestFare()
        {
            var dateOdElementWithLowestFare = DriverFactory.Driver.FindElement(By.XPath(LowestFareXPath));
            return PriceParser.ParsePrice(dateOdElementWithLowestFare.Text);
        }

        /// <summary>
        /// Methods for TestCase8
        /// </summary>
        public static void ClickContinue()
        {
            ContinueBtn.Click();
        }

        public static void SelectPrice()
        {
            SelectRaceBtn.Click();
        }

        public static void SelectPossibleRace()
        {
            ChooseRaceBtn.Click();
        }

        public static void SaveTrip()
        {
            SaveTripBtn.Click();
        }
    }
}