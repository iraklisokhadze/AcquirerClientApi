using System.Xml.Serialization;

namespace Core.ResponseModels
{
    [XmlRoot(ElementName = "account-amount")]
        public class Accountamount
        {
            [XmlElement(ElementName = "id")]
            public string Id { get; set; }
            [XmlElement(ElementName = "amount")]
            public string Amount { get; set; }
            [XmlElement(ElementName = "fee")]
            public string Fee { get; set; }
            [XmlElement(ElementName = "currency")]
            public string Currency { get; set; }
            [XmlElement(ElementName = "exponent")]
            public string Exponent { get; set; }
        }

      
}
