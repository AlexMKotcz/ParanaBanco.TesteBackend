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
            "Invalid fullname. First and Surname are required.");

        DomainExceptionValidation.When(fullName.Split(' ').Any(s => s.Length < 3),
            "Invalid fullname, too short, minimum 3 characters for both first and surname");

        DomainExceptionValidation.When(string.IsNullOrEmpty(email),
            "Invalid email. Email is required.");

        DomainExceptionValidation.When(ValidateEmail(email),
            "Invalid email, not in correct format.");
    }

    private static bool ValidateEmail(string email)
    {
        // Regular expression to validate the email format
        const string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        return Regex.IsMatch(email, pattern);
    }
}
