using $safeprojectname$.Util;
using $ext_projectname$.Data.AppExceptions;
using $ext_projectname$.Data.Constants;
using $ext_projectname$.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Options;
using System.Net;
using System.Runtime.Serialization;
using System.Text;

namespace $safeprojectname$
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IActionResultExecutor<ObjectResult> executor;
        private readonly IOptionsMonitor<DbLoggerConfiguration> logConfig;
        private readonly IConfiguration configuration;
        private ILogger logger;

        private static readonly ActionDescriptor EmptyActionDescriptor = new ActionDescriptor();
        public ExceptionHandlerMiddleware(RequestDelegate next, IActionResultExecutor<ObjectResult> executor, IOptionsMonitor<DbLoggerConfiguration> logConfig, IConfiguration configuration)
        {
            this.next = next;
            this.executor = executor;
            this.logConfig = logConfig;
            this.configuration = configuration;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            if (logger == null)
                logger = new DbLoggerProvider(logConfig, configuration).CreateLogger("ErrorLogger");
            try
            {
                await next(context);
            }
            catch (UnauthorizedException ex)
            {
                logger.LogError(ex, $"UnauthorizedException . Url: {context.Request.Path}. Request Data: " + GetRequestData(context));
                var routeData = context.GetRouteData() ?? new RouteData();
                var actionContext = new ActionContext(context, routeData, EmptyActionDescriptor);

                ApiResponse<object> apiResponse = new ApiResponse<object>();
                apiResponse.Payload = null;
                apiResponse.IsSuccess = false;
                apiResponse.Message = ex.Message;

                var result = new ObjectResult(apiResponse)
                {
                    StatusCode = (int)HttpStatusCode.Unauthorized
                };

                await executor.ExecuteAsync(actionContext, result);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"An unhandled exception has occurred while executing the rquest. Url: {context.Request.Path}. Request Data: " + GetRequestData(context));
                var routeData = context.GetRouteData() ?? new RouteData();
                var actionContext = new ActionContext(context, routeData, EmptyActionDescriptor);

                ApiResponse<object> apiResponse = new ApiResponse<object>();
                apiResponse.Payload = null;
                apiResponse.IsSuccess = false;
                apiResponse.Message = ErrorMessages.UNHANDLED_EXCEPTION;

                var result = new ObjectResult(apiResponse)
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };

                await executor.ExecuteAsync(actionContext, result);
            }
        }

        private static string GetRequestData(HttpContext context)
        {
            StringBuilder sb = new StringBuilder();
            if(context.Request.HasFormContentType && context.Request.Form.Any())
            {
                sb.Append("Form variables: ");
                foreach(var x in context.Request.Form)
                {
                    sb.AppendFormat("Key={0}, Value={1}<br/>", x.Key, x.Value);
                }
            }
            sb.AppendLine("Method: " + context.Request.Method);
            return sb.ToString();
        }

    }
}
