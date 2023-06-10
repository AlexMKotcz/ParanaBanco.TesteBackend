using System.ComponentModel.DataAnnotations;

namespace ParanaBanco.TesteBackend.Application.Contracts.Requests;
public struct ClientRequest
{
    [Required(AllowEmptyStrings =false)]
    [MinLength(7)] //3 + ' ' + 3
    [MaxLength(150)]
    public string FullName { get; set; }

    [Required(AllowEmptyStrings =false)]
    [MaxLength(150)]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public IEnumerable<PhoneRequest> Phones { get; set; }
}
