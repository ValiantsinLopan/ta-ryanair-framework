using Framework.BusinessObjects;
using Framework.Config;
using Framework.Resources;
using Framework.Steps;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Resources
{
    public class DataProviders
    {
        public static IEnumerable TestCaseWithCountries()
            {
            AvailiableAirportsSteps steps = new AvailiableAirportsSteps();
            var data = steps.DeserializeCountries(Configuration.CountriesPath);
                foreach (Country currentCountry in data.Countries)
                {
                    yield return new TestCaseData(currentCountry.CountryName, currentCountry.Airports);
                }
            }
        } }

