using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EntregasADomiclio.AdminDeUsuario.Sql.Contexts
{
    public class AppDbUsersContext : IdentityDbContext
    {
        private readonly string _connectionString;

        public AppDbUsersContext()
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
