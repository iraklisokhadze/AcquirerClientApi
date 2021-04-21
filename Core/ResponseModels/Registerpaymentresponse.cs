using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Core.ResponseModels
{
    [XmlRoot(ElementName = "register-payment-response")]
    public class Registerpaymentresponse
    {
        [XmlElement(ElementName = "result")]
        public Result Result { get; set; }
    }

}
