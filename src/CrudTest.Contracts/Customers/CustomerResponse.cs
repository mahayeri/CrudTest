namespace CrudTest.Contracts.Customers;
public sealed record CustomerResponse(
    string Id,
    string FirstName,
    string LastName,
    DateTime DateOfBirth,
    string PhoneNumber,
    string Email,
    string BankAccountNumber);
