using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace EntregasADomicilio.Admin.BusinessLayer.Dtos
{
    public class PlatilloDtoIn
    {
        public Guid? Id { get; set; } = Guid.NewGuid();

        [Required]
        public string Nombre { get; set; }        

        [Required]
        [MaxLength(500)]
        public string Descripcion { get; set; }

        [Required]
        public decimal Precio { get; set; }

        [Required]
        public IFormFile FormFile { get; set; }

        [Required]
        public string Categoria { get; set; }
    }

    public class PlatilloDto
    {
        public Guid Id { get; set; }

        public string Categoria { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public decimal Precio { get; set; }

        public bool EstaActivo { get; set; }
    }
}
