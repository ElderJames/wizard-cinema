namespace Wizard.Cinema.Remote.Spider.Response
{
    public class BaseResponse<TResponse> where TResponse : class
    {
        public TResponse Value { get; set; }
    }
}