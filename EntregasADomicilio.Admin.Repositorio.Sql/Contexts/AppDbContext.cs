using EntregasADomicilio.Admin.Repositorio.Sql.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EntregasADomicilio.Admin.Repositorio.Sql.Contexts
{
    public class AppDbContext : DbContext
    {
        private readonly string _connectionString;

        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Direccion> Direccion { get; set; }

        public DbSet<Platillo> Platillo { get; set; }

        public DbSet<Pedido> Pedido { get; set; }

        public DbSet<DetalleDelPedido> DetalleDelPedido { get; set; }


        public AppDbContext()
        {
            _connectionString = "Data Source=192.168.1.86; Initial Catalog=EntregasADomicilio; Persist Security Info=True; User ID=sa; Password=Macross#2012; TrustServerCertificate=True;";
        }

        public AppDbContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("EntregasADomicilio");
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