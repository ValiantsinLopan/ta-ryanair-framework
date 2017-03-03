using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Steps;
using Framework.Resources;
using Framework.BusinessObjects;

namespace NUnitTests
{
    [TestFixture]
    class AvailiableAirportsTest : BaseTest
    {
        [Test, TestCaseSource(typeof(DataProviders), "TestCaseWithCountries")]
        public void CheckCountriesAndAirports(string countryName, List<Airport> airports)
        {
            AvailiableAirportsSteps steps = new AvailiableAirportsSteps();
            steps.Open();
            steps.ClickFlightsFrom();
            
            Assert.True(steps.AirportsIsDisplayed("Dublin"));
        }

    }
}
