using System.Xml.Serialization;

namespace Core.ResponseModels
{
    [XmlRoot(ElementName = "card")]
        public class Card
        {
            [XmlElement(ElementName = "ref")]
            public string Ref { get; set; }
            [XmlElement(ElementName = "present")]
            public string Present { get; set; }
        }

      
}
