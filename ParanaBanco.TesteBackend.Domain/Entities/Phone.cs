using ParanaBanco.TesteBackend.Domain.Enums;

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
        DDD = dDD;
        Number = number;
        Type = type;
    }
}
