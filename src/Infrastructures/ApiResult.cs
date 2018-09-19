namespace Infrastructures
{
    public sealed class ApiResult<TResult>
    {
        public ResultStatus Status { get; set; }

        public string Message { get; set; }

        public TResult Result { get; set; }

        public ApiResult(ResultStatus status, TResult result)
        {
            this.Result = result;
            this.Status = status;
        }

        public ApiResult(ResultStatus status, string message)
        {
            this.Status = status;
            this.Message = message;
        }
    }
}
