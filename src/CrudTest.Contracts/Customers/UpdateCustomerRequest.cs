namespace CrudTest.Contracts.Customers;

public sealed record UpdateCustomerRequest(
    string FirstName,
    string LastName,
    DateTime DateOfBirth,
    string PhoneNumber,
    string Email,
    string BankAccountNumber);
