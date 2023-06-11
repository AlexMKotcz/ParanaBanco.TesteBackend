namespace ParanaBanco.TesteBackend.Domain.Interfaces;

public interface IRepository
{
    Task<T?> GetFirstOrDefaultAsync<T>(IQueryable<T> query);
    Task<IEnumerable<T>> GetToListAsync<T>(IQueryable<T> query);
    Task<bool> AnyAsync<T>(IQueryable<T> query);
    Task<int> CountAsync<T>(IQueryable<T> query);
}