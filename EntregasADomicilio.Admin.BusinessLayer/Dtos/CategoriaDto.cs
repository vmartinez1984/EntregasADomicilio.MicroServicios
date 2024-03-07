using System;

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
