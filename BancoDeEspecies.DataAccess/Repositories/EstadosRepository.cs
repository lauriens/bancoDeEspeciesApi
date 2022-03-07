using BancoDeEspecies.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BancoDeEspecies.DataAccess.Repositories
{
    public interface IEstadosRepository
    {
        Task<IEnumerable<Estado>> ListAsync();
    }

    public class EstadosRepository : BaseRepository, IEstadosRepository
    {
        public EstadosRepository(BancoDeEspeciesDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Estado>> ListAsync()
        {
            return await _context.Estados.ToListAsync();
        }
    }
}
