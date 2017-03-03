using Framework.BusinessObjects;
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
            MainPage.Open();
        }

        public void ClickFlightsFrom(string countryName)
        {
            mainPage.FlightsFrom.Click();
            mainPage.FlightsFrom.SendKeys(countryName);
        }

        public void DeserializeCountries()
        {

        }

        public bool AirportsIsDisplayed(List<Airport> airports)
        {
            bool checker = true;

            foreach (Airport currentAirport in airports)
            {
                checker = mainPage.GetAirportName(currentAirport.AirportName).Displayed;
            }

            return checker;
        }

    }
}
