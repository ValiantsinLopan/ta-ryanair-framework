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

        public static IWebDriver Driver
        {
            get
            {
                IWebDriver driver;
                if (!DriversDictionary.TryGetValue(CurrentTest, out driver))
                {
                    InitDriver();
                }

                return driver;
            }
        }

        public static void InitDriver()
        {
            var driverId = TestContext.CurrentContext.Test.ClassName;
            DriversDictionary.TryAdd(driverId, GetDriverInstance());
            Driver.Manage().Window.Maximize();
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
            return new ChromeDriver(Configuration.ChromeBinPath);
        }

        private static IWebDriver GetFirefoxDriver()
        {
            var service = FirefoxDriverService.CreateDefaultService(Configuration.FirefoxBinPath);
            return new FirefoxDriver(service);
        }

        private static IWebDriver GetEdgeDriver()
        {
            var service = EdgeDriverService.CreateDefaultService(Configuration.EdgeBinPath);
            return new EdgeDriver(service);
        }

        private static IWebDriver GetIeDriver()
        {
            var service = InternetExplorerDriverService.CreateDefaultService(Configuration.IeBinPath);
            return new InternetExplorerDriver(service);
        }

        private static IWebDriver GetRemoteDriver()
        {
            var capabilities = Configuration.LoadBrowserStackCapabilities();
            return new RemoteWebDriver(new Uri(BrowserStack.URL), capabilities);
        }
    }
}
