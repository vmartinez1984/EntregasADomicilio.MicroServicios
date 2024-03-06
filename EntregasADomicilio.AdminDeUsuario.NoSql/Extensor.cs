using EntregasADomicilio.Web.Usuarios.Core.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntregasADomicilio.AdminDeUsuario.NoSql
{
    public static class Extensor
    {
        public static void AddRepositorioUsuarioNoSql(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorioNoSql>();
            //services.AddIdentity<IdentityUser, IdentityRole>()
            //    .AddEntityFrameworkStores<AppDbUsersContext>()
            //    .AddDefaultTokenProviders();
        }
    }
}
