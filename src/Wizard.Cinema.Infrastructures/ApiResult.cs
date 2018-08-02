namespace Wizard.Cinema.Infrastructures
{
    public sealed class ApiResult<TResult>: ApiResult
    {
        public ApiResult()
        {

        }

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

        public new TResult Result { get; set; }
    }

    public class ApiResult
    {
        public ResultStatus Status { get; set; }

        public string Message { get; set; }

        public virtual dynamic Result { get; set; }
    }
}
