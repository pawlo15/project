using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Project.Infrastructure.Accessories;
using Project.Infrastructure.Exceptions;
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
                _logger.LogWarning($"Method: {httpContext.Request.Method} | Path: {httpContext.Request.Path}");

                switch (e)
                {
                    case AuthorizeException:
                        {
                            AuthorizeException? authorizeException = (AuthorizeException) e;
                            httpContext.Response.StatusCode = (int) System.Net.HttpStatusCode.Unauthorized;

                            response = AddResponse(authorizeException.ErrorCode);
                            break;
                        }                     
                    case DomainException:
                        {
                            DomainException? domainException = (DomainException) e;
                            httpContext.Response.StatusCode = (int) System.Net.HttpStatusCode.InternalServerError;

                            response = AddResponse(domainException.ErrorCode);
                            break;
                        }                       

                    case NoActiveAccountException:
                        {
                            NoActiveAccountException? noActiveAccount = (NoActiveAccountException) e;
                            httpContext.Response.StatusCode = (int) System.Net.HttpStatusCode.BadRequest;

                            response = AddResponse(noActiveAccount.ErrorCode);
                            break;
                        }                       

                    case WrongTransferAmountException:
                        {
                            WrongTransferAmountException? wrongTransferAmount = (WrongTransferAmountException) e;
                            httpContext.Response.StatusCode = (int) System.Net.HttpStatusCode.BadRequest;

                            response = AddResponse(wrongTransferAmount.ErrorCode);
                            break;
                        }

                    case UserRegisterException:
                        {
                            UserRegisterException? userRegisterException = (UserRegisterException) e;
                            httpContext.Response.StatusCode = (int) System.Net.HttpStatusCode.BadRequest;

                            response = AddResponse(userRegisterException.ErrorCode);
                            break;
                        }

                    default:
                        {
                            httpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                            _logger.LogWarning($"Request body: {body} | Error: {e}");

                            response = AddResponse(ErrorCode.ERR000);
                            break;
                        }
                }
                await httpContext.Response.WriteAsJsonAsync(response);
            }
        }
        private async Task<string> GetRequestBody(HttpContext httpContext)
        {
            httpContext.Request.EnableBuffering();

            var body = await new StreamReader(httpContext.Request.Body, Encoding.UTF8).ReadToEndAsync();

            httpContext.Request.Body.Position = 0;

            return body;
        }

        private ServiceResponse<string> AddResponse(ErrorCode errorCode)
        {
            ServiceResponse<string> response = new ServiceResponse<string>();
            response.Data = Errors.GetErrorCode(errorCode);
            response.Message = Errors.GetValue(errorCode);
            _logger.LogError($"Error code: {response.Data} | {response.Message}");
            return response;
        }
    }
}
