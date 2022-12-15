using MediatR;
using System.Reflection;
using System.Runtime.Loader;

namespace Project.Extensions
{
    public static class MediatRExtension
    {
        private static Assembly assembly =
            AssemblyLoadContext.Default.LoadFromAssemblyPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"Project.Infrastructure.dll"));

        public static IServiceCollection AddMediatREntension(this IServiceCollection service)
        {
            service.AddMediatR(assembly);
            return service;
        }
    }
}
