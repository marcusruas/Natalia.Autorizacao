using Microsoft.Extensions.DependencyInjection;
using Natalia.Autorizacao.Infrastructure.Repositories;
using System.Reflection;

namespace Natalia.Autorizacao.Infrastructure
{
    public static class InjecaoDependencia
    {
        public static IServiceCollection AdicionarDependencias(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            return services;
        }
    }
}
