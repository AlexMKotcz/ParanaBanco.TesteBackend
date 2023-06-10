
using FluentAssertions;

using ParanaBanco.TesteBackend.Domain.Entities;
using ParanaBanco.TesteBackend.Domain.Validation;

using Xunit;
namespace ParanaBanco.TesteBackend.Domain.Tests;
public class ClientUnitTest1
{
    [Fact]
    public void CreateClient_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Client("Alex Mariano Kotcz", "alexmariano129@gmail.com",
            new List<Phone>() { new Phone(41, "988257783", Enums.EPhoneType.Mobile) });

        action.Should().NotThrow<DomainExceptionValidation>();
    }
}

public class PhoneUnitTest1
{

}