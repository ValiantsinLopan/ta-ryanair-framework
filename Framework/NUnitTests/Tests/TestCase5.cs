using NUnit.Framework;
using Framework.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Webdriver;

namespace NUnitTests.Tests
{
    [TestFixture()]
    public class TestCase5 : BaseTest

    {
        private CheckFlyOutFlyInDateSteps step = new CheckFlyOutFlyInDateSteps();
        [SetUp]
        

        [Test]
        public void CheckFlightData()
        {
            step.OpenMainPage();
            step.SelectFlight("Berlin Schönefeld", "Brussels", "4","5");
            
        }
       
    }
}
