using CrudTest.Application.Common.Interfaces.Messaging;

namespace CrudTest.Application.Customers.Command.CreateCustomer;

public sealed record CreateCustomerCommand(
    string FirstName,
    string LastName,
    DateTime DateOfBirth,
    string PhoneNumber,
    string Email,
    string BankAccountNumber) : ICommand<string>;
