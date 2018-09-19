using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

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
            Result = default(TResult);

            Type type = typeof(TResult);
            if (type.IsNullableType())
                Result = default(TResult);

            if (type.IsArray)
            {
                Type genericType = type.GenericTypeArguments[0];
                MethodCallExpression callExp = Expression.Call(typeof(Array), nameof(Array.Empty), new[] { genericType }, null);
                Result = Expression.Lambda<Func<TResult>>(callExp).Compile()();
            }

            if (type.IsEnumerable())
            {
                Type genericType = type.GenericTypeArguments[0];
                MethodCallExpression callExp = Expression.Call(typeof(Enumerable), nameof(Enumerable.Empty), new[] { genericType }, null);
                Result = Expression.Lambda<Func<TResult>>(callExp).Compile()();
            }
        }

        public ApiResult(ResultStatus status, TResult result, string message)
        {
            this.Result = result;
            this.Status = status;
            this.Message = message;
        }
    }
}
