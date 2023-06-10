using System.Linq.Expressions;

using ParanaBanco.TesteBackend.Domain.Entities;

namespace ParanaBanco.TesteBackend.Domain.Interfaces.IRepository;
public interface IClientRepository
{
    Task AddAsync(Client client);
    IQueryable<int> Count(Expression<Func<Client, bool>>? expression = null);

    IQueryable<Client> Get(Expression<Func<Client, bool>>? expression = null);

    Task UpdateAsync(Client client);
}
