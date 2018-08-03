using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Microsoft.Extensions.Logging;

namespace Wizard.Cinema.Remote
{
    public class RemoteCall
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<RemoteCall> _logger;

        public RemoteCall(IHttpClientFactory httpClientFactory, ILogger<RemoteCall> logger)
        {
            _logger = logger;
            this._httpClient = httpClientFactory.CreateClient("movieInfo");
        }

        public async Task<TResponse> SendAsync<TResponse>(BaseRequest<TResponse> request) where TResponse : class
        {
            var text = await FeatchHtmlAsync(request);

            return JsonConvert.DeserializeObject<TResponse>(text);
        }

        public async Task<string> FeatchHtmlAsync<TResponse>(BaseRequest<TResponse> request) where TResponse : class
        {
            var reqMsg = new HttpRequestMessage(request.Method, request.Url);
            var respMsg = await _httpClient.SendAsync(reqMsg);
            var text = await respMsg.Content.ReadAsStringAsync();
            _logger.LogDebug("请求" + request.Url + "返回:" + text);

            if (string.IsNullOrEmpty(request.XPath))
                return text;

            var doc = new HtmlDocument();
            doc.LoadHtml(text);

            return doc.DocumentNode.SelectSingleNode(request.XPath).OuterHtml;
        }
    }
}