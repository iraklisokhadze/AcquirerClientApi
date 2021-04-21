using AutoMapper;
using Core.Repositories;
using Core.RequestModels;
using Infrastucture.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastucture.Repositories
{
    public class DbRepository : IDbRepository
    {
        private readonly AcquireDbContext _acquireDbContext;
        private readonly IMapper _mapper;

        public DbRepository(AcquireDbContext acquireDbContext, IMapper mapper)
        {
            _acquireDbContext = acquireDbContext;
            _mapper = mapper;
        }

        public Task<AddPaymentRequest> AddPayment(AddPaymentRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task AddPaymentCallBack(CallbackRequest request)
        {
            _acquireDbContext.PaymentCallbacks.Add(_mapper.Map<PaymentCallback>(request));
            await _acquireDbContext.SaveChangesAsync();
        }

        public async Task AddRefundCallBack(CallbackRequest request)
        {
            _acquireDbContext.RefundCallbacks.Add(_mapper.Map<RefundCallback>(request));
            await _acquireDbContext.SaveChangesAsync();
        }
    }
}
