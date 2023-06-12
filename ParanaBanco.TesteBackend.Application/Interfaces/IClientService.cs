using ParanaBanco.TesteBackend.Application.Contracts.Parameters;
using ParanaBanco.TesteBackend.Application.Contracts.Requests;
using ParanaBanco.TesteBackend.Application.Contracts.Responses;

namespace ParanaBanco.TesteBackend.Application.Interfaces;
public interface IClientService
{
    Task<ClientResponse> Add(ClientRequest client);
    Task<IEnumerable<ClientResponse>> GetClients();
    Task<IEnumerable<ClientResponse>> GetByFullPhone(int ddd, string number);
    Task<ClientResponse> GetById(int? id);
    Task UpdateEmail(int clientId, EmailParameter email);
    Task UpdatePhones(int clientId, IEnumerable<PhoneRequest> phones);
    Task RemoveByEmail(EmailParameter email);
}
