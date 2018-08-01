using System;
using System.Collections.Generic;
using System.Text;

namespace Wizard.Cinema.Remote
{
    public class BaseResponse<TResponse> where TResponse : class
    {
        public TResponse Value { get; set; }
    }
}