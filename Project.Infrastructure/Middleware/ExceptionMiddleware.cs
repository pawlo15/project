using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Project.Infrastructure.Models;
using System.Text;

namespace Project.Infrastructure.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            string body = string.Empty;
            try
            {
                body =  await GetRequestBody(httpContext);
                await _next(httpContext);
            }
            catch (Exception e)
            {
                ServiceResponse<string> response = new ServiceResponse<string>();
                switch (true)
                {
                    default:
                        break;
                }
                await httpContext.Response.WriteAsJsonAsync(response);
            }
            
            // middleware do zrobienia obsługa błędów itp.      
        }
        private async Task<string> GetRequestBody(HttpContext httpContext)
        {
            httpContext.Request.EnableBuffering();

            var body = await new StreamReader(httpContext.Request.Body, Encoding.UTF8).ReadToEndAsync();

            httpContext.Request.Body.Position = 0;

            return body;
        }

        private ServiceResponse<string> AddResponse()
        {
            ServiceResponse<string> response = new ServiceResponse<string>();
            _logger.LogError("Error code: ");
            return response;
        }
    }
}
