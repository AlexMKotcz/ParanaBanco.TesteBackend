using System.ComponentModel.DataAnnotations;

using ParanaBanco.TesteBackend.Application.Contracts.Parameters;

namespace ParanaBanco.TesteBackend.Application.Contracts.Requests;
public struct ClientRequest
{
    [Required(AllowEmptyStrings = false)]
    [MinLength(7)] //3 + ' ' + 3
    [MaxLength(150)]
    public string FullName { get; set; }

    [Required(AllowEmptyStrings = false)]
    public EmailParameter Email { get; set; }

    [Required]
    public IEnumerable<PhoneRequest> Phones { get; set; }
}
