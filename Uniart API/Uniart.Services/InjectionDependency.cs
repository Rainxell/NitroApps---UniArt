using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Uniart.DataAccess;
using Uniart.DataAccess.ComisionRepos;
using Uniart.DataAccess.Envio_Servicio_CiudadRepos;
using Uniart.DataAccess.EnvioRepos;
using Uniart.DataAccess.Variacion_DetalleRepos;
using Uniart.Services.Variacion_DetalleServ;

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
            services.AddTransient<IUsuarioTarjetaRepository, UsuarioTarjetaRepository>();
            services.AddTransient<IUsuarioTarjetaService, UsuarioTarjetaService>();
            services.AddTransient<ITecnicaRepository, TecnicaRepository>();
            services.AddTransient<ITecnicaService, TecnicaService>();
            services.AddTransient<ITemaRepository, TemaRepository>();
            services.AddTransient<ITemaService, TemaService>();
            services.AddTransient<ITarjetaRepository, TarjetaRepository>();
            services.AddTransient<ITarjetaService, TarjetaService>();
            services.AddTransient<IServicio_VariacionRepository, Servicio_VariacionRepository>();
            services.AddTransient<IServicio_VariacionService, Servicio_VariacionService>();
            services.AddTransient<IServicio_TemaRepository, Servicio_TemaRepository>();
            services.AddTransient<IServicio_TemaService, Servicio_TemaService>();
            services.AddTransient<IServicio_FormatoRepository, Servicio_FormatoRepository>();
            services.AddTransient<IServicio_FormatoService, Servicio_FormatoService>();
            services.AddTransient<IServicio_CaracteristicaRepository, Servicio_CaracteristicaRepository>();
            services.AddTransient<IServicio_CaracteristicaService, Servicio_CaracteristicaService>();
            services.AddTransient<IServicioRepository, ServicioRepository>();
            services.AddTransient<IServicioService, ServicioService>();
            services.AddTransient<IReviewRepository, ReviewRepository>();
            services.AddTransient<IReviewService, ReviewService>();
            services.AddTransient<IRed_Social_ArtistaRepository, Red_Social_ArtistaRepository>();
            services.AddTransient<IRed_Social_ArtistaService, Red_Social_ArtistaService>();
            services.AddTransient<IPropuestaRepository, PropuestaRepository>();
            services.AddTransient<IPropuestaService, PropuestaService>();
            services.AddTransient<IMensajeRepository, MensajeRepository>();
            services.AddTransient<IMensajeService, MensajeService>();
            services.AddTransient<ILicenciaRepository, LicenciaRepository>();
            services.AddTransient<ILicenciaService, LicenciaService>();
            services.AddTransient<ICaracteristica_OptionRepository, Caracteristica_OptionRepository>();
            services.AddTransient<ICaracteristicas_OpcionesService, Caracterisiticas_OpcionesService>();
            services.AddTransient<IChatRepository, ChatRepository>();
            services.AddTransient<IChatService, ChatService>();
            services.AddTransient<IComisionRepository, ComisionRepository>();
            services.AddTransient<IComisionService, ComisionService>();
            services.AddTransient<IFormatoRepository, FormatoRepository>();
            services.AddTransient<IFormatoService, FormatoService>();
            services.AddTransient<IEstiloRepository, EstiloRepository>();
            services.AddTransient<IEstiloService, EstiloService>();
            services.AddTransient<IEnvio_Servicio_CiudadRepository, Envio_Servicio_CiudadRepository>();
            services.AddTransient<IEnvio_Servicio_CiudadService, Envio_Servicio_CiudadService>();
            services.AddTransient<IEnvioRepository, EnvioRepository>();
            services.AddTransient<IEnvioService, EnvioService>();
            return services.AddScoped<IUsuarioRepository, UsuarioRepository>()
                .AddScoped<IUsuarioService, UsuarioService>();
        }
    }
}
