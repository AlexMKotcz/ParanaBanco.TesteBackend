using System.Linq.Expressions;

using ParanaBanco.TesteBackend.Domain.Entities;

namespace ParanaBanco.TesteBackend.Domain.Interfaces.IRepository;
public interface IPhoneRepository
{
    Task AddAsync(Phone phone);
    IQueryable<int> Count(Expression<Func<Phone, bool>>? expression = null);

    IQueryable<Phone> Get(Expression<Func<Phone, bool>>? expression = null);

    Task UpdateAsync(Phone client);
}
