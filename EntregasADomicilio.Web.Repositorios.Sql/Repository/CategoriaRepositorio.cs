using EntregasADomicilio.Web.Platillos.Repositorios.Sql.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntregasADomicilio.Web.Platillos.Repositorios.Sql.Repository
{
    public class CategoriaRepositorio //: ICategoria
    {
        private readonly AppDbContext _appDbContext;

        public CategoriaRepositorio(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }       

        //public async Task<List<Categoria>> ObtenerTodosAsync()
        //{
        //    return await _appDbContext.Categoria.Where(x => x.EstaActivo).ToListAsync();
        //}
    }
}
