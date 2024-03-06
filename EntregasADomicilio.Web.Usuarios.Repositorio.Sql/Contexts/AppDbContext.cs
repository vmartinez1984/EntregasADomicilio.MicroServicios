using EntregasADomicilio.Admin.WebData.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EntregasADomicilio.Web.Usuarios.Repositorio.Sql.Contexts
{
    public class AppDbContext : DbContext ///: IdentityDbContext
    {
        private readonly string _connectionString;

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Direccion> Direccion { get; set; }

        public AppDbContext()
        {
            _connectionString = "Data Source=192.168.1.86;Initial Catalog=EntregasADomicilio; Persist Security Info=True;User ID=sa;Password=Macross#2012; TrustServerCertificate=True;";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }
    }
}
