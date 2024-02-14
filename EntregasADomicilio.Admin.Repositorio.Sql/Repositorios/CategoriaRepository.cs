using EntregasADomicilio.Admin.Repositorio.Sql.Contexts;
using EntregasADomicilio.Admin.Repositorio.Sql.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntregasADomicilio.Admin.Repositorio.Sql.Entities
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _appDbContext;

        public CategoriaRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task Actualizar(Categoria categoria)
        {
            _appDbContext.Categoria.Update(categoria);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<int> Agregar(Categoria categoria)
        {
            _appDbContext.Categoria.Add(categoria);
            await _appDbContext.SaveChangesAsync();

            return categoria.Id;
        }

        public async Task Borrar(int categoriaId)
        {
            Categoria categoria;

            categoria = await _appDbContext.Categoria.Where(x => x.Id == categoriaId).FirstOrDefaultAsync();
            categoria.EstaActivo = false;
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<Categoria> ObtenerPorGuidAsync(Guid guid)
        {
            return await _appDbContext.Categoria.Where(x=>x.Guid == guid).FirstOrDefaultAsync();
        }

        public async Task<Categoria> ObtenerPorIdAsync(int categoriaId)
        {
            return await _appDbContext.Categoria.Where(x => x.Id == categoriaId).FirstOrDefaultAsync();
        }

        public async Task<List<Categoria>> ObtenerTodos(bool? estaActivo = null)
        {
            if (estaActivo == null)
                return await _appDbContext.Categoria.ToListAsync();
            else
                return await _appDbContext.Categoria.Where(x => x.EstaActivo == estaActivo).ToListAsync();
        }
    }
}
