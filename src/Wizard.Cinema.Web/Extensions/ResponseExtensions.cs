using System.Net;
using Infrastructures;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Wizard.Cinema.Web.Extensions
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
                    IExceptionHandlerFeature error = context.Features.Get<IExceptionHandlerFeature>();
                    if (error != null)
                    {
                        ApiResult<dynamic> result = Anonymous.ApiResult<object>(ResultStatus.EXCEPTION, error.Error.Message);
                        await context.Response.WriteAsync(JsonConvert.SerializeObject(result, new JsonSerializerSettings()
                        {
                            ContractResolver = new CamelCasePropertyNamesContractResolver()
                        })).ConfigureAwait(false);
                    }
                });
            });
        }
    }
}
