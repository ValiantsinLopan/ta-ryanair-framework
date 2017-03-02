using Framework.Tools;
using Framework.UI.Pages;
using Framework.Webdriver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Steps
{
    public class LowestFareSteps
    {
        static CheapFlightPage cheapFlightPage;
        static List<int> indexesOfEmptyDays;
       
        public static void GoToMainPage()
        {
            MainPage.Open();
        }

        /// <summary>
        /// Gets all days wich have any price higher than zero
        /// </summary>
        /// <returns> List<IWebElement> of prices of these days </returns>
        public static List<IWebElement> GetDaysWithPrices(List<IWebElement> allDays)
        {
            var counter = 0;
            indexesOfEmptyDays = new List<int>();
            foreach (var dayPrice in allDays.ToList())
            {
                counter++;
                if (PriceParser.ParsePrice(dayPrice.Text) == 0)
                {
                    indexesOfEmptyDays.Add(counter);
                    allDays.Remove(dayPrice);
                }
            }
            return allDays;
        }
        

        /// <summary>
        /// Finds all days from the calendar which have the Lowest Price
        /// </summary>
        /// <returns> List<IWebElement> of the same lowest prices </returns>
        private static List<IWebElement> FindDaysWithLowestPrice(List<IWebElement> calendar, double lowestPrice)
        {
            foreach(var dayPrice in calendar)
            {
                if (PriceParser.ParsePrice(dayPrice.Text) != lowestPrice)
                {
                    calendar.Remove(dayPrice);
                }
            }           
            return calendar;
        }

        public static bool CheckIfLowestFairCompliesTheLowestPrice()
        {
            var lowestFarePrice = CheapFlightPage.GetPriceOfDayLabeledLowestFare();
            var minPrice = GetMinPrice();
            if (lowestFarePrice.Equals(minPrice))
            {
                return true;
            }
            else return false;
        }

        /// <summary>
        /// Finds the lowest price of the month
        /// </summary>
        /// <returns> double, minPrice </returns>
        public static double GetMinPrice()
        {
            List<IWebElement> allPrices = CheapFlightPage.CalendarPrices;
            var validListOfPrices = GetDaysWithPrices(allPrices);
            var minPrice = PriceParser.ParsePrice(validListOfPrices[0].Text);
            IWebElement lowestPrice = null;
            foreach (var pricePerOneDay in validListOfPrices)
            {
                if (PriceParser.ParsePrice(pricePerOneDay.Text) < minPrice)
                {
                    lowestPrice = pricePerOneDay;
                    minPrice = PriceParser.ParsePrice(lowestPrice.Text);
                }
            }
            return minPrice;
        }
    }
}
