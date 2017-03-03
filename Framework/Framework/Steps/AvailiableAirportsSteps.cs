using Framework.BusinessObjects;
using Framework.UI.Pages;
using System.Collections.Generic;

namespace Framework.Steps
{
    public class AvailiableAirportsSteps
    {
        public MainPage mainPage = new MainPage();

        public void Open()
        {
            MainPage.Open();
        }

        /// <summary>
        /// Click on part of form "flights from"
        /// </summary>
        public void ClickFlightsFrom()
        {
            mainPage.FromInput.Clear();
            mainPage.FromInput.Click();
        }

        /// <summary>
        /// Enter name of country in form "flights from"
        /// </summary>
        public void EnterCountryName(string countryName)
        {
            mainPage.FromInput.SendKeys(countryName);
        }

        /// <summary>
        /// Gets countries and airports from xml-file
        /// </summary>
        /// <returns> AllCountries with countries and airports </returns>
        public AllCountries DeserializeCountries(string path)
        {
            return AllCountries.DeserialiseCountries(path);

        }

        /// <summary>
        /// Check that all airports are displayed
        /// </summary>
        /// <returns> true if all airports is displayed </returns>
        public bool AllAirportsAreDisplayed(List<Airport> airports)
        {
            bool checker = true;
            foreach (Airport currentAirport in airports)
            {
                checker = mainPage.GetAirportName(currentAirport.AirportName).Displayed;
                if (checker == false)
                {
                    break;
                }
            }
            return checker;
        }
    }
}
