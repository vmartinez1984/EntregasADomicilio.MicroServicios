﻿using EntregasADomicilio.Web.Platillos.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EntregasADomicilio.Web.Platillos.Core.Interfaces.Repositories
{
    public interface IPlatillo
    {
        Task<Platillo> ObtenerPorIdAsync(string v);
        Task<List<Platillo>> ObtenerTodosAsync();
    }
}
