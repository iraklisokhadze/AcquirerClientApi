using System;
using System.Collections.Generic;
using System.Text;

namespace Core.RequestModels
{
    public class IpayConfiguration
    {
        public string BaseUrl { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}
