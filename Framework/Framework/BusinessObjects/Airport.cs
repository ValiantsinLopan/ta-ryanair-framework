using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Framework.BusinessObjects
{
    public class Airport
    {
        [XmlElement("airport")]
        public string AirportName { get; set; }


        public Airport()
        {

        }

        public Airport(string airportName)
        {
            this.AirportName = airportName;
        }
    }
}
