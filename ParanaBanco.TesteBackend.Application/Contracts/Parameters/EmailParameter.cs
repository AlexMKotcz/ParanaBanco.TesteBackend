using System.ComponentModel.DataAnnotations;

namespace ParanaBanco.TesteBackend.Application.Contracts.Parameters;

public struct EmailParameter
{
    [Required(AllowEmptyStrings = false)]
    [MaxLength(150)]
    [EmailAddress]
    public string Email { get; set; }

    public override string ToString() => Email;
}