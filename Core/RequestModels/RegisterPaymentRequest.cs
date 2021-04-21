using System;
using System.Collections.Generic;

namespace Core.RequestModels
{
    public class RegisterPaymentRequest
    {
        /// <summary>
        /// მაღაზიის იდენტიფიკატორი PPS-ში. სიგრძე – 32 სიმბოლო (ციფრებით/ასოებით);
        /// </summary>
        public string MerchantID { get; set; }

        /// <summary>
        /// ტრანზაქციის იდენტიფიკატორი PPS-ში. სიგრძე – 32 სიმბოლო (ციფრებით/ასოებით).
        /// გამოიყენება პირველი და მეორე ფაზების მოთხოვნების შესადარებლად;
        /// </summary>
        public string TransactionID { get; set; }

        /// <summary>
        ///  გადახდის (ტრანზაქციის) შიდა იდენტიფიკატორი მაღაზიაში; 
        ///  Payment Result Code – გადახდის განხორციელების შედეგი.
        ///  შეუძლია ResultCode1(წარმატებული შედეგი) და ResultCode2(წარუმატებელი შედეგი) მნიშვნელობების მიღება;
        /// </summary>
        public string MerchantTransactionID { get; set; }

        /// <summary>
        /// შენაძენის თანხა მინორულ ერთეულებში (არსებობს, თუ ResultCode = 1);
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// მაღაზიის ანგარიშის იდენტიფიკატორი PPS-ში. არასავალდებლო ველი იმ პირობით, თუ მოცემულ ვალუტაში მაღაზიას აქვს მხოლოდ ერთი ანგარიში;
        /// </summary>
        public string MerchantAccountID { get; set; }

        /// <summary>
        /// შენაძენის პარამეტრების ნაკრები. პარამეტრების ნაკრებს და მათ სახელებს ადგენს მაღაზია (სავალდებულო პარამეტრი). 
        /// </summary>
        public IEnumerable<OrderParam> OrderParams { get; set; }

        /// <summary>
        /// გადახდის შედეგის მონაცემები;
        /// </summary>
        public AdditionalPaymentResult AdditionalPaymentResults { get; set; }

    }

    public class AdditionalPaymentResult
    {
        /// <summary>
        ///  (Retrieval Reference Number) – გადახდის უნიკალური იდენტიფიკატორი საპროცესინგო ცენტრში (არსერბობს, თუ ResultCode = 1); 
        /// </summary>
        public string RRN { get; set; }

        /// <summary>
        /// ავტორიზაციის კოდი, რომელიც მიღებულია საპროცესინგო ცენტრიდან (ISO 8583 field 38);
        /// </summary>
        public string Authcode { get; set; }

        /// <summary>
        /// ბარათის დაფარული ნომერი, რომლითაც ხორციელდება გადახდა; 
        /// </summary>
        public string MaskedPan { get; set; }

        /// <summary>
        /// – პასუხი (Y/N), მიღებული MPI-დან 3D Secure-აუთენტიფიკაციის შესრულების შედეგად: Y – წარმატებული შედეგი, N – წარუმატებელი შედეგი;
        /// </summary>
        public char IsFullyAuthenticated { get; set; }

        /// <summary>
        /// ბარათის მფლობელის ვინაობა;
        /// </summary>
        public string Сardholder { get; set; }

        /// <summary>
        /// დრო და თარიღი ავტორიზაიის მოთხოვნიდან MMddHHmmss ფორმატში. პარამეტრი არსებობს, თუ ResultCode = 1;
        /// </summary>
        public DateTime? TransmissionDateTime { get; set; }

        /// <summary>
        /// p.3DS.PARes.TX.cavv – ვერიფიკაციის მნიშვნელობა ბარათის მფლობელის აუტენთიფიცირებისთვის
        /// </summary>
        public string P3DSPAResTXcavv  { get; set; }

        /// <summary>
        /// p.3DS.PARes.TX.eci – ელექტრონული კომერციის ინდიკატორი. პარამეტრი არსებობს, თუ extended3DSResults = true;
        /// </summary>
        public string P3DSPAResTXeci { get; set; }

        /// <summary>
        /// p.3DS.PARes.Purchase.xid – ტრანზაქციის იდენტიფიკატორი. პარამეტრი არსებობს, თუ extended3DSResults = true.
        /// </summary>
        public string P3DSPAResPurchasexid  { get; set; }


    }
}
