using AutoMapper;

using ParanaBanco.TesteBackend.Application.Contracts.Requests;
using ParanaBanco.TesteBackend.Application.Contracts.Responses;
using ParanaBanco.TesteBackend.Application.Interfaces;
using ParanaBanco.TesteBackend.Domain.Entities;
using ParanaBanco.TesteBackend.Domain.Interfaces;

namespace ParanaBanco.TesteBackend.Application.Services;
public class ClientService : IClientService
{
    private readonly IClientRepository _clientRepository;
    private readonly IRepository _repository;
    private readonly IMapper _mapper;

    public ClientService(IClientRepository clientRepository, IRepository repository, IMapper mapper)
    {
        _clientRepository = clientRepository;
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ClientResponse> Add(ClientRequest client)
    {
        Client clientEntity = _mapper.Map<Client>(client);
        await _clientRepository.AddAsync(clientEntity);
        return _mapper.Map<ClientResponse>(clientEntity);
    }

    public async Task<IEnumerable<ClientResponse>> GetByFullPhone(int ddd, string number)
    {
        IEnumerable<Client> clients = await _repository.GetToListAsync(
            _clientRepository.Get(c => c.Phones.Any(p => p.DDD == ddd || p.Number.Contains(number))));
        return _mapper.Map<IEnumerable<ClientResponse>>(clients);
    }

    public async Task<ClientResponse> GetById(int? id)
    {
        Client? client = await GetClientByIdWithoutContract(id);
        return _mapper.Map<ClientResponse>(client);
    }

    public async Task<IEnumerable<ClientResponse>> GetClients()
    {
        IEnumerable<Client> clients = await _repository.GetToListAsync(_clientRepository.Get().OrderBy(c => c.FullName));
        return _mapper.Map<IEnumerable<ClientResponse>>(clients);
    }

    public async Task RemoveByEmail(string email)
    {
        Client? client = await _repository.GetFirstOrDefaultAsync(_clientRepository.Get(c => c.Email.Equals(email)))
            ?? throw new ArgumentException("Não foi encontrado nenhum cliente com o email fornecido.");

        await _clientRepository.DeleteAsync(client);
    }

    public async Task UpdateEmail(int clientId, string email)
    {
        Client? client = await GetClientByIdWithoutContract(clientId)
            ?? throw new ArgumentException("Não foi encontrado o cliente com o id fornecido.");

        client.Update(client.FullName, email, client.Phones);

        await _clientRepository.UpdateAsync(client);
    }

    public async Task UpdatePhones(int clientId, IEnumerable<PhoneRequest> phones)
    {
        Client? client = await GetClientByIdWithoutContract(clientId)
            ?? throw new ArgumentException("Não foi encontrado o cliente com o id fornecido.");

        client.Update(client.FullName, client.Email, _mapper.Map<IEnumerable<Phone>>(phones).ToList());

        await _clientRepository.UpdateAsync(client);
    }

    private async Task<Client?> GetClientByIdWithoutContract(int? id)
        => await _repository.GetFirstOrDefaultAsync(_clientRepository.Get(c => c.Id == id));

}
