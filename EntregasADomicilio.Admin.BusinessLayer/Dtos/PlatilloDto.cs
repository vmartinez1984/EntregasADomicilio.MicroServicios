using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace EntregasADomicilio.Admin.BusinessLayer.Dtos
{
    public class PlatilloDtoIn
    {
        [Required]
        public string Nombre { get; set; }

        [Required]
        public Guid Guid { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(500)]
        public string Descripcion { get; set; }

        [Required]
        public decimal Precio { get; set; }

        [Required]
        public IFormFile FormFile { get; set; }

        [Required]
        public int CategoriaId { get; set; }
    }

    public class PlatilloDto
    {
        public int Id { get; set; }

        public CategoriaDto Categoria { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public decimal Precio { get; set; }
    }
}
