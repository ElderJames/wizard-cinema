using System.Net.Http;

namespace Wizard.Cinema.Remote.Spider.Request
{
    public class BaseRequest<TResponse>
    {
        public virtual string Url { get; }

        public HttpMethod Method => HttpMethod.Get;

        public virtual string XPath { get; }
    }
}