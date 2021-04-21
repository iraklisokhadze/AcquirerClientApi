using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastucture.DBEntities
{
    public class RefundCallback
    {
        public int Id { get; set; }
        public string OrderId { get; set; }
        public string PaymentHash { get; set; }
        public string IpayPaymentId { get; set; }
        public string Status { get; set; }
        public string StatusDescription { get; set; }
        public int ShopOrderId { get; set; }
        public string PaymentMethod { get; set; }
        public string CardType { get; set; }

        //იმ შემთხვევაში თუ გადახდა შესრულებულია ბარათით ინტერვეილის გავლით, დაემატება შემდეგი ორი პარამეტრი:
        public string TransactionId { get; set; }
        public string Pan { get; set; }

    }
}
