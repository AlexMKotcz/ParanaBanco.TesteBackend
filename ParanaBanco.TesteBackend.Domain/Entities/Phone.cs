using System.Net.Sockets;

using ParanaBanco.TesteBackend.Domain.Enums;
using ParanaBanco.TesteBackend.Domain.Validation;

namespace ParanaBanco.TesteBackend.Domain.Entities;

public class Phone : Entity
{
    public int DDD { get; set; }
    public string Number { get; set; }
    public EPhoneType Type { get; set; }

    /// <summary>
    /// Private CTOR for ORM 
    /// </summary>
    private Phone() { }

    public Phone(int dDD, string number, EPhoneType type)
    {
        ValidateDomain(dDD, number, type);
    }

    public Phone(int id, int dDD, string number, EPhoneType type)
    {
        DomainExceptionValidation.When(id < 0, "Invalid Id value.");
        Id = id;
        ValidateDomain(dDD, number, type);
    }

    private void ValidateDomain(int dDD, string number, EPhoneType type)
    {
        DomainExceptionValidation.When(dDD < 11 || dDD > 99,
            "Invalid DDD. Must be a valid DDD, between 11 and 99.");

        DomainExceptionValidation.When(string.IsNullOrEmpty(number),
            "Invalid number. number is required.");

        DomainExceptionValidation.When(!number.All(char.IsDigit),
            "Invalid number, all chars must be numeric.");

        DomainExceptionValidation.When(number.Length < 8,
            "Invalid number, too short, minimum 8 numbers.");

        DomainExceptionValidation.When(number.Length > 9,
            "Invalid number, too long, maximum 9 numbers.");

        DomainExceptionValidation.When(!(type == EPhoneType.Mobile || type == EPhoneType.LandLine),
            "Invalid type, must be Mobile or LandLine.");

        DDD = dDD;
        Number = number;
        Type = type;
    }
}
