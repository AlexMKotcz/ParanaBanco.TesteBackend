using System.Linq.Expressions;

using ParanaBanco.TesteBackend.Domain.Entities;
using ParanaBanco.TesteBackend.Domain.Interfaces;

namespace ParanaBanco.TesteBackend.Data.Repository;

public class PhoneRepository : IPhoneRepository
{
    public Task AddAsync(Phone phone)
    {
        throw new NotImplementedException();
    }

    public IQueryable<int> Count(Expression<Func<Phone, bool>>? expression = null)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Phone> Get(Expression<Func<Phone, bool>>? expression = null)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Phone client)
    {
        throw new NotImplementedException();
    }
}