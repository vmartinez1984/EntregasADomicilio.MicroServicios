using AutoMapper;
using EntregasADomicilio.Admin.BusinessLayer.Dtos;
using EntregasADomicilio.Admin.Repositorio.Sql.Entities;
using EntregasADomicilio.Admin.Repositorio.Sql.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EntregasADomicilio.Admin.BusinessLayer.Bl
{
    public class CategoriaBl
    {
        private readonly IRepositorySql _repositorySql;
        private readonly IMapper _mapper;

        public CategoriaBl(IRepositorySql repositorySql, IMapper mapper)
        {
            this._repositorySql = repositorySql;
            this._mapper = mapper;
        }

        public async Task Actualizar(int categoriaId, CategoriaDtoIn categoriaDtoIn)
        {
            Categoria categoria;

            categoria = await _repositorySql.Categoria.ObtenerPorIdAsync(categoriaId);
            _mapper.Map(categoriaDtoIn, categoria);

            await _repositorySql.Categoria.Actualizar(categoria);
        }

        public async Task<int> Agregar(CategoriaDtoIn categoria)
        {
            Categoria entity;

            entity = _mapper.Map<Categoria>(categoria);
            if(entity.Guid == Guid.Empty)
                entity.Guid = Guid.NewGuid();
            await _repositorySql.Categoria.Agregar(entity);

            return entity.Id;
        }

        public Task Borrar(int categoriaId)
        {
            throw new NotImplementedException();
        }

        public async Task<CategoriaDto> ObtenerPorGuid(Guid guid)
        {
            CategoriaDto categoriaDto;
            Categoria categoria;

            categoria = await _repositorySql.Categoria.ObtenerPorGuidAsync(guid);
            categoriaDto = _mapper.Map<CategoriaDto>(categoria);

            return categoriaDto;
        }

        public async Task<List<CategoriaDto>> ObtenerTodos()
        {
            List<CategoriaDto> dtos;
            List<Categoria> entities;

            entities = await _repositorySql.Categoria.ObtenerTodos();
            dtos = _mapper.Map<List<CategoriaDto>>(entities);

            return dtos;
        }
    }
}
