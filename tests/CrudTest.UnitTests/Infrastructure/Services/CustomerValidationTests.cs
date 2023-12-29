using CrudTest.Infrastructure.Persistence;
using CrudTest.Infrastructure.Services;
using FluentAssertions;
using Moq;

namespace CrudTest.UnitTests.Infrastructure.Services;
public class CustomerValidationTests
{
    private readonly Mock<ApplicationDbContext> _dbContextMock;
    private readonly CustomerValidation _validation;

    public CustomerValidationTests()
    {
        _dbContextMock = new Mock<ApplicationDbContext>();
        _validation = new CustomerValidation(_dbContextMock.Object);
    }

    [Fact]
    public void BeIban_ValidIban_ReturnsTrue()
    {
        // Arrange
        string iban = "DE89370400440532013000";

        // Act
        bool isValid = _validation.BeIban(iban);

        // Assert
        isValid.Should().BeTrue();
    }

    [Fact]
    public void BeIban_InvalidIban_ReturnsFalse()
    {
        // Arrange
        string iban = "DE123456789012345";

        // Act
        bool isValid = _validation.BeIban(iban);

        // Assert
        isValid.Should().BeFalse();
    }

    [Fact]
    public void BeMobileNumber_ValidMobileNumber_ReturnsTrue()
    {
        // Arrange
        string phoneNumber = "9198504880";

        // Act
        bool isValid = _validation.BeMobileNumber(phoneNumber);

        // Assert
        isValid.Should().BeTrue();
    }

    [Fact]
    public void BeMobileNumber_InvalidMobileNumber_ReturnsFalse()
    {
        // Arrange
        string phoneNumber = "123456789";

        // Act
        bool isValid = _validation.BeMobileNumber(phoneNumber);

        // Assert
        isValid.Should().BeFalse();
    }
}
