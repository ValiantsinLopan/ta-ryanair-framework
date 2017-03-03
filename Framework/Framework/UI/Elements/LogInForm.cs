using Framework.Webdriver;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Threading;

namespace Framework.UI.Elements
{
    public class LogInForm
    {
        public IWebElement LoginInput => DriverFactory.Driver.FindElement(By.XPath("//*[@class='form-field']//input"));
        public IWebElement PasswordInput => DriverFactory.Driver.FindElement(By.XPath("//*[@class='form-field password']//input"));
        public IWebElement LogInButton => DriverFactory.Driver.FindElement(By.XPath("//*[@class='modal-form-group']//button"));

        public void LogInRyanair(string login, string password)
        {
            LoginInput.SendKeys(login);
            PasswordInput.SendKeys(password);
            LogInButton.Click();
        }
    }
}
