using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Uniart.DataAccess;
using Uniart.DataAccess.Variacion_DetalleRepos;
using Uniart.Services.Variacion_DetalleServ;
using Uniart.DataAccess.ComisionRepos;

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
            services.AddTransient<IRed_SocialRepository, Red_SocialRepository>();
            services.AddTransient<IRed_SocialService, Red_SocialService>();
            services.AddTransient<IVariacion_DetalleRepository, Variacion_DetalleRepository>();
            services.AddTransient<IVariacion_DetalleService, Variacion_DetalleService>();
            services.AddTransient<IValoracionRepository, ValoracionRepository>();
            services.AddTransient<IValoracionServices, ValoracionService>();

            services.AddTransient<ICaracteristica_OptionRepository, Caracteristica_OptionRepository>();
            services.AddTransient<ICaracteristicas_OpcionesService, Caracterisiticas_OpcionesService>();

            services.AddTransient<ICaracteristica_OptionRepository, Caracteristica_OptionRepository>();
            services.AddTransient<ICaracteristicas_OpcionesService, Caracterisiticas_OpcionesService>();

            services.AddTransient<IChatRepository, ChatRepository>();
            services.AddTransient<IChatService, ChatService>();

            services.AddTransient<IComisionRepository, ComisionRepository>();
            services.AddTransient<IComisionService, ComisionService>();

            return services.AddScoped<IUsuarioRepository, UsuarioRepository>()
                .AddScoped<IUsuarioService, UsuarioService>();
        }
    }
}
