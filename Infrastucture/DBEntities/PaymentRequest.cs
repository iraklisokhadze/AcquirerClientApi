using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Infrastucture.DBEntities
{
    public class Payment
    {
        public int Id { get; set; }
        public string TransactionId { get; set; }
        public DateTime CreateDate { get; set; }
        public decimal Amount { get; set; }
        public string Ccy { get; set; }
        public int StatusId { get; set; }
        public virtual PaymentStatus PaymentStatus { get; set; }
    }
}
