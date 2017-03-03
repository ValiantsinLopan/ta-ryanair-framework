using Framework.BusinessObjects;
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
            var data = AllCountries.DeserialiseCountries("C:\\Users\\Iryna_Bahatka1\\Documents\\CountriesWithAirports.xml");
                foreach (Country currentCountry in data.Countries)
                {
                    yield return new TestCaseData(currentCountry.CountryName, currentCountry.Airports);
                }
            }
        }
    }
}
