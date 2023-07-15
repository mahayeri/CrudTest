using CrudTest.Application.Common.Interfaces.Validations;
using CrudTest.Infrastructure.Persistence;
using IbanNet;
using Microsoft.EntityFrameworkCore;
using PhoneNumbers;

namespace CrudTest.Infrastructure.Services;
public class CustomerValidation : ICustomerValidation
{
    private readonly PhoneNumberUtil _phoneNumberUtil;
    private readonly IbanValidator _ibanValidator;
    private readonly ApplicationDbContext _context;
    public CustomerValidation(ApplicationDbContext context)
    {
        _context = context;
        _phoneNumberUtil = PhoneNumberUtil.GetInstance();
        _ibanValidator = new IbanValidator();
    }
    public bool BeIban(string iban)
    {
        var validationResult = _ibanValidator.Validate(iban);
        return validationResult.IsValid;
    }

    public bool BeMobileNumber(string inputPhoneNumber)
    {
        try
        {
            const string internationalRegion = "IR";
            var phoneNumber = _phoneNumberUtil.Parse(inputPhoneNumber, internationalRegion);
            return _phoneNumberUtil.IsValidNumber(phoneNumber) &&
                   _phoneNumberUtil.GetNumberType(phoneNumber) == PhoneNumberType.MOBILE;
        }
        catch (NumberParseException)
        {
            return false;
        }
    }

    public async Task<bool> BeUniqueEmailAsync(string email, CancellationToken cancellationToken)
    {
        var isEmailUnique = await _context.Customers
            .AllAsync(c => c.Email != email, cancellationToken);

        return isEmailUnique;
    }
}
