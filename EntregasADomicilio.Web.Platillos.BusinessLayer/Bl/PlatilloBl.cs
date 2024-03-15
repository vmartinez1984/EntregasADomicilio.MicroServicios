using AutoMapper;
using EntregasADomicilio.StoreFiles;
using EntregasADomicilio.Web.Platillos.BusinessLayer.Dtos;
using EntregasADomicilio.Web.Platillos.BusinessLayer.Interfaces;
using EntregasADomicilio.Web.Platillos.Core.Entities;
using EntregasADomicilio.Web.Platillos.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntregasADomicilio.Web.Platillos.BusinessLayer.Bl
{
    public class PlatilloBl : IPlatilloBl
    {
        private readonly IRepositorio _repositorio;
        private readonly IMapper _mapper;
        private readonly AlmacenDeArchivosFirebase _almacenadorDeArchivos;

        public PlatilloBl(IRepositorio repositorio, IMapper mapper,
            AlmacenDeArchivosFirebase almacenadorDeArchivosFirebaseStorage
        )
        {
            this._repositorio = repositorio;
            this._mapper = mapper;
            _almacenadorDeArchivos = almacenadorDeArchivosFirebaseStorage;
        }

        public async Task<byte[]> ObtenerBytesAsync(Guid platilloId)
        {
            Platillo platillo;

            platillo = await _repositorio.Platillo.ObtenerPorIdAsync(platilloId.ToString());

            return await ObtenerBytesDeAlmacenAsync(platillo.ListaDeArchivos, "FirebaseStorage");
        }

        private async Task<byte[]> ObtenerBytesDeAlmacenAsync(List<Archivo> listaDeArchivos, string almacen)
        {
            byte[] bytes = null;
            Archivo archivo;


            archivo = listaDeArchivos.Where(x => x.NombreDelAlmacen == almacen).FirstOrDefault();
            if (archivo != null)
                bytes = await _almacenadorDeArchivos.Obtener(archivo.RutaDelArchivo);

            return bytes;
        }

        public async Task<List<PlatilloDto>> ObtnerTodos()
        {
            List<PlatilloDto> platilloDtos;
            List<Platillo> platillos;

            platillos = await _repositorio.Platillo.ObtenerTodosAsync();
            platilloDtos = _mapper.Map<List<PlatilloDto>>(platillos);

            return platilloDtos;
        }

        public async Task<PlatilloDto> ObtenerPorId(string id)
        {
            PlatilloDto platilloDtos;
            Platillo platillos;

            platillos = await _repositorio.Platillo.ObtenerPorIdAsync(id);
            platilloDtos = _mapper.Map<PlatilloDto>(platillos);

            return platilloDtos;
        }
    }
}