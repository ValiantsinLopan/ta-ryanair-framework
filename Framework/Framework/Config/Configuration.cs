using Framework.Resources;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Config
{
    public static class Configuration
    {

        /// <summary>
        /// Get full solution path form currently called assembly
        /// </summary>
        /// <returns>full solution path</returns>
        public static string SolutionPath => Uri.UnescapeDataString(new DirectoryInfo(new Uri(Assembly.GetCallingAssembly().GetName().CodeBase).AbsolutePath).Parent.Parent.Parent.Parent.FullName);

        //TODO: getting name from config
        public static string CurrentBrowserName => "chrome";

        public static string ChromeBinPath
        {
            get
            {
                    return $"{SolutionPath}/{DriversPaths.ChromeDriver}";

            }
        }
    }
}
