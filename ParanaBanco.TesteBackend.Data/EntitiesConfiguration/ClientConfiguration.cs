using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ParanaBanco.TesteBackend.Domain.Entities;

namespace ParanaBanco.TesteBackend.Data.EntitiesConfiguration;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> entity)
    {
        entity.HasKey(c => c.Id);
        entity.Property(c => c.FullName).IsRequired();
        entity.Property(c => c.Email).IsRequired();

        entity.HasMany(c => c.Phones)
            .WithOne(p => p.Client)
            .HasForeignKey(p => p.ClientId);
    }
}
