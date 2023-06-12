using Microsoft.EntityFrameworkCore;

using ParanaBanco.TesteBackend.Domain.Entities;

namespace ParanaBanco.TesteBackend.Data;
public class DataDbContext : DbContext
{
    public DataDbContext() { }
    public DataDbContext(DbContextOptions<DataDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(DataDbContext).Assembly);
    }


    public DbSet<Client> Clients { get; set; }
    public DbSet<Phone> Phones { get; set; }
}