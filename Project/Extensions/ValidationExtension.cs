using FluentValidation;
using FluentValidation.AspNetCore;
using System.Reflection;
using System.Runtime.Loader;

namespace Project.Extensions
{
    public static class ValidationExtension
    {
        private static Assembly assembly =
            AssemblyLoadContext.Default.LoadFromAssemblyPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                $"Project.Infrastructure.dll"));

        public static IServiceCollection AddValidation(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();

            ValidatorOptions.Global.DefaultClassLevelCascadeMode = CascadeMode.Stop;
            ValidatorOptions.Global.DefaultRuleLevelCascadeMode = CascadeMode.Stop;

            services.AddValidatorsFromAssembly(assembly);

            return services;
        }
    }
}
