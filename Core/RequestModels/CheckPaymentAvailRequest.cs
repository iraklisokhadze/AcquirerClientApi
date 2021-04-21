using Core.ResponseModels;
using Microsoft.AspNetCore.Mvc;

namespace Core.RequestModels
{
    public class CheckPaymentAvailRequest
    {
        [BindProperty(Name = "merch_id")]
        public string MerchantId { get; set; }

        [BindProperty(Name = "trx_id")]
        public string TransactionId { get; set; }

        [BindProperty(Name = "o.id")]
        public string PaymentId { get; set; }

        [BindProperty(Name = "o.phone")]
        public string PhoneNumber { get; set; }

        [BindProperty(Name = "o.amount")]
        public string Amount { get; set; }

        [BindProperty(Name = "ts")]
        public string Date { get; set; }


        
        [BindProperty(Name = "result_code")]
        public ResultCode ResultCode { get; set; }

        [BindProperty(Name = "ext_result_code")]
        public string ExtendedResultCode { get; set; }

        [BindProperty(Name = "p.authcode")]
        public string AuthCode { get; set; }

        [BindProperty(Name = "p.expiryDate")]
        public string ExpiryDate { get; set; }

        [BindProperty(Name = "p.cardholder")]
        public string Cardholder { get; set; }

        [BindProperty(Name = "p.maskedPan")]
        public string MaskedPan { get; set; }

        [BindProperty(Name = "p.rrn")]
        public string RRN { get; set; }
    }
}
