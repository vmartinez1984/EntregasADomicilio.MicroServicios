using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EntregasADomicilio.Admin.BusinessLayer.Dtos
{
    public class CategoriaDto
    {
        public string Id { get; set; }

        public string Nombre { get; set; }

        public bool EstaActivo { get; set; } = true;
    }

    public class CategoriaDtoIn
    {
        [Required, MinLength(5), MaxLength(50)]
        [DefaultValue("")]
        public string Nombre { get; set; }

        public bool EstaActivo { get; set; } = true;
                
        public Guid Id { get; set; } = Guid.NewGuid();
    }

    public class CategoriaDtoUpdate
    {
        public string Nombre { get; set; }

        public bool EstaActivo { get; set; } = true;        
    }
}
