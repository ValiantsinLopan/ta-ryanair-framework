using System;
using Framework.Webdriver;

namespace Framework.Steps
{
    public class Steps
    {
        
        public string LogInWithFacebook()
        {
            UI.Pages.LogInPage loginPage = new UI.Pages.LogInPage();
            loginPage.Open();
            loginPage.LogInViaFacebook();
            return loginPage.GetLoggedInFacebookUserName();
        }

        public string LogInWithGoogle()
        {
            UI.Pages.LogInPage loginPage = new UI.Pages.LogInPage();
            loginPage.Open();
            loginPage.LogInViaGoogle();
            return loginPage.GetLoggedInGoogleUserName();
        }
    }
}
