using EntregasADomicilio.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntregasADomicilio.Web.Pedidos.Repositorios.Sql
{
    public class AppDbContext: DbContext
    {
        private readonly string _connectionString;

        public DbSet<Pedido> Pedido { get; set; }        

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
