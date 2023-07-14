namespace CrudTest.Application.Customers.Common;
public static class CustomerValidationErrorMessages
{
    public static readonly string PhoneNumberErrorMessage = "'Phone Number' is not a valid mobile number.";
    public static readonly string IbanErrorMessage = "'Bank Account Number' is not a valid iban.";
    public static readonly string UniqueEmailErrorMessage = "'Email' is not a unique email address.";
}