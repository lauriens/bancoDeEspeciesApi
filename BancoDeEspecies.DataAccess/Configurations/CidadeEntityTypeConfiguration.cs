using BancoDeEspecies.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BancoDeEspecies.DataAccess.Configurations
{
    public class CidadeEntityTypeConfiguration : IEntityTypeConfiguration<Cidade>
    {
        public void Configure(EntityTypeBuilder<Cidade> builder)
        {
            builder
                .ToTable("Cidades");

            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder
                .Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(200);

            builder
                .HasOne(p => p.Estado)
                .WithMany(p => p.Cidades);
        }
    }
}
