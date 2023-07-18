using CrudTest.Application.Common.Interfaces.Persistence;
using CrudTest.Application.Customers.Command.CreateCustomer;
using CrudTest.Application.UnitTests.Customers.TestUtils;
using FluentAssertions;
using Moq;
using Xunit;

namespace CrudTest.Application.UnitTests.Customers.Command;

public class CreateMenuCommandHandlerTests
{
	private readonly Mock<ICustomerRepository> _mockCustomerRepository;
	private readonly CreateCustomerCommandHandler _handler;
	public CreateMenuCommandHandlerTests()
	{
		_mockCustomerRepository = new Mock<ICustomerRepository>();
		_handler = new CreateCustomerCommandHandler(_mockCustomerRepository.Object);
	}

	[Theory]
	[MemberData(nameof(ValidCreateCustomerCommands))]
	public async Task HandleCreateCustomerCommand_ValidCustomerGiven_ShouldCreateCustomerAndReturnId(
		CreateCustomerCommand command)
	{
		// Act
		// Invoke the Handler
		var result = await _handler.Handle(command, default);

		// Assert
		result.IsError.Should().BeFalse();
		result.Value.Should().BeOfType(typeof(string));
		result.Value.Should().HaveLength(36);
	}

	public static IEnumerable<object[]> ValidCreateCustomerCommands()
	{
		yield return new[] { CreateCustomerCommandUtils.Create() };
	}
}
