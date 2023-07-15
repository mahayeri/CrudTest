namespace CrudTest.Application.Customers.Common;

public sealed record CustomerResponseModel(
    Guid Id,
    string FirstName,
    string LastName,
    DateTime DateOfBirth,
    string PhoneNumber,
    string Email,
    string BankAccountNumber);
