using AutoMapper;
using EntregasADomicilio.Admin.WebData.Core.Interfaces.Web.Usuarios;
using EntregasADomicilio.Web.Usuarios.BusinessLayer.Bl;
using EntregasADomicilio.Web.Usuarios.Repositorio.Sql.Contexts;
using EntregasADomicilio.Web.Usuarios.Repositorio.Sql.Repositorios;
using EntregasADomilicio.Web.Pedidos.Repositorios.Ws;
using Microsoft.Extensions.DependencyInjection;
using JwtTokenService;
using JwtTokenService.Helpers;
using Microsoft.Extensions.Configuration;
using EntregasADomicilio.Web.Usuarios.Core.Interfaces.Repositories;
using EntregasADomiclio.AdminDeUsuario.Sql.Repositorios;
using EntregasADomicilio.AdminDeUsuario.NoSql;
using EntregasADomicilio.Web.Pedidos.Repositorios.Sql;
using EntregasADomiclio.AdminDeUsuario.Sql.Helpers;

namespace EntregasADomicilio.Web.Usuarios.BusinessLayer.Helpers
{
    public static class Extensor
    {
        public static void AddUnitOfWork(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IClienteBl, ClienteBl>();
            services.AddScoped<IUsuarioBl, UsuarioBl>();
            services.AddScoped<IPedidoBl, PedidoBl>();

            services.AddScoped<EntregasADomicilio.Web.Usuarios.Repositorio.Sql.Contexts.AppDbContext>();            
            services.AddScoped<IRepositorio, RepositorioU>();
            services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
            services.AddScoped<IDireccionRepositorio, DireccionRepositorio>();
            services.AddSingleton<JwtToken>();
            services.AddPedidoRepositorio();

            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorioNoSql>();
            //services.AddIdentity<IdentityUser, IdentityRole>()
            //   .AddEntityFrameworkStores<AppDbUsersContext>()
            //   .AddDefaultTokenProviders();
            //services.AddRepositorioUsuario();

            services.AddJwtAuthentication(configuration);

            //Mappers
            var mapperConfig = new MapperConfiguration(mapperConfig =>
            {
                mapperConfig.AddProfile<Mappers>();
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }

}