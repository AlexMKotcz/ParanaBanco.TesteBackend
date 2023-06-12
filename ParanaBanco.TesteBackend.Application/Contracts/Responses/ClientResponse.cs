namespace ParanaBanco.TesteBackend.Application.Contracts.Responses;
public record ClientResponse : BaseResponse
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public List<PhoneResponse> Phones { get; set; }
}
