using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using ParanaBanco.TesteBackend.Domain.Entities;
using ParanaBanco.TesteBackend.Domain.Interfaces.IRepository;

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

    public IQueryable<Client> Get(Expression<Func<Client, bool>>? expression = null)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Client client)
    {
        throw new NotImplementedException();
    }
}

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