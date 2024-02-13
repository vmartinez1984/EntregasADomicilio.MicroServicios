using EntregasADomicilio.Web.Repositorios.Sql.Contexts;
using EntregasADomicilio.Web.Repositorios.Sql.Entities;
using EntregasADomicilio.Web.Repositorios.Sql.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntregasADomicilio.Web.Repositorios.Sql.Repository
{
    public class CategoriaRepositorio : ICategoria
    {
        private readonly AppDbContext _appDbContext;

        public CategoriaRepositorio(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Categoria>> ObtenerTodos()
        {
            return await _appDbContext.Categoria.Where(x => x.EstaActivo).ToListAsync();
        }
    }
}
