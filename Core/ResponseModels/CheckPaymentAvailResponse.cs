using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Core.ResponseModels
{
    //public class CheckPaymentAvailResponse
    //{
    //    /// <summary>
    //    /// შეძენის შესაძლებლობის შემოწმების შედეგი. ResultCode1 (წარმატებული შედეგი) და ResultCode2 (წარუმატებელი შედეგი) პარამეტრი სავალდებულოა;
    //    /// თუ ResultCode=2 (CPA Rejected – გადახდის შეცდომით განხორციელება), ველი <desc> მოიცავს პარამეტრს, 
    //    /// რომელიც აღწერს წარუმატებლობის მიზეზს, გადახდის პირველი ფაზის შესრულებისას.
    //    /// </summary>
    //    public int ResultCode { get; set; }

    //    /// <summary>
    //    ///  შედეგის აღწერა (არსებობს, თუ ResultCode = 1);
    //    /// </summary>
    //    public string ResultDescription { get; set; }

    //    /// <summary>
    //    /// მაღაზიაში გადახდის (ტრანზაქციის) შიდა იდენტიფიკატორი;
    //    /// </summary>
    //    public string MerchantTransactionID { get; set; }

    //    /// <summary>
    //    ///  შენაძენის მოკლე აღწერა; მაქსიმუმ 30 სიმბოლო
    //    /// </summary>
    //    [MaxLength(30)]
    //    public string PurchaseDescriptionShort { get; set; }

    //    /// <summary>
    //    /// შენაძენის სრული აღწერა;მაქსიმუმ 125 სიმბოლო
    //    /// </summary>
    //    [MaxLength(125)]
    //    public string PurchaseDescriptionLong { get; set; }

    //    /// <summary>
    //    /// შენაძენის თანხა მინორულ ერთეულებში (არსებობს, თუ ResultCode = 1);
    //    /// </summary>
    //    public decimal Amount { get; set; }

    //    /// <summary>
    //    /// მაღაზიის საკომისიოს თანხა მინორულ ერთეულებში (არსებობს, თუ ResultCode = 1);
    //    /// </summary>
    //    public decimal Fee { get; set; }

    //    /// <summary>
    //    /// შეძენისას გამოყენებული ვალუტა;
    //    /// </summary>
    //    [MaxLength(3)]
    //    public string Currency { get; set; }

    //    /// <summary>
    //    /// მაღაზიის ანგარიშის იდენტიფიკატორი PPS-ში. არასავალდებულო ველი იმ პირობით, 
    //    /// თუ მაღაზიას მოცემულ ვალუტაში აქვს მხოლოდ ერთი ანგარიში;
    //    /// </summary>
    //    public string MerchantAccountId { get; set; }

    //    /// <summary>
    //    /// შუამავალი მაღაზიის დასახელება (თუ მაღაზია შუამავლად იყენებს Facilitator-ს)
    //    /// </summary>
    //    public string Submerchant { get; set; }

    //    /// <summary>
    //    /// შენაძენის პარამეტრების აღწერის ბლოკი. პარამეტრი ოფციონურია;
    //    /// </summary>
    //    public IEnumerable<OrderParam> OrderParams { get; set; }

    //    /// <summary>
    //    /// იმ ტრანზაქციის იდენტიფიკატორი, რომელიც მოიცავს მონაცემებს თავდაპირველი გადახდის შესახებ(მხოლოდ რეკურენტული გადახდისთვის).
    //    /// </summary>
    //    public string PrimaryTransactionID { get; set; }

    //}

      
}

/// <summary>
/// OrderParams param – შენაძენის პარამეტრის აღწერა (Name – პარამეტრის დასახელება (პარამეტრი სავალდებულოა); 
/// Value – პარამეტრის მნიშვნელობა(პარამეტრი სავალდებულოა)). პარამეტრი ოფციონურია;
/// </summary>
public class OrderParam
{
    public string Name { get; set; }
    public string Value { get; set; }
}
