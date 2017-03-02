using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCase3
{
    public class CheapFlightPage
    {
        By viewByMonthBtn = By.XPath("//span[(contains(text(), 'View by month'))]");
        By calendarPrices = By.ClassName("calendar-price");
        By calendarDates = By.ClassName("day-label");
        static By lowestFareLbl = By.XPath("//div[@class='calendar-content']//span[(contains(text(), 'Lowest Fare'))]");
                
        public IWebElement GetViewByMonthBtn()
        {
            IWebElement element = WebDriver.Driver.FindElement(viewByMonthBtn);
            return element;
        }

        public List<IWebElement> GetCalendarPrices()
        {            
            try
            {
                List<IWebElement> elements = WebDriver.Driver.FindElements(calendarPrices).ToList();
                return elements;
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nMessage ---\n{0}", ex.Message);
                Console.WriteLine(
                    "\nHelpLink ---\n{0}", ex.HelpLink);
                Console.WriteLine("\nSource ---\n{0}", ex.Source);
                Console.WriteLine(
                    "\nStackTrace ---\n{0}", ex.StackTrace);
                Console.WriteLine(
                    "\nTargetSite ---\n{0}", ex.TargetSite);
            }
            return null;
        }

        public static double GetPriceOfDayLabeledLowestFare()
        {
            try
            {
                IWebElement LowestFare = WebDriver.Driver.FindElement(lowestFareLbl);
                IWebElement dateOdElementWithLowestFare = WebDriver.Driver.FindElement(By.XPath("//div[@class='calendar-content']//span[(contains(text(), 'Lowest Fare'))]//ancestor::*[position()=2]//child::p[@class='calendar-price']"/*$"{lowestFareLbl}//ancestor::*[position()=2]//child::p[@class='calendar-price']"*/));
                return PriceParser.ParsePrice(dateOdElementWithLowestFare.Text);
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nMessage ---\n{0}", ex.Message);
                Console.WriteLine(
                    "\nHelpLink ---\n{0}", ex.HelpLink);
                Console.WriteLine("\nSource ---\n{0}", ex.Source);
                Console.WriteLine(
                    "\nStackTrace ---\n{0}", ex.StackTrace);
                Console.WriteLine(
                    "\nTargetSite ---\n{0}", ex.TargetSite);
            }
            return 0.0;
        } 
    }
}
