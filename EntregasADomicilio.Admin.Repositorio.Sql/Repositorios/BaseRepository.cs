using EntregasADomicilio.Admin.Repositorio.Sql.Contexts;

namespace EntregasADomicilio.Admin.Repositorio.Sql.Repositorios
{
    public class BaseRepository
    {
        public readonly AppDbContext _appDbContext;

        public BaseRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
    }
}
