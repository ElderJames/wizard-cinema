using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Wizard.Infrastructures;

namespace Wizard.Cinema.Admin.Extensions
{
    public static class ResponseExtensions
    {
        public static void UseHeaderExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(builder =>
            {
                builder.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.OK;
                    context.Response.ContentType = "application/json";
                    var error = context.Features.Get<IExceptionHandlerFeature>();
                    if (error != null)
                    {
                        var result = Anonymous.ApiResult<object>(ResultStatus.EXCEPTION, error.Error.Message);

                        await context.Response.WriteAsync(JsonConvert.SerializeObject(result)).ConfigureAwait(false);
                    }
                });
            });
        }
    }
}
