using Project.Infrastructure.Middleware;

namespace Project.Extensions
{
    public static class ExceptionExtension
    {
        public static IApplicationBuilder UseExceptionExtension(this WebApplication app) 
        {
            app.UseMiddleware<ExceptionMiddleware>();
            return app;
        }
    }
}
