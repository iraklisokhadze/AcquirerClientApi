using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ResponseModels
{
    public interface IErrorMessage
    {
        string Key { get; set; }

        string Value { get; set; }
    }
}
