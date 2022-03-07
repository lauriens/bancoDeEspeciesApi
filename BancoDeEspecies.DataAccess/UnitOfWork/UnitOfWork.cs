using BancoDeEspecies.DataAccess.Configurations;

namespace BancoDeEspecies.DataAccess.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        new void Dispose();
        void Dispose(bool disposing);
        BaseRepository<T> GetBaseRepository<T>() where T : class;
        Task SaveChangesAsync();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly BancoDeEspeciesDbContext _context;
        private readonly Dictionary<string, object> _repositories;
        private bool _disposed;

        public UnitOfWork(BancoDeEspeciesDbContext context)
        {
            _context = context;
            _repositories = new Dictionary<string, object>();
        }

        public BaseRepository<T> GetBaseRepository<T>() where T : class
        {
            var type = typeof(T).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(BaseRepository<T>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _context);

                if (repositoryInstance != null)
                    _repositories.Add(type, repositoryInstance);
            }
            return (BaseRepository<T>)_repositories[type];
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
                _context.Dispose();
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
