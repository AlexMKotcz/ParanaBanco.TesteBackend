namespace ParanaBanco.TesteBackend.Application.Contracts.Responses;
public record ClientResponse : BaseResponse
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public IEnumerable<PhoneResponse> Phones { get; set; }
}
