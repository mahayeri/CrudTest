using CrudTest.Domain.Common.Models;
using CrudTest.Domain.CustomerAggregate.Events;
using CrudTest.Domain.CustomerAggregate.ValueObjects;

namespace CrudTest.Domain.CustomerAggregate;
public sealed class Customer : AggregateRoot<CustomerId, Guid>
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public DateTime DateOfBirth { get; private set; }
    public string PhoneNumber { get; private set; }
    public string Email { get; private set; }
    public string BankAccountNumber { get; private set; }
    private Customer(
        CustomerId id,
        string firstName,
        string lastName,
        DateTime dateOfBirth,
        string phoneNumber,
        string email,
        string bankAccountNumber) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        PhoneNumber = phoneNumber;
        Email = email;
        BankAccountNumber = bankAccountNumber;
    }

    /// <summary>
    /// static method to create a new instance of the customer class and raise an event 
    /// </summary>
    /// <returns>Customer</returns>
    public static Customer Create(
        string firstName,
        string lastName,
        DateTime dateOfBirth,
        string phoneNumber,
        string email,
        string bankAccountNumber)
    {
        Customer customer = new(
            CustomerId.CreateUnique(),
            firstName,
            lastName,
            dateOfBirth,
            phoneNumber,
            email,
            bankAccountNumber);

        customer.AddDomainEvent(new CustomerCreatedEvent(customer));

        return customer;
    }

    /// <summary>
    /// update the properties of the customer aggregate and raise an event 
    /// </summary>
    /// <param name="firstName"></param>
    /// <param name="lastName"></param>
    /// <param name="dateOfBirth"></param>
    /// <param name="phoneNumber"></param>
    /// <param name="email"></param>
    /// <param name="bankAccountNumber"></param>
    public void Update(
        string firstName,
        string lastName,
        DateTime dateOfBirth,
        string phoneNumber,
        string email,
        string bankAccountNumber)
    {
        FirstName = (FirstName != firstName) ? firstName : FirstName;
        LastName = (LastName != lastName) ? lastName : LastName;
        DateOfBirth = (DateOfBirth != dateOfBirth) ? dateOfBirth : DateOfBirth;
        PhoneNumber = (PhoneNumber != phoneNumber) ? phoneNumber : PhoneNumber;
        Email = (Email != email) ? email : Email;
        BankAccountNumber = (BankAccountNumber != bankAccountNumber) ? bankAccountNumber : BankAccountNumber;

        AddDomainEvent(new CustomerUpdatedEvent(this));
    }
#pragma warning disable CS8618
    private Customer() { }
#pragma warning restore CS8618
}
