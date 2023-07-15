using CrudTest.Application.Common.Interfaces.Messaging;

namespace CrudTest.Application.Customers.Command.UpdateCustomer;
public sealed record UpdateCustomerCommand(
    Guid Id,
    string FirstName,
    string LastName,
    DateTime DateOfBirth,
    string PhoneNumber,
    string Email,
    string BankAccountNumber) : ICommand<bool>;
