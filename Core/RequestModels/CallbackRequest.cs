using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.RequestModels
{
    public enum EnumCollbackType
    {
        Payment = 1,
        Refund = 2
    }
    public class CallbackRequest
    {
        [BindProperty(Name = "order_id")]
        public string OrderId { get; set; }

        [BindProperty(Name = "payment_hash")]
        public string PaymentHash { get; set; }//

        [BindProperty(Name = "ipay_payment_id")]
        public string IpayPaymentId { get; set; }

        [BindProperty(Name = "status")]//success, error
        public string Status { get; set; }

        [BindProperty(Name = "status_description")]//PERFORMED, REJECTED ,etc.
        public string StatusDescription { get; set; }

        [BindProperty(Name = "shop_order_id")]//shop-order-id
        public int ShopOrderId { get; set; }

        [BindProperty(Name = "payment_method")]//GC_CARD, BOG_CARD, BOG_LOAN, BOG_LOYALTY
        public string PaymentMethod { get; set; }

        [BindProperty(Name = "card_type")]//VISA, MC, AMEX
        public string CardType { get; set; }

        //იმ შემთხვევაში თუ გადახდა შესრულებულია ბარათით ინტერვეილის გავლით, დაემატება შემდეგი ორი პარამეტრი:
        [BindProperty(Name = "transaction_id")]
        public string TransactionId { get; set; }

        [BindProperty(Name = "pan")]
        public string Pan { get; set; }

    }
}
