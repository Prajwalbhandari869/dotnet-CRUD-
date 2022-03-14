using SongsTrack.Repository.Entities;
using System.Net;
using System.Text.Json;

namespace SongsTrack.Server.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IHostEnvironment _env;
        private readonly ILogger<ExceptionMiddleware> _logger;

        /// <summary>
        /// Requiest Deligate is what is coming up next in the middleware pipeline.
        /// ILogger is used to log out exception in termminal. 
        /// IHostEnvironment is to check environment is development or production.
        /// Each context of httprequest pass through InvokeAsync method's try block and catched by catch block if any occer.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="env"></param>
        /// <param name="logger"></param>
        public ExceptionMiddleware(RequestDelegate next,IHostEnvironment env,ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _env = env;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var response = _env.IsDevelopment()
                    ? new ApiException(context.Response.StatusCode,ex.Message,ex.StackTrace?.ToString())
                    : new ApiException(context.Response.StatusCode,"Internal Server Error");
                var option = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                var json = JsonSerializer.Serialize(response, option);
                await context.Response.WriteAsync(json);
            }
        }
    }
}
