using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Infrastructures;
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
            string text = await FeatchHtmlAsync(request);
            try
            {
                return JsonConvert.DeserializeObject<TResponse>(text);
            }
            catch (Exception ex)
            {
                throw new Exception("反序列化出错,字符串：" + text, ex);
            }
        }

        public async Task<string> FeatchHtmlAsync<TResponse>(BaseRequest<TResponse> request) where TResponse : class
        {
            var reqMsg = new HttpRequestMessage(request.Method, request.Url);
            if (!request.PostData.IsNullOrEmpty())
                reqMsg.Content = new StringContent(request.PostData, Encoding.UTF8, "application/x-www-form-urlencoded");

            reqMsg.Headers.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/69.0.3497.100 Safari/537.36");

            var respMsg = await _httpClient.SendAsync(reqMsg);
            var text = await respMsg.Content.ReadAsStringAsync();
            _logger.LogDebug("请求" + request.Url + "返回:" + text);

            if (text.Contains("我们检测到您所在的网络环境存在恶意访问"))
                throw new Exception("被发现了，请通知James!");

            if (text.Contains("该影院不支持在线选座"))
                throw new Exception("该影院不支持在线选座");

            if (string.IsNullOrEmpty(request.XPath))
                return text;

            var doc = new HtmlDocument();
            doc.LoadHtml(text);

            return doc.DocumentNode.SelectSingleNode(request.XPath)?.OuterHtml;
        }
    }
}
