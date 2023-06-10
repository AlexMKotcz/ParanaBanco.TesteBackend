using ParanaBanco.TesteBackend.Application.Contracts.Requests;
using ParanaBanco.TesteBackend.Application.Contracts.Responses;
using ParanaBanco.TesteBackend.Application.Interfaces.IService;
using ParanaBanco.TesteBackend.Domain.Interfaces.IRepository;

namespace ParanaBanco.TesteBackend.Application.Services;
internal class ClientService : IClientService
{
    private readonly IClientRepository _clientRepository;

    public ClientService(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public async Task Add(ClientRequest client)
    {
        throw new NotImplementedException();
    }

    public async Task<ClientResponse> GetByFullPhone(int? ddd, string? number)
    {
        throw new NotImplementedException();
    }

    public async Task<ClientResponse> GetById(int? id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<ClientResponse>> GetClients()
    {
        throw new NotImplementedException();
    }

    public async Task RemoveByEmail(string email)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateEmail(int clientId, string email)
    {
        throw new NotImplementedException();
    }

    public async Task UpdatePhones(int clientId, IEnumerable<PhoneRequest> phones)
    {
        throw new NotImplementedException();
    }
}
