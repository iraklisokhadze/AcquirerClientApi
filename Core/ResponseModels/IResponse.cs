using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ResponseModels
{
    public interface IResponse<T>
    {
        bool Succeeded { get; }

        T Data { get; }

        IErrorMessage ErrorMessage { get; }
    }
}
