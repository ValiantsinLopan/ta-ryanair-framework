using Framework.UI.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Steps
{
    public class PreviousSearchSteps
    {
        public MainPage mainPage = new MainPage();
        public BookingFlightPage bookingPage = new BookingFlightPage();

        public void Open()
        {
            MainPage.Open();
        }

        public void SelectFlight(string depature, string destination, string leavingDay, string arrivalDay)
        {
            mainPage.SelectDepatureDestination(depature, destination);
            mainPage.SelectLeavingArrivalDate(leavingDay, arrivalDay);
            mainPage.ContinueButton.Click();
            mainPage.ContinueButton.Click();
        }

        public void ClickOnFlightField()
        {
            bookingPage.FlightField.Click();
        }
    }
}
