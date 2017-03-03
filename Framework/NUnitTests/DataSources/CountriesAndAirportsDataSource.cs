using Framework.BusinessObjects;
using Framework.Resources;
using Framework.Steps;
using NUnit.Framework;
using System;
using System.Collections;
using System.IO;
using System.Reflection;

namespace NUnitTests.DataSources
{
    class CountriesAndAirportsDataSource
    {
        public static string SolutionPath => Uri.UnescapeDataString(new DirectoryInfo(new Uri(Assembly.GetCallingAssembly().GetName().CodeBase).AbsolutePath).Parent.Parent.Parent.Parent.FullName);
        public static string CountriesPath => $"{SolutionPath}/{TestDataPaths.CountriesAndAirportsPath}";

        /// <summary>
        /// Gets countries with airports
        /// </summary>
        /// <returns> Name of country, list of airports in country </returns>
        public static IEnumerable TestCaseWithCountries()
        {
            AvailiableAirportsSteps steps = new AvailiableAirportsSteps();
            var data = steps.DeserializeCountries(CountriesPath);
            foreach (Country currentCountry in data.Countries)
            {
                yield return new TestCaseData(currentCountry.CountryName, currentCountry.Airports);
            }
        }
    }
}
