using System.Xml.Serialization;

namespace Core.ResponseModels
{
    [XmlRoot(ElementName = "result")]
        public class Result
        {
            [XmlElement(ElementName = "code")]
            public string Code { get; set; }
            [XmlElement(ElementName = "desc")]
            public string Desc { get; set; }
        }

    public enum ResultCode
    {
        Success = 1,
        Fail = 2,
        Other = 3
    }
}
