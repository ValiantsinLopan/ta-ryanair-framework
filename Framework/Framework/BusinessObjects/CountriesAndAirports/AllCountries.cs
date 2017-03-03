using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace Framework.BusinessObjects
{
    [Serializable]
    public class AllCountries
    {
        [XmlElement("country")]
        public List<Country> Countries { get; set; }

        public static AllCountries DeserialiseCountries(string filePath)
        {
            var countrySerialiser = new XmlSerializer(typeof(AllCountries));
            return (AllCountries)countrySerialiser.Deserialize(new XmlTextReader(filePath));
        }
    }
}
