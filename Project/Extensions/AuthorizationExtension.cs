using Project.Infrastructure.Accessories;
using Project.Infrastructure.Models.User;
using Project.Infrastructure.Policy;

namespace Project.Extensions
{
    public static class AuthorizationExtension
    {
        public static IServiceCollection AddAuthorizationExtension(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AccessForLogClient", policy =>
                policy.Requirements.Add(new RoleRequirement(new List<Roles> { Roles.Client })));
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("AccessForWorker", policy =>
                policy.Requirements.Add(new RoleRequirement(new List<Roles> { Roles.Admin })));
            });
            return services;
        }
    }
}
