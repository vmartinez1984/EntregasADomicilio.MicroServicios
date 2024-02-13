using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntregasADomicilio.Web.Repositorios.Sql.Interfaces
{
    public interface IRepositorio
    {
        public IPlatillo Platillo { get; set; }

        public ICategoria Categoria { get; set; }
    }
}
