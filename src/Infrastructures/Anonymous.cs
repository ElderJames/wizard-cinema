using System;

namespace Infrastructures
{
    public static class Anonymous
    {
        private static readonly Lazy<ApiResult<dynamic>> apiResult = new Lazy<ApiResult<dynamic>>();

        public static ApiResult<TResult> ApiResult<TResult>(ResultStatus status, TResult result)
        {
            apiResult.Value.Result = result;
            apiResult.Value.Status = status;

            return apiResult.Value as ApiResult<TResult>;
        }

        public static ApiResult<TResult> ApiResult<TResult>(ResultStatus status, string message)
        {
            apiResult.Value.Result = default(TResult);
            apiResult.Value.Message = message;
            apiResult.Value.Status = status;

            return apiResult.Value as ApiResult<TResult>;
        }

        public static ApiResult<object> ApiResult(ResultStatus status, string message)
        {
            apiResult.Value.Result = null;
            apiResult.Value.Message = message;
            apiResult.Value.Status = status;

            return apiResult.Value;
        }
    }
}
