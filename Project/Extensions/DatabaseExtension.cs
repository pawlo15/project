using Microsoft.EntityFrameworkCore;
using Project.Infrastructure.Data;

namespace Project.Extensions
{
    public static class DatabaseExtension
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, WebApplicationBuilder application)
        {
            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(application.Configuration.GetConnectionString("DbConnection")));

            return services;
        }
    }
}
