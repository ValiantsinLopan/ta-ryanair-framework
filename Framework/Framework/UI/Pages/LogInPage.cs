using Framework.Webdriver;
using OpenQA.Selenium;

namespace Framework.UI.Pages
{
    public class LogInPage : MainPage
    {

        public IWebElement LogInWithFacebookButton => DriverFactory.Driver.FindElement(By.XPath(".//*[@id='ngdialog1']/div[2]/signup-home-form/div/div/div[2]/div/dialog-body/div[2]/signup-home-tabs/div[2]/div/div/div/social-login/div/button[1]"));
        public IWebElement LogInWithGoogleButton => DriverFactory.Driver.FindElement(By.XPath(".//*[@id='ngdialog1']/div[2]/signup-home-form/div/div/div[2]/div/dialog-body/div[2]/signup-home-tabs/div[2]/div/div/div/social-login/div/button[2]"));
        public IWebElement LoggedInUserButton => DriverFactory.Driver.FindElement(By.XPath(".//*[@id='menu-container']/ul[2]/li[1]/a/span"));

        public void LogInViaFacebook()
        {
            LogInPage mainPage = new LogInPage();
            mainPage.Open();

            LogInButton.Click();
            LogInWithFacebookButton.Click();
        }

        public string GetLoggedInFacebookUserName()
        {
            return LoggedInUserButton.Text;
        }

        public void LogInViaGoogle()
        {
            LogInPage mainPage = new LogInPage();
            mainPage.Open();

            LogInButton.Click();
            LogInWithGoogleButton.Click();
        }

        public string GetLoggedInGoogleUserName()
        {
            return LoggedInUserButton.Text;
        }
    }
}
