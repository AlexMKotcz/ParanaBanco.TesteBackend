using System.Linq.Expressions;

using ParanaBanco.TesteBackend.Domain.Entities;
using ParanaBanco.TesteBackend.Domain.Interfaces;

namespace ParanaBanco.TesteBackend.Data.Repository;
public class ClientRepository : IClientRepository
{
    public Task AddAsync(Client client)
    {
        throw new NotImplementedException();
    }

    public IQueryable<int> Count(Expression<Func<Client, bool>>? expression = null)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Client client)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Client> Get(Expression<Func<Client, bool>>? expression = null)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Client client)
    {
        throw new NotImplementedException();
    }
}
