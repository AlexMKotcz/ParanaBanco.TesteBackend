using Microsoft.EntityFrameworkCore;

using ParanaBanco.TesteBackend.Domain.Interfaces;

namespace ParanaBanco.TesteBackend.Data.Repository;

public class RepositoryProcesser : IRepository
{
    public async Task<bool> AnyAsync<T>(IQueryable<T> query) => await query.AnyAsync();

    public async Task<int> CountAsync<T>(IQueryable<T> query) => await query.CountAsync();

    public async Task<T?> GetFirstOrDefaultAsync<T>(IQueryable<T> query) => await query.FirstOrDefaultAsync();

    public async Task<IEnumerable<T>> GetToListAsync<T>(IQueryable<T> query) => await query.ToListAsync();
}
