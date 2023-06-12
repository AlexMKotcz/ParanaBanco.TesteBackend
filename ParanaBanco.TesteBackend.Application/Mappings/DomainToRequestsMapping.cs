using AutoMapper;

using ParanaBanco.TesteBackend.Application.Contracts.Requests;
using ParanaBanco.TesteBackend.Domain.Entities;

namespace ParanaBanco.TesteBackend.Application.Mappings;
public class DomainToRequestsMapping : Profile
{
    public DomainToRequestsMapping()
    {
        CreateMap<Client, ClientRequest>().ForMember(cr => cr.Email, map => map.MapFrom(c => c.Email)).ReverseMap();

        CreateMap<Phone, PhoneRequest>().ReverseMap();
    }
}
