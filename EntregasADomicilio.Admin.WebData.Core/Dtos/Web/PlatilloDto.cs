﻿namespace EntregasADomicilio.Admin.WebData.Core.Dtos.Web
{
    public class PlatilloDto
    {
        public int Id { get; set; }

        public CategoriaDto Categoria { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public decimal Precio { get; set; }
    }
}
