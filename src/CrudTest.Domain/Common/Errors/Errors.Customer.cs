using ErrorOr;

namespace CrudTest.Domain.Common.Errors;

public static partial class Errors
{
    public static class Customer
    {
        public static Error UniqueEmail => Error.Validation(
            code: "Customer.InvalidEmail",
            description: "'Email' is not a unique email address.");

        public static Error InvalidIban => Error.Validation(
            code: "Customer.InvalidIban",
            description: "'Bank Account Number' is not a valid iban.");

        public static Error InvalidPhoneNumber => Error.Validation(
            code: "Customer.InvalidPhoneNumber",
            description: "'Phone Number' is not a valid mobile number.");

        public static Error CustomerNotFound => Error.NotFound(
            code: "Customer.NotFound",
            description: "No customer with the given Id can be found.");
    }
}