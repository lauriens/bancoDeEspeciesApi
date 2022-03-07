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

            builder
                .Entity<Localidade>()
                .ToTable("Localidades");

            builder
                .Entity<Localidade>()
                .HasKey(p => p.Id);

            builder
                .Entity<Localidade>()
                .Property(p => p.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder
                .Entity<Localidade>()
                .Property(p => p.Latitude);

            builder
                .Entity<Localidade>()
                .Property(p => p.Longitude);

            builder
                .Entity<Localidade>()
                .HasOne(p => p.Estado)
                .WithMany(p => p.Localidades);

            builder
                .Entity<Localidade>()
                .HasOne(p => p.Cidade)
                .WithMany(p => p.Localidades);

        }
    }
}
