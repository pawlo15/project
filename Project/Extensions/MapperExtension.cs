using Project.Infrastructure.Accessories;
using System.Reflection;

namespace Project.Extensions
{
    public static class MapperExtension
    {
        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetAssembly(typeof(AutoMapProfile)));
            return services;
        }
    }
}
