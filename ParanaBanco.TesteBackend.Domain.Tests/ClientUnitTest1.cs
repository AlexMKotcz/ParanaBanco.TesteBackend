
using FluentAssertions;

using ParanaBanco.TesteBackend.Domain.Entities;
using ParanaBanco.TesteBackend.Domain.Validation;

using Xunit;
namespace ParanaBanco.TesteBackend.Domain.Tests;
public class ClientUnitTest1
{
    const string ValidName = "Alex Mariano Kotcz",
        ValidEmail = "alexmariano129@gmail.com";

    readonly List<Phone> ValidPhones = new()
    {
        new Phone(41, "988257783", Enums.EPhoneType.Mobile),
        new Phone(41, "33571395", Enums.EPhoneType.LandLine)
    };

    public static IEnumerable<object[]> GetEmptyList()
    {
        yield return Array.Empty<object>();
    }

    [Fact]
    [Trait("Client", "Valid")]
    public void CreateClient_WithValidParameters_ResultObjectValidState()
    {
        Action action = () =>
        {
            _ = new Client(ValidName, ValidEmail, ValidPhones);
        };

        action.Should().NotThrow<DomainExceptionValidation>().And.NotThrow<Exception>();
    }

    [Fact]
    [Trait("Client", "Id")]
    public void CreateClient_NegativeIdValue_DomainExceptionInvalidId()
    {
        Action action = () =>
        {
            _ = new Client(-1, ValidName, ValidEmail, ValidPhones);
        };

        action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Id value.");
    }

    [Fact]
    [Trait("Client", "Name")]
    public void CreateClient_MissingNameValue_DomainExceptionRequiredName()
    {
        Action action = () =>
        {
            _ = new Client(2, string.Empty, ValidEmail, ValidPhones);
        };

        action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid fullName. FullName is required.");
    }

    [Fact]
    [Trait("Client", "Name")]
    public void CreateClient_OnlyFirstNameValue_DomainExceptionNotFullName()
    {
        Action action = () =>
        {
            _ = new Client("Alex", ValidEmail, ValidPhones);
        };

        action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid fullname. Both first and surname are required.");
    }

    [Theory]
    [InlineData("Al ", "Kotcz")]
    [InlineData("Alex ", "Ko")]
    [Trait("Client", "Name")]
    public void CreateClient_NameTooShort_DomainExceptionNameTooShort(string firstName, string lastName)
    {
        Action action = () =>
        {
            _ = new Client(firstName + lastName, ValidEmail, ValidPhones);
        };

        action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid fullname, too short, minimum 3 characters for both first and surname.");
    }

    [Fact]
    [Trait("Client", "Name")]
    public void CreateClient_NameTooLong_DomainExceptionNameTooLong()
    {
        const string fictionalName = "Sandra Isis Vieira André Pinto Teresinha Marcela Rosa Porto João Isaac Henry Melo"
            + " Sandra Isis Vieira André Pinto Teresinha Marcela Rosa Porto João Isaac Henry Melo";

        Action action = () =>
        {
            _ = new Client(fictionalName, ValidEmail, ValidPhones);
        };

        action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid fullname, too long, maximum 150 characters in total.");
    }

    [Fact]
    [Trait("Client", "Email")]
    public void CreateClient_MissingEmailValue_DomainExceptionRequiredEmail()
    {
        Action action = () =>
        {
            _ = new Client(ValidName, "", ValidPhones);
        };

        action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid email. Email is required.");
    }

    [Theory]
    [InlineData("alexmariano129@gmail.com")]
    [InlineData("alexmariano@outlook.com.br")]
    [InlineData("alex.mariano@123.com")]
    [InlineData("alex@yahoo.org")]
    [Trait("Client", "Email")]
    public void CreateClient_ValidEmailValue_ResultObjectValidState(string email)
    {
        Action action = () =>
        {
            _ = new Client(ValidName, email, ValidPhones);
        };

        action.Should().NotThrow<DomainExceptionValidation>().And.NotThrow<Exception>();
    }

    [Theory]
    [InlineData("alexmariano129@gm@il.com")]
    [InlineData("alexmarianooutlook.com.br")]
    [InlineData("alexmariano123com")]
    [InlineData("alex@yahooorg")]
    [Trait("Client", "Email")]
    public void CreateClient_InvalidEmailFormat_DomainExceptionInvalidEmail(string email)
    {
        Action action = () =>
        {
            _ = new Client(ValidName, email, ValidPhones);
        };

        action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid email, must be a valid one.");
    }

    [Fact]
    [Trait("Client", "Email")]
    public void CreateClient_EmailTooLong_DomainExceptionEmailTooLong()
    {
        const string fictionalEmail = "SandraIsisVieiraAndréPintoTeresinhaMarcelaRosaPortoJoãoIsaacHenryMeloSandraIsis" +
            "VieiraAndréPintoTeresinhaMarcelaRosaPortoJoãoIsaacHenryMelo@outlook.com.br";

        Action action = () =>
        {
            _ = new Client(ValidName, fictionalEmail, ValidPhones);
        };

        action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid email, too long, maximum 150 characters.");
    }

    [Fact]
    [Trait("Client", "Phone")]
    public void CreateClient_MissingPhones_DomainExceptionPhoneRequired()
    {
        Action action = () =>
        {
            _ = new Client(ValidName, ValidEmail, new());
        };

        action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid phone list. At least one phone is required.");
    }
}
