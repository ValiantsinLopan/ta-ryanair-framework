using System;
using System.Collections.Concurrent;
using Framework.Config;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Framework.Webdriver
{
    public static class DriverFactory
    {
        public static void Open()
        {
            Driver.Navigate().GoToUrl("google.com");
        }

        private const string Chrome = "chrome";
        private const string Firefox = "firefox";
        private const string Ie = "ie";
        private const string Edge = "edge";
        private const string Opera = "opera";
        private const string Remote = "remote";

        public static void CleanupDriver() { Driver.Quit(); }

        private static readonly ConcurrentDictionary<string, IWebDriver> DriversDictionary = new ConcurrentDictionary<string, IWebDriver>();

        private static string CurrentTest => TestContext.CurrentContext.Test.ClassName;
        public static IWebDriver Driver => DriversDictionary[CurrentTest];

        public static void InitDriver(string driverName, string driverPath)
        {
            //TODO: implement
            var driverId = TestContext.CurrentContext.Test.ClassName;
            DriversDictionary.TryAdd(driverId, GetDriverInstance());
        }

        /// <summary>
        /// Creates driver specified by driver name
        /// </summary>
        /// <param name="driver">driver name to create</param>
        /// <exception cref="InvalidOperationException">if driver with specified name wasn't found</exception>
        /// <returns></returns>
        private static IWebDriver GetDriverInstance()
        {
            switch (Configuration.CurrentBrowserName)
            {
                case Chrome:
                    {
                        return GetChromeDriver();
                    }
                case Firefox:
                    {
                        return GetFirefoxDriver();
                    }
                case Ie:
                    {
                        return GetIeDriver();
                    }
                case Edge:
                    {
                        return GetEdgeDriver();
                    }
                case Opera:
                    {
                        return GetOperaDriver();
                    }
                case Remote:
                    {
                        return GetRemoteDriver();
                    }
                default:
                    {
                        break;
                    }
            }

            throw new InvalidOperationException("No driver found for '" + Configuration.CurrentBrowserName + "'");
        }

        private static IWebDriver GetChromeDriver()
        {
            var driver = new ChromeDriver(Configuration.ChromeBinPath);
            driver.Manage().Window.Maximize();
            return driver;
        }

        private static IWebDriver GetFirefoxDriver()
        {
            throw new NotImplementedException();
        }

        private static IWebDriver GetEdgeDriver()
        {
            throw new NotImplementedException();
        }

        private static IWebDriver GetIeDriver()
        {
            throw new NotImplementedException();
        }

        private static IWebDriver GetRemoteDriver()
        {
            throw new NotImplementedException();
        }

        private static IWebDriver GetOperaDriver()
        {
            throw new NotImplementedException();
        }
    }
}
