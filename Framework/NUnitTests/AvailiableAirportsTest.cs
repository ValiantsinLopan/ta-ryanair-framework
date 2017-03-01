using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Steps;

namespace NUnitTests
{
    [TestFixture]
    class AvailiableAirportsTest : BaseTest
    {
        [Test]
        public void CheckCountriesAndAirports()
        {
            AvailiableAirportsSteps steps = new AvailiableAirportsSteps();
            steps.Open();

        }

    }
}
