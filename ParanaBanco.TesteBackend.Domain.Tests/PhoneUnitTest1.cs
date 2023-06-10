
using FluentAssertions;

using ParanaBanco.TesteBackend.Domain.Entities;
using ParanaBanco.TesteBackend.Domain.Validation;

using Xunit;
namespace ParanaBanco.TesteBackend.Domain.Tests;

public class PhoneUnitTest1
{
    [Fact]
    public void CreatePhone_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => { _ = new Phone(41, "988257783", Enums.EPhoneType.LandLine); };

        action.Should().NotThrow<DomainExceptionValidation>();
    }
}