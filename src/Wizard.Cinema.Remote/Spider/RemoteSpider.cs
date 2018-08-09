using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Wizard.Cinema.Remote.Spider.Request;

namespace Wizard.Cinema.Remote.Spider
{
    public class RemoteSpider
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<RemoteSpider> _logger;

        public RemoteSpider(IHttpClientFactory httpClientFactory, ILogger<RemoteSpider> logger)
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