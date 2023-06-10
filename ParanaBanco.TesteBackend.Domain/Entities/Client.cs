using System.Text.RegularExpressions;

using ParanaBanco.TesteBackend.Domain.Validation;

namespace ParanaBanco.TesteBackend.Domain.Entities;
public class Client : Entity 
{
    public string FullName { get; private set; }
    public string Email { get; private set; }
    public List<Phone> Phones { get; private set; }

    /// <summary>
    /// Private CTOR for ORM 
    /// </summary>
    private Client() { }

    public Client(int id, string fullName, string email, List<Phone> phones)
    {
        DomainExceptionValidation.When(id < 0, "Invalid Id value.");
        Id = id;
        ValidateDomain(fullName, email, phones);
    }
    public Client(string fullName, string email, List<Phone> phones)
    {
        ValidateDomain(fullName, email, phones);
    }

    private void ValidateDomain(string fullName, string email, List<Phone> phones)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(fullName),
            "Invalid fullName. FullName is required.");

        DomainExceptionValidation.When(!fullName.Contains(' '),
            "Invalid fullname. Both first and surname are required.");

        string[] names = fullName.Split(' ');
        DomainExceptionValidation.When(names.First().Length < 3 || names.Last().Length < 3,
            "Invalid fullname, too short, minimum 3 characters for both first and surname.");

        DomainExceptionValidation.When(fullName.Length > 150,
            "Invalid fullname, too long, maximum 150 characters in total.");

        DomainExceptionValidation.When(string.IsNullOrEmpty(email),
            "Invalid email. Email is required.");

        DomainExceptionValidation.When(!ValidateEmail(email),
            "Invalid email, must be a valid one.");

        DomainExceptionValidation.When(email.Length > 150,
            "Invalid email, too long, maximum 150 characters.");

        DomainExceptionValidation.When(phones == null || phones.Count == 0,
            "Invalid phone list. At least one phone is required.");

        FullName = fullName;
        Email = email;
        Phones = phones;
    }

    private static bool ValidateEmail(string email)
    {
        // Regular expression to validate the email format
        const string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        return Regex.IsMatch(email, pattern);
    }
}
