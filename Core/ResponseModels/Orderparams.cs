using System.Xml.Serialization;

namespace Core.ResponseModels
{
    [XmlRoot(ElementName = "order-params")]
        public class Orderparams
        {
            [XmlElement(ElementName = "param")]
            public Param Param { get; set; }
        }

      
}
