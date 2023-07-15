namespace CrudTest.Application.Common.Interfaces.Validations;
public interface ICustomerValidation
{
    /// <summary>
    ///     Checks the input to be a valid iban 
    /// </summary>
    /// <param name="iban"></param>
    /// <returns>bool.</returns>
    bool BeIban(string iban);

    /// <summary>
    ///     Checks the input to be a valid mobile number in IR
    /// </summary>
    /// <param name="inputPhoneNumber"></param>
    /// <returns>bool.</returns>
    bool BeMobileNumber(string inputPhoneNumber);

    /// <summary>
    ///		Checks the database if this email is unique
    /// </summary>
    /// <param name="email">email</param>
    /// <returns>bool.</returns>
    Task<bool> BeUniqueEmailAsync(string email, CancellationToken cancellationToken);
}
