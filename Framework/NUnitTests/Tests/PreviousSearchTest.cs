using Framework.Steps;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    class PreviousSearchTest : BaseTest
    {
        public PreviousSearchSteps step;

        [OneTimeSetUp]
        public void SetUp()
        {
            step = new PreviousSearchSteps();
            step.Open();

        }

        [Test]
        public void CheckPreviousSearch()
        {           
            step.SelectFlight("Berlin", "Brussels", "5", "5");
            step.ClickOnFlightField();
            step.Open();
        }
    }
}
