using BancoDeEspecies.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BancoDeEspecies.DataAccess.Configurations
{
    public class EstadoEntityTypeConfiguration : IEntityTypeConfiguration<Estado>
    {
        public void Configure(EntityTypeBuilder<Estado> builder)
        {
            builder
                .ToTable("Estados");

            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder
                .Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(p => p.Abreviacao)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(2);

            builder
                .HasMany(p => p.Cidades)
                .WithOne(p => p.Estado);
        }
    }
}
