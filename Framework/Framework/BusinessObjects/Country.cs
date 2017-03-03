using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Framework.BusinessObjects
{
   public class Country
    {
        [XmlElement("name")]
        public string CountryName { get; set; }

        [XmlElement("airports")]
        public List<Airport> Airports { get; set; }


        public Country()
        {

        }

        public Country(string countryName, List<Airport> airports)
        {
            this.CountryName = countryName;
            this.Airports = airports;
        }

    }
}
