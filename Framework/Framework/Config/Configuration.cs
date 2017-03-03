using Framework.Resources;
using System;
using System.Collections;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Reflection;
using OpenQA.Selenium.Remote;

namespace Framework.Config
{
    public static class Configuration
    {
        private const string ConfigFilePath = "Framework/app.config";

        private static System.Configuration.Configuration _config;
        private static System.Configuration.Configuration Config => _config ?? (_config = LoadConfig());

        /// <summary>
        /// Loads configuration from file
        /// </summary>
        /// <returns>loaded and parsed conf file</returns>
        private static System.Configuration.Configuration LoadConfig()
        {
            var configMap = new ExeConfigurationFileMap
            {
                ExeConfigFilename = $"{SolutionPath}/{ConfigFilePath}"
            };
            return ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
        }

        /// <summary>
        /// Get full solution path form currently called assembly
        /// </summary>
        /// <returns>full solution path</returns>
        public static string SolutionPath => Uri.UnescapeDataString(new DirectoryInfo(new Uri(Assembly.GetCallingAssembly().GetName().CodeBase).AbsolutePath).Parent.Parent.Parent.Parent.FullName);

        public static string CurrentBrowserName => Config.AppSettings.Settings["browser.current"].Value;

        public static string ChromeBinPath => $"{SolutionPath}/{DriversPaths.ChromeDriver}";
        public static string FirefoxBinPath => $"{SolutionPath}/{DriversPaths.FirefoxDriver}";
        public static string EdgeBinPath => $"{SolutionPath}/{DriversPaths.EdgeDriver}";
        public static string IeBinPath => $"{SolutionPath}/{DriversPaths.IEDriver}";

        /// <summary>
        /// Loads all specified capabilities from config file
        /// </summary>
        /// <returns>loaded capabilities</returns>
        public static DesiredCapabilities LoadBrowserStackCapabilities()
        {
            var capabilities = new DesiredCapabilities();

            var set = BrowserStack.ResourceManager.GetResourceSet(CultureInfo.InvariantCulture, true, true);
            foreach (DictionaryEntry variable in set)
            {
                try
                {
                    var capabilityKey = (string)variable.Value;
                    var capabilityValue = Config.AppSettings.Settings[capabilityKey].Value;
                    capabilities.SetCapability(capabilityKey, capabilityValue);
                }
                catch (NullReferenceException) { }
            }

            return capabilities;
        }
    }
}
