using System;

namespace Wizard.Cinema.Infrastructures
{
    public static class Anonymous
    {
        private static readonly Lazy<ApiResult> apiResult = new Lazy<ApiResult>();
        public static ApiResult ApiResult<TResult>(ResultStatus status,TResult result)
        {
            apiResult.Value.Result = result;
            apiResult.Value.Status = status;

            return apiResult.Value;
        }

        public static ApiResult ApiResult<TResult>(ResultStatus status, string message)
        {
            apiResult.Value.Result = default(TResult);
            apiResult.Value.Message = message;
            apiResult.Value.Status = status;

            return apiResult.Value;
        }
    }
}
