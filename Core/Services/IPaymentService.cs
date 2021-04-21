using Core.RequestModels;
using Core.ResponseModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IPaymentService
    {
        Task<IResponse<int>> Pay(AddPaymentRequest request);
        Task<object> CheckPayment(object request);
        Task<object> RegisterPayment(object request);
        Task PaymentFailed(string orderId);
        Task PaymentSuceeded(string orderId);
        Task RegiisterCallBack(CallbackRequest request, EnumCollbackType collbackType);
    }
}
