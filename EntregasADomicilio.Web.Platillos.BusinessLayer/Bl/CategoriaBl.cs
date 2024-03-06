using AutoMapper;
using EntregasADomicilio.Web.Platillos.BusinessLayer.Dtos;
using EntregasADomicilio.Web.Platillos.BusinessLayer.Interfaces;
using EntregasADomicilio.Web.Platillos.Core.Entities;
using EntregasADomicilio.Web.Platillos.Core.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EntregasADomicilio.Web.Platillos.BusinessLayer.Bl
{
    public class CategoriaBl : ICategoriaBl
    {
        private readonly IRepositorio _repositorio;
        private readonly IMapper _mapper;

        public CategoriaBl(IRepositorio repositorio, IMapper mapper)
        {
            this._repositorio = repositorio;
            this._mapper = mapper;
        }

        public async Task<List<CategoriaDto>> ObtenerTodos()
        {
            List<Categoria> categorias;
            List<CategoriaDto> categoriaDtos;

            categorias = await _repositorio.Categoria.ObtenerTodosAsync();
            categoriaDtos = _mapper.Map<List<CategoriaDto>>(categorias);

            return categoriaDtos;
        }
    }
}
