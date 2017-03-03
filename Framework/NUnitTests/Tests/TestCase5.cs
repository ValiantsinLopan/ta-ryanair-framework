using NUnit.Framework;
using Framework.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Webdriver;
using System.Threading;

namespace NUnitTests.Tests
{
    [TestFixture, Parallelizable(ParallelScope.Fixtures)]
    public class TestCase5 : BaseTest

    {
        private CheckFlyOutFlyInDateSteps step = new CheckFlyOutFlyInDateSteps();
        
        [Test]
        public void CheckFlightData()
        {
            DriverFactory.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            step.OpenMainPage();
            step.Login("l747662@mvrht.com", "1qaz@WSX");
            Thread.Sleep(3000);
            step.SelectFlight("Berlin", "Brussels", "5","5");
            Thread.Sleep(5000);
            step.SelectTickets();
            Assert.IsFalse(step.IsPossibleSelectFirstBackTicket(),"");
        }
       
    }
}
