using System.Xml.Serialization;

namespace Core.ResponseModels
{
    [XmlRoot(ElementName = "payment-avail-response")]
    public class Paymentavailresponse
    {
        [XmlElement(ElementName = "result")]
        public Result Result { get; set; }
        [XmlElement(ElementName = "merchant-trx")]
        public string Merchanttrx { get; set; }
        [XmlElement(ElementName = "primaryTrxPcid")]
        public string PrimaryTrxPcid { get; set; }
        [XmlElement(ElementName = "submerchant")]
        public string Submerchant { get; set; }
        [XmlElement(ElementName = "card")]
        public Card Card { get; set; }
        [XmlElement(ElementName = "transaction-type")]
        public string Transactiontype { get; set; }
        [XmlElement(ElementName = "purchase")]
        public Purchase Purchase { get; set; }
        [XmlElement(ElementName = "order-params")]
        public Orderparams Orderparams { get; set; }
    }

      
}
