using System.Linq.Expressions;

using ParanaBanco.TesteBackend.Domain.Entities;

namespace ParanaBanco.TesteBackend.Domain.Interfaces;
public interface IClientRepository
{
    Task AddAsync(Client client);
    IQueryable<Client> Get(Expression<Func<Client, bool>>? expression = null);

    Task UpdateAsync(Client client);

    Task DeleteAsync(Client client);
}
