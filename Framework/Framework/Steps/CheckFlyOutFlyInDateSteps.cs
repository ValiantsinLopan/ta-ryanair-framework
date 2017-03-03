using Framework.UI.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using Framework.Webdriver;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace Framework.Steps
{
    public class CheckFlyOutFlyInDateSteps
    {
        MainPage MainPage = new MainPage();
        BookingFlightPage BookingPage = new BookingFlightPage();

        public void OpenMainPage()
        {
            MainPage.Open();
        }
        public void Login(string login, string password)
        {
            MainPage.Login(login,password);
        }

        public void SelectFlight(string depature, string destination, string leavingDay, string arrivalDay )
        {
            MainPage.SelectDepatureDestination(depature,destination);
            MainPage.SelectLeavingArrivalDate(leavingDay, arrivalDay);
            MainPage.ContinueButton.Click();
            MainPage.ContinueButton.Click();
        }
        public void SelectTickets()
        { 
            
            BookingPage.SelectRegularTicketTo();

            //BookingPage.SelectRegularTicketBack();
        }
        public bool IsPossibleSelectFirstBackTicket()
        {
            return BookingPage.IsFirstBackTicketAvailable();
        }
    }
}
