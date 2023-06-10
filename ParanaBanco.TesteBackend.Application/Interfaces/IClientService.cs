using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ParanaBanco.TesteBackend.Application.Contracts.Requests;
using ParanaBanco.TesteBackend.Application.Contracts.Responses;

namespace ParanaBanco.TesteBackend.Application.Interfaces;
public interface IClientService
{
    Task<IEnumerable<ClientResponse>> GetClients();
    Task<ClientResponse> GetById(int? id);
    Task Add(ClientRequest client);

    Task UpdateEmail(int clientId, string email);
    Task UpdatePhones(int clientId, IEnumerable<PhoneRequest> phones);
    Task Remove(string email);
}
