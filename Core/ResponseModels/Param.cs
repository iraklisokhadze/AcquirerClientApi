using System.Xml.Serialization;

namespace Core.ResponseModels
{
    [XmlRoot(ElementName = "param")]
        public class Param
        {
            [XmlElement(ElementName = "name")]
            public string Name { get; set; }
            [XmlElement(ElementName = "value")]
            public string Value { get; set; }
        }

      
}
