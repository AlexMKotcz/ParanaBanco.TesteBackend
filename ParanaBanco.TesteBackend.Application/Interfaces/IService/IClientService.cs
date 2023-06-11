using ParanaBanco.TesteBackend.Application.Contracts.Requests;
using ParanaBanco.TesteBackend.Application.Contracts.Responses;

namespace ParanaBanco.TesteBackend.Application.Interfaces.IService;
public interface IClientService
{
    Task<ClientResponse> Add(ClientRequest client);
    Task<IEnumerable<ClientResponse>> GetClients();
    Task<IEnumerable<ClientResponse>> GetByFullPhone(int ddd, string number);
    Task<ClientResponse> GetById(int? id);
    Task UpdateEmail(int clientId, string email);
    Task UpdatePhones(int clientId, IEnumerable<PhoneRequest> phones);
    Task RemoveByEmail(string email);
}
