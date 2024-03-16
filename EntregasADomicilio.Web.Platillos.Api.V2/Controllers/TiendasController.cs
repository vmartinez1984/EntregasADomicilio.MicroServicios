using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EntregasADomicilio.Web.Platillos.Api.V2.Interfaces;
using EntregasADomicilio.Web.Platillos.Api.V2.Dtos;
using EntregasADomicilio.Web.Platillos.Api.V2.Entities;

namespace EntregasADomicilio.Web.Platillos.Api.V2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiendasController : ControllerBase
    {
        private readonly IRepositorio _repositorio;

        public TiendasController(IRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            TiendaDto tiendaDto;
            Tienda tienda;

            tienda = await _repositorio.Tienda.ObtenerAsync();
            tiendaDto = new TiendaDto
            {
                AcercaDeNosotros = new AcercaDeNosotrosDto
                {
                    Contenido = tienda.AcercaDeNosotros.Contenido,
                    Titulo = tienda.AcercaDeNosotros.Titulo
                },
                CoordenadasGps = tienda.CoordenadasGps,
                Correo = tienda.Correo,
                Direccion = tienda.Direccion,
                Horarios = ObtenerHorarios(tienda.Horarios),
                Nombre = tienda.Nombre,
                Tarjetas = ObtenerTarjetas(tienda.Tarjetas),
                Telefono = tienda.Telefono,
            };

            return Ok(tiendaDto);
        }

        private List<TarjetaDto> ObtenerTarjetas(List<Tarjeta> tarjetas)
        {
            List<TarjetaDto> lista;

            lista = new List<TarjetaDto>();
            foreach (var item in tarjetas)
            {
                lista.Add(new TarjetaDto
                {
                    Contenido = item.Contenido,
                    Icon = item.Icono,
                    Titulo = item.Titulo,
                });
            }

            return lista;
        }

        private List<HorarioDto> ObtenerHorarios(List<Horario> horarios)
        {
            List<HorarioDto> horarioDtos;

            horarioDtos = new List<HorarioDto>();
            foreach (var item in horarios)
            {
                horarioDtos.Add(new HorarioDto
                {
                    Dias = item.Dias,
                    Horas = item.Horas
                });
            }

            return horarioDtos;
        }
    }
}
