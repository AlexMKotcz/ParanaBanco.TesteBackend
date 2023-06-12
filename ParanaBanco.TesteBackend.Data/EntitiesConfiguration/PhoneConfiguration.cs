using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ParanaBanco.TesteBackend.Domain.Entities;

namespace ParanaBanco.TesteBackend.Data.EntitiesConfiguration;

public class PhoneConfiguration : IEntityTypeConfiguration<Phone>
{
    public void Configure(EntityTypeBuilder<Phone> entity)
    {
        entity.HasKey(p => p.Id);
        entity.Property(p => p.DDD).IsRequired();
        entity.Property(p => p.Number).IsRequired().HasMaxLength(9);
        entity.Property(p => p.Type).IsRequired();
    }
}