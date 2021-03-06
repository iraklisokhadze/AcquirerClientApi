using Core.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AcquirerClientApi
{
    public class GeorgianCardHelper
    {
        //public static Uri BuildPaymentUri(string paymentId, GeorgianCardConfiguration config)
        //{
        //    var queryString = HttpUtility.ParseQueryString(string.Empty);

        //    queryString["merch_id"] = config.MerchantId;
        //    queryString["page_id"] = config.PageId;
        //    queryString["lang_code"] = "ka"; // NOTE: ka, en, ru - You can move it to param and pass based on UI lang
        //    queryString["o.id"] = paymentId;
        //    queryString["back_url_s"] = config.PaymentSuccessUrl;
        //    queryString["back_url_f"] = config.PaymentFailUrl;

        //    var uriBuilder = new UriBuilder(config.PaymentUrl) { Query = queryString.ToString() };

        //    return uriBuilder.Uri;
        //}

        public static string BuildPaymentAvailableResponse(ResultCode resultCode,
                                                           string resultDesc,
                                                           int paymentAmount = default, /*GeorgianCardConfiguration config = default,*/
                                                           string shortDesc = default,
                                                           string longDesc = default,
                                                           string merchAccId = default,
                                                           string ccy = default,
                                                           string exponent = default)
        {
            switch (resultCode)
            {
                case ResultCode.Success:
                    {
                        var result =
                            new XElement("payment-avail-response",
                                new XElement("result",
                                    new XElement("code", (int)resultCode),
                                    new XElement("desc", resultDesc)
                                ),
                                new XElement("purchase",
                                    new XElement("shortDesc", shortDesc ?? "Payment Processing"),
                                    new XElement("longDesc", longDesc ?? "Payment Processing"),
                                    new XElement("account-amount",
                                        new XElement("id", merchAccId),
                                        new XElement("amount", paymentAmount),
                                        new XElement("currency", ccy),
                                        new XElement("exponent", exponent)
                                    )
                                )
                            );
                        return result.ToString();
                    }
                case ResultCode.Fail:
                    {
                        var result =
                            new XElement("payment-avail-response",
                                new XElement("result",
                                    new XElement("code", (int)resultCode),
                                    new XElement("desc", resultDesc)
                                )
                            );
                        return result.ToString();
                    }
                default:
                    return null;
            }
        }

        public static string BuildRegisterPaymentResponse(ResultCode resultCode, string resultDesc)
        {
            var result =
                new XElement("register-payment-response",
                    new XElement("result",
                        new XElement("code", (int)resultCode),
                        new XElement("desc", resultDesc)
                    )
                );

            return result.ToString();
        }

        public static int ConvertGELToGeorgianCardAmount(decimal input)
        {
            return Convert.ToInt32(input * 100);
        }

        public static decimal ConvertGeorgianCardAmountToGEL(int input)
        {
            return Convert.ToDecimal(input) / 100;
        }
    }
}
