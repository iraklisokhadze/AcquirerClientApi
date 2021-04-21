using Core.RequestModels;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IDbRepository
    {
        Task<AddPaymentRequest> AddPayment(AddPaymentRequest request);
        Task AddPaymentCallBack(CallbackRequest request);
        Task AddRefundCallBack(CallbackRequest request);
    }
}
