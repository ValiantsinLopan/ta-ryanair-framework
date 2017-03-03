using Framework.BusinessObjects;
using Framework.Config;
using Framework.Steps;
using NUnit.Framework;
using System.Collections;

namespace Framework.Resources
{
    public class DataProviders
    {
        /// <summary>
        /// Gets countries with airports
        /// </summary>
        /// <returns> Name of country, list of airports in country </returns>
        public static IEnumerable TestCaseWithCountries()
        {
            AvailiableAirportsSteps steps = new AvailiableAirportsSteps();
            var data = steps.DeserializeCountries(Configuration.CountriesPath);
            foreach (Country currentCountry in data.Countries)
            {
                yield return new TestCaseData(currentCountry.CountryName, currentCountry.Airports);
            }
        }
    }
}

