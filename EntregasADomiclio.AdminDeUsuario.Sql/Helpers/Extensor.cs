using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using EntregasADomiclio.AdminDeUsuario.Sql.Contexts;

namespace EntregasADomiclio.AdminDeUsuario.Sql.Helpers
{
    public static class Extensor
    {
        public static void AddRepositorioUsuario(this IServiceCollection services)
        {
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbUsersContext>()
                .AddDefaultTokenProviders();
        }
    }
}
