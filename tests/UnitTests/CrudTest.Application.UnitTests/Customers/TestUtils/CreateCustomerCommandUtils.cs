using CrudTest.Application.Customers.Command.CreateCustomer;
using CrudTest.Application.UnitTests.TestUtils.Constants;

namespace CrudTest.Application.UnitTests.Customers.TestUtils;
public static class CreateCustomerCommandUtils
{
	public static CreateCustomerCommand Create()
	{
		return new CreateCustomerCommand(
			Constants.Customer.FirstName,
			Constants.Customer.LastName,
			Constants.Customer.DateOfBirth,
			Constants.Customer.PhoneNumber,
			Constants.Customer.Email,
			Constants.Customer.BankAccountNumber);
	}
}
