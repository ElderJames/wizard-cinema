using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Wizard.Cinema.Remote
{
    public class BaseRequest<TResponse>
    {
        public virtual string Url { get; }

        public HttpMethod Method => HttpMethod.Get;

        public virtual string XPath { get; }
    }
}