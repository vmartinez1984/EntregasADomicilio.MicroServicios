using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EntregasADomicilio.Admin.WebData.Core.Entities
{
    public class Direccion
    {
        public int Id { get; set; }

        [ForeignKey(nameof(Usuario))]
        public int UsuarioId { get; set; }

        public virtual Cliente Usuario { get; set; }

        [MaxLength(250)]
        public string CalleYNumero { get; set; }

        [MaxLength(250)]
        public string Referencias { get; set; }

        [MaxLength(250)]
        public string Alcaldia { get; set; }

        [MaxLength(250)]
        public string Estado { get; set; }

        [MaxLength(5)]
        public string CodigoPostal { get; set; }

        [MaxLength(25)]
        public string Latitud { get; set; }

        [MaxLength(25)]
        public string Longitud { get; set; }

        public int Orden { get; set; } = 1;
    }
}
