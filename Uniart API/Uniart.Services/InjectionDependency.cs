using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Uniart.DataAccess;

namespace Uniart.Services
{
    public static class InjectionDependency
    {
        public static IServiceCollection AddInjection(this IServiceCollection services)
        {
            services.AddTransient<IArtistaRepository, ArtistaRepository>();
            services.AddTransient<IArtistaService, ArtistaService>();
            services.AddTransient<IPaisRepository, PaisRepository>();
            services.AddTransient<IPaisService, PaisService>();
            services.AddTransient<ICiudadRepository, CiudadRepository>();
            services.AddTransient<ICiudadService, CiudadService>();
            return services.AddScoped<IUsuarioRepository, UsuarioRepository>()
                .AddScoped<IUsuarioService, UsuarioService>();
        }
    }
}
