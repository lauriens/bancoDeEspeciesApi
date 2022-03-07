using BancoDeEspecies.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BancoDeEspecies.DataAccess.Repositories
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

            builder
                .Entity<Estado>()
                .ToTable("Estados");
            builder
                .Entity<Estado>()
                .HasKey(p => p.Id);
            builder
                .Entity<Estado>()
                .Property(p => p.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();
            builder
                .Entity<Estado>()
                .Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Entity<Estado>()
                .Property(p => p.Abreviacao)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(2);
            builder
                .Entity<Estado>()
                .HasMany(p => p.Cidades)
                .WithOne(p => p.Estado);

            builder.Entity<Estado>().HasData
            (
                new Estado { Id = 1, Nome = "Rio Grande do Sul", Abreviacao = "RS" }, // Id set manually due to in-memory provider
                new Estado { Id = 2, Nome = "São Paulo", Abreviacao = "SP" }
            );

            builder
                .Entity<Cidade>()
                .ToTable("Cidades");

            builder
                .Entity<Cidade>()
                .HasKey(p => p.Id);

            builder
                .Entity<Cidade>()
                .Property(p => p.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder
                .Entity<Cidade>()
                .Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(200);

            builder
                .Entity<Cidade>()
                .HasOne(p => p.Estado)
                .WithMany(p => p.Cidades);


            builder.Entity<Cidade>().HasData
            (
                new Cidade { Id = 1, Nome = "Porto Alegre" }, // Id set manually due to in-memory provider
                new Cidade { Id = 2, Nome = "São Paulo" }
            );
        }
    }
}
