using System;

namespace EntregasADomicilio.Admin.BusinessLayer.Dtos
{
    public class CategoriaDto
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public bool EstaActivo { get; set; } = true;
    }

    public class CategoriaDtoIn
    {
        public string Nombre { get; set; }

        public bool EstaActivo { get; set; } = true;

        public Guid  Guid { get; set; } = Guid.NewGuid();
    }
}
