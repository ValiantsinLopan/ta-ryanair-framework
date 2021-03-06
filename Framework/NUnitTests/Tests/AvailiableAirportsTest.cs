﻿using NUnit.Framework;
using System.Collections.Generic;
using Framework.Steps;
using Framework.Resources;
using Framework.BusinessObjects;
using NUnitTests.DataSources;

namespace NUnitTests
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    class AvailiableAirportsTest : BaseTest
    {
        public AvailiableAirportsSteps step;

        [OneTimeSetUp]
        public void SetUp()
        {
            step = new AvailiableAirportsSteps();
            step.Open();
        }

        [Test, TestCaseSource(typeof(CountriesAndAirportsDataSource), "TestCaseWithCountries")]
        public void CheckCountriesAndAirports(string countryName, List<Airport> airports)
        {    
            step.ClickFlightsFrom();
            step.EnterCountryName(countryName);
            Assert.True(step.AllAirportsAreDisplayed(airports), $"problem with {countryName}");
        }

    }
}
