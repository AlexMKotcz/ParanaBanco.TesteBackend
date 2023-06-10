
using FluentAssertions;

using ParanaBanco.TesteBackend.Domain.Entities;
using ParanaBanco.TesteBackend.Domain.Validation;

using Xunit;
namespace ParanaBanco.TesteBackend.Domain.Tests;

public class PhoneUnitTest1
{
    [Fact]
    [Trait("Phone", "Valid")]
    public void CreatePhone_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => { _ = new Phone(41, "988257783", Enums.EPhoneType.LandLine); };

        action.Should().NotThrow<DomainExceptionValidation>();
    }

    [Fact]
    [Trait("Phone", "Id")]
    public void CreatePhone_NegativeIdValue_DomainExceptionInvalidId()
    {
        Action action = () => { _ = new Phone(-1, 41, "988257783", Enums.EPhoneType.LandLine); };

        action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Id value.");
    }

    [Theory]
    [InlineData(int.MinValue)]
    [InlineData(-10)]
    [InlineData(0)]
    [InlineData(5)]
    [InlineData(105)]
    [InlineData(int.MaxValue)]
    [Trait("Phone", "DDD")]
    public void CreatePhone_InvalidDDDValue_DomainExceptionInvalidDDD(int dDD)
    {
        Action action = () => { _ = new Phone(10, dDD, "988257783", Enums.EPhoneType.LandLine); };

        action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid DDD. Must be a valid DDD, between 11 and 99.");
    }

    [Fact]
    [Trait("Phone", "Number")]
    public void CreatePhone_MissingNumberValue_DomainExceptionRequiredNumber()
    {
        Action action = () => { _ = new Phone(10, 11, "", Enums.EPhoneType.LandLine); };

        action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid number. number is required.");
    }

    [Theory]
    [InlineData("3O571395")]
    [InlineData("Alex")]
    [Trait("Phone", "Number")]
    public void CreatePhone_NumberValueNotNumeric_DomainExceptionNumberNotNumeric(string number)
    {
        Action action = () => { _ = new Phone(10, 19, number, Enums.EPhoneType.LandLine); };

        action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid number, all chars must be numeric.");
    }

    [Theory]
    [InlineData("123")]
    [InlineData("1234567")]
    [Trait("Phone", "Number")]
    public void CreatePhone_NumberValueTooShort_DomainExceptionNumberTooShort(string number)
    {
        Action action = () => { _ = new Phone(10, 11, number, Enums.EPhoneType.LandLine); };

        action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid number, too short, minimum 8 numbers.");
    }

    [Fact]
    [Trait("Phone", "Number")]
    public void CreatePhone_NumberValueTooLong_DomainExceptionNumberTooLong()
    {
        Action action = () => { _ = new Phone(10, 11, "1234567890", Enums.EPhoneType.LandLine); };

        action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid number, too long, maximum 9 numbers.");
    }

    [Fact]
    [Trait("Phone", "Type")]
    public void CreatePhone_MissingType_DomainExceptionInvalidType()
    {
        Action action = () => { _ = new Phone(10, 41, "988257783", 0); };

        action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid type, must be Mobile or LandLine.");
    }
}