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
    public class SaveTripSteps
    {
        public static MyTripsPage myTripsPage = new MyTripsPage();
        
        public static void NavigateToSavedTrips()
        {
            myTripsPage.NavigateToSavedTrips();
        }

        public static int CheckNumberOfNewSavedTrip()
        {
            return myTripsPage.GetNumberOfSavedTrips();
        }

        public static void GoToMainPage()
        {
            MainPage.Open();
        }
    }
}
