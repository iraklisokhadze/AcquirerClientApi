using System.Xml.Serialization;

namespace Core.ResponseModels
{
    [XmlRoot(ElementName = "purchase")]
        public class Purchase
        {
            [XmlElement(ElementName = "shortDesc")]
            public string ShortDesc { get; set; }
            [XmlElement(ElementName = "longDesc")]
            public string LongDesc { get; set; }
            [XmlElement(ElementName = "account-amount")]
            public Accountamount Accountamount { get; set; }
        }

      
}
