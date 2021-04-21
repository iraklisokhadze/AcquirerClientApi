﻿using System.ComponentModel.DataAnnotations;

namespace Core.RequestModels
{
    public class AddPaymentRequest
    {
        public string OrderId { get; set; }

        /// <summary>
        /// მომხმარებელთან დიალოგის ენა (lang). ორსიმბოლოიანი კოდი ISO 639 სტანდარტის შესაბამისად (არასავალდებულო ველი);
        /// </summary>
        [MaxLength(2)]
        public string Lang { get; set; }

        /// <summary>
        /// გადახდის გვერდის იდენტიფიკატორი (page_id). სტრიქონი სიგრძით 32 სიმბოლო (არის სავალდებულო ველი).
        /// თუ პარამეტრი არ არის მითითებული, გადახდის გვერდი გამოიყენებს Default გადახდის გვერდებს.
        /// </summary>
        [Required]
        [MaxLength(32)]
        public string PageId { get; set; }

        /// <summary>
        /// მაღაზიის იდენტიფიკატორი ელექტრონული კომერციის სისტემურ მხარდაჭერაში merch_id სტრიქონი სიგრძით
        /// 32 სიმბოლო, (სავალდებულო ველი). ექვაიერი ატყობინებს ამ იდენტიფიკატორს მაღაზიას ელექტრონული
        /// კომერციის სისტემურ მხარდაჭერაში რეგისტრირების შემდეგ
        /// </summary>
        [Required]
        [MaxLength(32)]
        public string MerchantId { get; set; }

        // back_url_s დაბრუნების მისამართი გადახდის წარმატებით განხორციელების შემთხვევაში მოხდება ამ ბმულის გამოძახება(სავალდებულო);
        // back_url_ f დაბრუნების მისამართი გადახდის წარუმატებლად განხორციელების შემთხვევაში მოხდება ამ ბმულის გამოძახება(სავალდებულო);

        /// <summary>
        /// პრეავტორიზაცია (preauth). შესაძლო მნიშვნელობები: 
        /// Y – გადახდის განხორციელებაწინასწარი ავტორიზაციით (თანხის დაბლოკვით); 
        /// N – გადახდის განხორციელება წინასწარი ავტორიზაციის გარეშე(ჩვეულებრივი გადახდა).
        /// თუ პარამეტრი არ არის, მაშინ გადახდა ხორციელდება წინასწარი ავტორიაზაციის გარეშე.
        /// </summary>
        [MaxLength(1)]
        public string PreAuth { get; set; }

        //შეკვეთის დამატებითი პარამეტრები(ყველა პარამეტრი o.* სახელებით). ეს პარამეტრები მაღაზიას
        //გადაეცემა ორფაზიანი ურთიერთქმედების პროცესში.ჩვეულებრივ მოიცავს ტრანზაქციის/შეკვეთის/კალათის
        //იდენტიფიკატორს მაღაზიის სისტემაში(სავალდებულო)
    }
}
