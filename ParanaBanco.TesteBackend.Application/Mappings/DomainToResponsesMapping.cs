using AutoMapper;

using ParanaBanco.TesteBackend.Application.Contracts.Responses;
using ParanaBanco.TesteBackend.Domain.Entities;

namespace ParanaBanco.TesteBackend.Application.Mappings;

public class DomainToResponsesMapping : Profile
{
    public DomainToResponsesMapping()
    {
        CreateMap<Client, ClientResponse>().ReverseMap();
        CreateMap<Phone, PhoneResponse>().ReverseMap();
    }
}
