using Microsoft.AspNetCore.Authorization;
using Project.Infrastructure.Models.Client;
using Project.Infrastructure.Policy;
using Project.Infrastructure.Services;
using Project.Infrastructure.Services.Interfaces.Base;
using Project.Infrastructure.Services.Repositories;
using Project.Infrastructure.Services.Repositories.Base;

namespace Project.Extensions
{
    public static class ServicesExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IRepository<Client>, GenericRepository<Client>>();
            services.AddScoped<IRepository<Address>, GenericRepository<Address>>();
            services.AddScoped<IRepository<Account>, AccountRepository>();

            services.AddSingleton<IAuthorizationHandler, RoleHandler>();

            return services;
        }
    }
}
