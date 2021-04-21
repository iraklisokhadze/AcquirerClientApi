using AutoMapper;
using Core.RequestModels;
using Infrastucture.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastucture
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<CallbackRequest, PaymentCallback>();
            CreateMap<CallbackRequest, RefundCallback>();
        }
    }
}
