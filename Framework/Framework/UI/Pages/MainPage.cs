﻿using Framework.Webdriver;
using OpenQA.Selenium;

namespace Framework.UI.Pages
{
    public class MainPage
    {
        public const string Url = "https://www.ryanair.com/gb/en/";
        public IWebElement ContinueButton => DriverFactory.Driver.FindElement(By.XPath("//*[@class='core-input ng-pristine ng-valid ng-not-empty ng-touched']"));

        public void Open()
        {
            DriverFactory.Driver.Navigate().GoToUrl(Url);
        }

    }
}