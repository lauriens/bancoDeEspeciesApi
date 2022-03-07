namespace BancoDeEspecies.DataAccess.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly BancoDeEspeciesDbContext _context;

        public BaseRepository(BancoDeEspeciesDbContext context)
        {
            _context = context;
        }
    }
}
