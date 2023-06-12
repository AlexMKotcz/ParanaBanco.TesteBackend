using AutoMapper;

using ParanaBanco.TesteBackend.Application.Contracts.Parameters;
using ParanaBanco.TesteBackend.Application.Contracts.Requests;
using ParanaBanco.TesteBackend.Application.Contracts.Responses;
using ParanaBanco.TesteBackend.Application.Interfaces;
using ParanaBanco.TesteBackend.Domain.Entities;
using ParanaBanco.TesteBackend.Domain.Exceptions;
using ParanaBanco.TesteBackend.Domain.Interfaces;

namespace ParanaBanco.TesteBackend.Application.Services;
public class ClientService : IClientService
{
    private readonly IClientRepository _clientRepository;
    private readonly IRepositoryProcesser _repository;
    private readonly IMapper _mapper;

    public ClientService(IClientRepository clientRepository, IRepositoryProcesser repository, IMapper mapper)
    {
        _clientRepository = clientRepository;
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ClientResponse> Add(ClientRequest client)
    {
        if (await _repository.AnyAsync(_clientRepository.Get(c => c.Email == client.Email.ToString())))
            throw new ArgumentException("Já existe um cliente com o e-mail cadastrado!");

        Client clientEntity = _mapper.Map<Client>(client);
        await _clientRepository.AddAsync(clientEntity);
        return _mapper.Map<ClientResponse>(clientEntity);
    }

    public async Task<IEnumerable<ClientResponse>> GetByFullPhone(int ddd, string number)
    {
        IEnumerable<Client> clients = await _repository.GetToListAsync(
            _clientRepository.Get(c => c.Phones.Any(p => p.DDD == ddd && p.Number.Contains(number))));
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

    public async Task RemoveByEmail(EmailParameter email)
    {
        Client? client = await _repository.GetFirstOrDefaultAsync(_clientRepository.Get(c => c.Email.Equals(email.ToString())))
            ?? throw new EntryNotFoundException("Não foi encontrado nenhum cliente com o email fornecido.");

        await _clientRepository.DeleteAsync(client);
    }

    public async Task UpdateEmail(int clientId, EmailParameter email)
    {
        Client? client = await GetClientByIdWithoutContract(clientId)
            ?? throw new EntryNotFoundException("Não foi encontrado o cliente com o id fornecido.");

        client.Update(client.FullName, email.ToString(), client.Phones);

        await _clientRepository.UpdateAsync(client);
    }

    public async Task UpdatePhones(int clientId, IEnumerable<PhoneRequest> phones)
    {
        Client client = await GetClientByIdWithoutContract(clientId)
            ?? throw new EntryNotFoundException("Não foi encontrado o cliente com o id fornecido.");

        List<Phone> phonesRequest = _mapper.Map<List<Phone>>(phones);
        List<Phone> newPhones = GetAddedPhones(phonesRequest, client)
            , deletedPhones = GetDeletedPhones(phonesRequest, client.Phones);

        client.Update(client.FullName, client.Email, phonesRequest);

        await _clientRepository.UpdateClientPhonesAsync(newPhones, deletedPhones);
    }

    private static List<Phone> GetAddedPhones(List<Phone> requestList, Client clientDatabase)
    {
        List<Phone> phones =
            requestList.ExceptBy(
                clientDatabase.Phones.Select(phoneDb => new { phoneDb.DDD, phoneDb.Number, phoneDb.Type }),
                phoneRequest => new { phoneRequest.DDD, phoneRequest.Number, phoneRequest.Type })
            .ToList();

        phones.ForEach(p => p.ClientId = clientDatabase.Id);

        return phones;
    }
    private static List<Phone> GetDeletedPhones(List<Phone> requestList, List<Phone> dataBaseList)
        => dataBaseList.ExceptBy(requestList.Select(pDb => new { pDb.DDD, pDb.Number, pDb.Type }), pR => new { pR.DDD, pR.Number, pR.Type }).ToList();

    private async Task<Client?> GetClientByIdWithoutContract(int? id)
        => await _repository.GetFirstOrDefaultAsync(_clientRepository.Get(c => c.Id == id));

}
