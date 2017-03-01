using System;
using System.Collections.Concurrent;
using Framework.Config;
using Framework.Resources;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;

namespace Framework.Webdriver
{
    public static class DriverFactory
    {
        private const string Chrome = "chrome";
        private const string Firefox = "firefox";
        private const string Ie = "ie";
        private const string Edge = "edge";
        private const string Remote = "remote";

        private static readonly ConcurrentDictionary<string, IWebDriver> DriversDictionary = new ConcurrentDictionary<string, IWebDriver>();

        public static void CleanupDriver() { Driver.Quit(); }
        public static IWebDriver Driver => DriversDictionary[CurrentTest];

        public static void InitDriver(string driverName, string driverPath)
        {
            //TODO: implement
            var driverId = TestContext.CurrentContext.Test.ClassName;
            DriversDictionary.TryAdd(driverId, GetDriverInstance());
        }

        private static string CurrentTest => TestContext.CurrentContext.Test.ClassName;

        /// <summary>
        /// Creates driver specified by current test name
        /// </summary>
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
            var service = FirefoxDriverService.CreateDefaultService(Configuration.FirefoxBinPath);
            var driver = new FirefoxDriver(service);
            driver.Manage().Window.Maximize();
            return driver;
        }

        private static IWebDriver GetEdgeDriver()
        {
            var service = EdgeDriverService.CreateDefaultService(Configuration.EdgeBinPath);
            var driver = new EdgeDriver(service);
            driver.Manage().Window.Maximize();
            return driver;
        }

        private static IWebDriver GetIeDriver()
        {
            var service = InternetExplorerDriverService.CreateDefaultService(Configuration.IeBinPath);
            var driver = new InternetExplorerDriver(service);
            driver.Manage().Window.Maximize();
            return driver;
        }

        private static IWebDriver GetRemoteDriver()
        {
            var driver = new RemoteWebDriver(new Uri(BrowserStack.URL), Configuration.LoadBrowserStackCapabilities());
            return driver;
        }
    }
}
