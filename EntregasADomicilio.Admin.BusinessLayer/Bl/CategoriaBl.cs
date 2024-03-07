using AutoMapper;
using EntregasADomicilio.Admin.BusinessLayer.Dtos;
using EntregasADomicilio.Admin.Platillos.Core.Entidades;
using EntregasADomicilio.Admin.Platillos.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EntregasADomicilio.Admin.BusinessLayer.Bl
{
    public class CategoriaBl
    {
        private readonly IRepositorio _repositorySql;
        private readonly IMapper _mapper;

        public CategoriaBl(IRepositorio repositorySql, IMapper mapper)
        {
            this._repositorySql = repositorySql;
            this._mapper = mapper;
        }

        public async Task Actualizar(Guid categoriaId, CategoriaDtoUpdate categoriaDtoIn)
        {
            Categoria categoria;

            categoria = await _repositorySql.Categoria.ObtenerPorIdAsync(categoriaId.ToString());            
            categoria = _mapper.Map(categoriaDtoIn, categoria);

            await _repositorySql.Categoria.Actualizar(categoria);
        }

        public async Task<string> Agregar(CategoriaDtoIn categoria)
        {
            Categoria entity;

            entity = _mapper.Map<Categoria>(categoria);
            if (categoria.Id == Guid.Empty)
                entity.Id = Guid.NewGuid().ToString();
            await _repositorySql.Categoria.AgregarAsync(entity);

            return entity.Id;
        }

        public Task Borrar(int categoriaId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ExisteAsync(string categoria)
        {
            return await _repositorySql.Categoria.ExisteAsync(categoria);
        }

        public async Task<CategoriaDto> ObtenerPorGuid(Guid id)
        {
            CategoriaDto categoriaDto;
            Categoria categoria;

            categoria = await _repositorySql.Categoria.ObtenerPorIdAsync(id.ToString());
            categoriaDto = _mapper.Map<CategoriaDto>(categoria);

            return categoriaDto;
        }

        public async Task<List<CategoriaDto>> ObtenerTodos()
        {
            List<CategoriaDto> dtos;
            List<Categoria> entities;

            entities = await _repositorySql.Categoria.ObtenerTodosAsync();
            dtos = _mapper.Map<List<CategoriaDto>>(entities);

            return dtos;
        }
    }
}
