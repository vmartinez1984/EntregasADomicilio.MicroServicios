﻿using EntregasADomicilio.Web.Platillos.BusinessLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace EntregasADomicilio.Web.Platillos.BusinessLayer.Interfaces
{
    public interface IPlatilloBl
    {
        Task<byte[]> ObtenerBytesAsync(Guid platilloId);
        Task<List<PlatilloDto>> ObtnerTodos();
    }
}
