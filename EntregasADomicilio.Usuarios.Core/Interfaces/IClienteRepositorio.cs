using EntregasADomicilio.Usuarios.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntregasADomicilio.Usuarios.Core.Interfaces
{
    public interface IClienteRepositorio
    {
        Task AgregarAsync(Cliente cliente);
    }
}
