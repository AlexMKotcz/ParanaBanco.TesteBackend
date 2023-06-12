using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore;

using ParanaBanco.TesteBackend.Domain.Entities;
using ParanaBanco.TesteBackend.Domain.Interfaces;

namespace ParanaBanco.TesteBackend.Data.Repository;
public class ClientRepository : IClientRepository
{
    private readonly DataDbContext _context;

    public ClientRepository(DataDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Client client)
    {
        Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction? transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    public async Task DeleteAsync(Client client)
    {
        Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction? transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    public IQueryable<Client> Get(Expression<Func<Client, bool>>? expression = null)
    {
        return expression != null
            ? _context.Clients.Where(expression).Include(x => x.Phones).AsNoTracking()
            : _context.Clients.Include(x => x.Phones).AsNoTracking();
    }

    public async Task UpdateAsync(Client client)
    {
        Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction? transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            _context.Clients.Attach(client);
            _context.Entry(client).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    public async Task UpdateClientPhonesAsync(List<Phone> addedPhones, List<Phone> deletedPhones)
    {
        Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction? transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            _context.Phones.AddRange(addedPhones);
            _context.Phones.RemoveRange(deletedPhones);

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}
