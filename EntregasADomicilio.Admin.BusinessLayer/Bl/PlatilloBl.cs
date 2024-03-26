
using AutoMapper;
using EntregasADomicilio.Admin.BusinessLayer.Constants;
using EntregasADomicilio.Admin.BusinessLayer.Dtos;
using EntregasADomicilio.Admin.Platillos.Core.Entidades;
using EntregasADomicilio.Admin.Platillos.Core.Interfaces;
using EntregasADomicilio.StoreFiles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EntregasADomicilio.Admin.BusinessLayer.Bl
{
    public class PlatilloBl //: IPlatilloBl
    {
        private readonly IRepositorio _repositorySql;
        //private readonly IAlmacenadorDeArchivos _almacenDeArchivosVMtz;
        //private readonly IAlmacenadorDeArchivosS3 _almacenadorDeArchivosS3;
        private readonly AlmacenDeArchivosFirebase _almacenadorDeArchivosFirebaseStorage;
        private readonly IMapper _mapper;
        private readonly string _contenedor = "platillos";

        public PlatilloBl(
            IRepositorio repositorySql,
            //IAlmacenadorDeArchivos almacenadorDeArchivos,
            //IAlmacenadorDeArchivosS3 almacenadorDeArchivosS3,
            AlmacenDeArchivosFirebase almacenadorDeArchivosFirebaseStorage,
            IMapper mapper
        )
        {
            _repositorySql = repositorySql;
            //_almacenDeArchivosVMtz = almacenadorDeArchivos;
            //_almacenadorDeArchivosS3 = almacenadorDeArchivosS3;
            _almacenadorDeArchivosFirebaseStorage = almacenadorDeArchivosFirebaseStorage;
            _mapper = mapper;
        }

        //public async Task ActualizarAsync(int id, PlatilloDtoIn platillo)
        //{
        //    Platillo entity;

        //    entity = await _repositorySql.Platillo.ObtenerPorIdAsync(id);
        //    entity = _mapper.Map(platillo, entity);
        //    if (platillo.FormFile != null)
        //    {
        //        foreach (var item in entity.ListaDeArchivos)
        //        {
        //            item.EstaActivo = false;
        //        }
        //        entity.ListaDeArchivos.AddRange(await ObtenerListaDeArchivosAsync(platillo));
        //    }

        //    await _repositorySql.Platillo.ActualizarAsync(entity);
        //}

        public async Task<string> AgregarAsync(PlatilloDtoIn platillo)
        {
            Platillo entity;

            if (platillo.Id == Guid.Empty || platillo.Id == null)
                platillo.Id = Guid.NewGuid();
            entity = _mapper.Map<Platillo>(platillo);
            entity.ListaDeArchivos = await ObtenerListaDeArchivosAsync(platillo);
            await _repositorySql.Platillo.AgregarAsync(entity);

            return entity.Id;
        }

        private async Task<List<Archivo>> ObtenerListaDeArchivosAsync(PlatilloDtoIn platillo)
        {
            List<Archivo> archivos;
            string aliasDelArchivo;

            aliasDelArchivo = $"{platillo.Id}{Path.GetExtension(platillo.FormFile.FileName)}";
            //Archivo archivoVMtz = await GuardarEnAlamcenVMtz(platillo, aliasDelArchivo, AlmacenDeArchivos.AlmacenVMtz);
            //Archivo archivoS3 = await GuardarEnAlamcenVMtz(platillo, aliasDelArchivo, AlmacenDeArchivos.MinioS3);
            Archivo archivoFireStore = await GuardarEnAlamcenVMtz(platillo, aliasDelArchivo, AlmacenDeArchivos.FirebaseStorage);
            archivos = new List<Archivo>();
            //if (archivoVMtz != null)
            //    archivos.Add(archivoVMtz);
            //if (archivoS3 != null)
            //    archivos.Add(archivoS3);
            if (archivoFireStore != null)
                archivos.Add(archivoFireStore);

            return archivos;
        }

        private async Task<Archivo> GuardarEnAlamcenVMtz(PlatilloDtoIn platillo, string aliasDelArchivo, string almacen)
        {
            try
            {
                string rutaDelArchvo;

                switch (almacen)
                {
                    //case AlmacenDeArchivos.AlmacenVMtz:
                    //    rutaDelArchvo = await _almacenDeArchivosVMtz.Guardar(_contenedor, aliasDelArchivo, platillo.FormFile);
                    //    break;
                    //case AlmacenDeArchivos.MinioS3:
                    //    rutaDelArchvo = await _almacenadorDeArchivosS3.Guardar(_contenedor, aliasDelArchivo, platillo.FormFile);
                    //    break;
                    default:
                        rutaDelArchvo = await _almacenadorDeArchivosFirebaseStorage.Guardar(_contenedor, aliasDelArchivo, platillo.FormFile);
                        break;
                }
                return new Archivo
                {
                    NombreDelArchivo = platillo.FormFile.FileName,
                    NombreDelAlmacen = almacen,
                    RutaDelArchivo = rutaDelArchvo,
                    ContentType = platillo.FormFile.ContentType,
                    EstaActivo = true,
                    FechaDeRegistro = DateTime.Now,
                    AliasDelArchivo = aliasDelArchivo
                };
            }
            catch (Exception)
            {

                return null;
            }
        }

        //public async Task BorrarAsync(int id)
        //{
        //    Platillo platillo;

        //    platillo = await _repositorySql.Platillo.ObtenerPorIdAsync(id);
        //    platillo.EstaActivo = false;

        //    await _repositorySql.Platillo.ActualizarAsync(platillo);
        //}

        //public async Task<byte[]> ObtenerBytesAsync(int platilloId)
        //{
        //    byte[] bytes;
        //    Platillo platillo;

        //    platillo = await _repositorySql.Platillo.ObtenerPorIdAsync(platilloId);
        //    try
        //    {
        //        bytes = await ObtenerBytesDeAlmacenAsync(platillo.ListaDeArchivos, AlmacenDeArchivos.AlmacenVMtz);
        //    }
        //    catch (Exception)
        //    {
        //        bytes = await ObtenerBytesDeAlmacenAsync(platillo.ListaDeArchivos, AlmacenDeArchivos.FirebaseStorage);
        //    }

        //    return bytes;
        //}

        private async Task<byte[]> ObtenerBytesDeAlmacenAsync(List<Archivo> listaDeArchivos, string almacen)
        {
            byte[] bytes = null;
            Archivo archivo;

            switch (almacen)
            {
                case AlmacenDeArchivos.FirebaseStorage:
                    archivo = listaDeArchivos.Where(x => x.NombreDelAlmacen == AlmacenDeArchivos.FirebaseStorage).FirstOrDefault();
                    if (archivo != null)
                        bytes = await _almacenadorDeArchivosFirebaseStorage.Obtener(archivo.RutaDelArchivo);
                    break;
                //case AlmacenDeArchivos.MinioS3:
                //    archivo = listaDeArchivos.Where(x => x.NombreDelAlmacen == AlmacenDeArchivos.MinioS3).FirstOrDefault();
                //    if (archivo != null)
                //        bytes = await _almacenadorDeArchivosS3.ObtenerBytes(_contenedor, archivo.AliasDelArchivo);
                //    break;

                //case AlmacenDeArchivos.Local:
                //    //archivo = listaDeArchivos.Where(x => x.NombreDelAlmacen == AlmacenDeArchivos.Local).FirstOrDefault();
                //    //if (archivo != null)
                //    //    bytes = await _almacenadorDeArchivos.Obtener(archivo.RutaDelArchivo);
                //    bytes = null;
                //    break;

                //case AlmacenDeArchivos.AlmacenVMtz:
                //    archivo = listaDeArchivos.Where(x => x.NombreDelAlmacen == AlmacenDeArchivos.AlmacenVMtz).FirstOrDefault();
                //    if (archivo != null)
                //        bytes = await _almacenDeArchivosVMtz.Obtener(archivo.RutaDelArchivo);
                //    break;

                default:
                    bytes = null;
                    break;
            }

            return bytes;
        }

        public async Task<List<PlatilloDto>> ObtenerTodos()
        {
            List<Platillo> entities;
            List<PlatilloDto> dtos;

            entities = await _repositorySql.Platillo.ObtenerTodosAsync();
            dtos = _mapper.Map<List<PlatilloDto>>(entities);

            return dtos;
        }

        public async Task<List<PlatilloDto>> ObtenerTodosAsync(bool? estaActivo = null)
        {
            List<Platillo> entities;
            List<PlatilloDto> dtos;

            entities = await _repositorySql.Platillo.ObtenerTodosAsync(estaActivo);
            dtos = _mapper.Map<List<PlatilloDto>>(entities);

            return dtos;
        }

        public async Task<PlatilloDto> ObtenerPorId(Guid platilloId)
        {
            Platillo platillo;
            PlatilloDto platilloDto;

            platillo = await _repositorySql.Platillo.ObtenerPorIdAsync(platilloId.ToString());
            platilloDto = _mapper.Map<PlatilloDto>(platillo);

            return platilloDto;
        }

        public async Task<byte[]> ObtenerBytesAsync(Guid platilloId)
        {
            Platillo platillo;

            platillo = await _repositorySql.Platillo.ObtenerPorIdAsync(platilloId.ToString());

            return await ObtenerBytesDeAlmacenAsync(platillo.ListaDeArchivos, AlmacenDeArchivos.FirebaseStorage);
        }

        public async Task ActualizarAsync(Guid id, PlatilloDtoUpdate platillo)
        {
            Platillo platilloEntity;

            platilloEntity = await _repositorySql.Platillo.ObtenerPorIdAsync(id.ToString());
            platilloEntity = _mapper.Map(platillo, platilloEntity);
            if(platillo.FormFile is not null)
            {
                Archivo archivo;

                archivo = platilloEntity.ListaDeArchivos
                    .Where(x => x.NombreDelAlmacen == AlmacenDeArchivos.FirebaseStorage)
                    .FirstOrDefault();
                archivo.RutaDelArchivo =
                await _almacenadorDeArchivosFirebaseStorage.EditarArchivo(
                    _contenedor,
                    archivo.AliasDelArchivo,
                    platillo.FormFile
                );
            }

            await _repositorySql.Platillo.ActualizarAsync(platilloEntity);
        }

        public Task BorrarAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
