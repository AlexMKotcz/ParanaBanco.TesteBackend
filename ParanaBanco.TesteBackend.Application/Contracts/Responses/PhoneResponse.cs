using ParanaBanco.TesteBackend.Domain.Enums;

namespace ParanaBanco.TesteBackend.Application.Contracts.Responses;

public record PhoneResponse : BaseResponse
{
    public int DDD { get; set; }
    public string Number { get; set; }
    public EPhoneType Type { get; set; }
}
