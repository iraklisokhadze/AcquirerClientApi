using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastucture.DBEntities
{
    public class PaymentStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IEnumerable<Payment> PaymentRequests { get; set; }
    }
}
