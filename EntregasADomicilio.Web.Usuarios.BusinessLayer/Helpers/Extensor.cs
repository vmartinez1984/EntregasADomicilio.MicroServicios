using AutoMapper;
using EntregasADomicilio.Admin.WebData.Core.Interfaces.Web.Usuarios;
using EntregasADomicilio.Web.Usuarios.BusinessLayer.Bl;
using EntregasADomicilio.Web.Usuarios.Repositorio.Sql.Contexts;
using EntregasADomicilio.Web.Usuarios.Repositorio.Sql.Repositorios;
using EntregasADomilicio.Web.Pedidos.Repositorios.Ws;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace EntregasADomicilio.Web.Usuarios.BusinessLayer.Helpers
{
    public static class Extensor
    {
        public static void AddUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IClienteBl, ClienteBl>();
            services.AddScoped<IUsuarioBl, UsuarioBl>();
            services.AddScoped<IPedidoBl, PedidoBl>();

            services.AddScoped<AppDbContext>();            
            services.AddScoped<IRepositorio, RepositorioU>();
            services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
            services.AddScoped<IDireccionRepositorio, DireccionRepositorio>();
            services.AddPedidoRepositorio();

            //Mappers
            var mapperConfig = new MapperConfiguration(mapperConfig =>
            {
                mapperConfig.AddProfile<Mappers>();
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }

    public static class JwtExtensions
    {
        public const string SecurityKey = "VineAComala.ABuscarAMiPadreUnTalPedroParamo";

        public static void AddJwtAuthentication(this IServiceCollection services)
        {
            services.AddAuthentication(opt => {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })               
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    //ValidIssuer = "https://localhost:5002",
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecurityKey))
                };
            });
        }
    }


}