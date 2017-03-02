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
    [TestFixture, Parallelizable(ParallelScope.Fixtures)]
    public class TestCase5 : BaseTest

    {
        private CheckFlyOutFlyInDateSteps step = new CheckFlyOutFlyInDateSteps();
        
        [Test]
        public void CheckFlightData()
        {
            step.OpenMainPage();
            step.SelectFlight("Berlin", "Toulouse", "5","6");
            
        }
       
    }
}
