using EntregasADomicilio.Admin.Platillos.Core.Interfaces;

namespace EntregasADomicilio.Admin.Platillos.FireStore.Repositorios
{
    public class Repositorio : IRepositorio
    {
        public Repositorio(ICategoriaRepositorio categoriaRepositorio, IPlatilloRepositorio platilloRepositorio)
        {
            Categoria = categoriaRepositorio;
            Platillo = platilloRepositorio;
        }

        public ICategoriaRepositorio Categoria { get; }
        public IPlatilloRepositorio Platillo { get; }
    }
}
