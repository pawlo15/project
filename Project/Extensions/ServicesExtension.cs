using Microsoft.AspNetCore.Authorization;
using Project.Infrastructure.Policy;
using Project.Infrastructure.Services;
using Project.Infrastructure.Services.Interfaces.Base;
using Project.Infrastructure.Services.Repositories.Base;

namespace Project.Extensions
{
    public static class ServicesExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddSingleton<IAuthorizationHandler, RoleHandler>();

            return services;
        }
    }
}
