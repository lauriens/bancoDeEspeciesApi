using BancoDeEspecies.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BancoDeEspecies.DataAccess.Configurations
{
    public class LocalidadeEntityTypeConfiguration : IEntityTypeConfiguration<Localidade>
    {
        public void Configure(EntityTypeBuilder<Localidade> builder)
        {
            builder
                .ToTable("Localidades");

            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder
                .Property(p => p.Latitude);

            builder
                .Property(p => p.Longitude);

            builder
                .HasOne(p => p.Estado)
                .WithMany(p => p.Localidades);

            builder
                .HasOne(p => p.Cidade)
                .WithMany(p => p.Localidades);
        }
    }
}
