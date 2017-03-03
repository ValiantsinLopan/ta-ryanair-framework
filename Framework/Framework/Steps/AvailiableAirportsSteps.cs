using Framework.UI.Pages;
using Framework.Webdriver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Steps
{
   public class AvailiableAirportsSteps
    {
        public MainPage mainPage = new MainPage();

        public void Open()
        {
            mainPage.Open(); 
        }

        public void ClickFlightsFrom()
        {
            mainPage.FlightsFrom.Click();
            mainPage.FlightsFrom.SendKeys("Ireland");
        }

        public void DeserializeCountries()
        {

        }

        public bool AirportsIsDisplayed(string nameOfAirport)
        {
            return mainPage.GetAirportName(nameOfAirport).Displayed;
        }

    }
}
