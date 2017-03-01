using Framework.UI.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using Framework.Webdriver;

namespace Framework.Steps
{
    public class CheckFlyOutFlyInDateSteps
    {
        MainPage MainPage = new MainPage();
        

        public void OpenMainPage()
        {
            MainPage.Open();
        }

        public void SelectFlight(string depature, string destination, string leavingDay, string arrivalDay )
        {
            MainPage.SelectDepatureDestination(depature,destination);
            MainPage.SelectLeavingArrivalDate(leavingDay, arrivalDay);
            MainPage.ContinueButton.Click();
        }
        
    }
}
