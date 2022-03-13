using BancoDeEspecies.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BancoDeEspecies.DataAccess.Configurations
{
    public class BancoDeEspeciesDbContext : DbContext
    {
        public BancoDeEspeciesDbContext(DbContextOptions<BancoDeEspeciesDbContext> options) : base(options)
        {
        }

        public DbSet<Cidade> Cidades { get; set; } = null!;
        public DbSet<Estado> Estados { get; set; } = null!;
        public DbSet<Localidade> Localidades { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(CidadeEntityTypeConfiguration).Assembly);
        }
    }
}
