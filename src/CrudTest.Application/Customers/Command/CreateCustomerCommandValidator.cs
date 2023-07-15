using CrudTest.Application.Common.Interfaces.Persistence;
using CrudTest.Application.Customers.Common;
using FluentValidation;
using IbanNet;
using PhoneNumbers;

namespace CrudTest.Application.Customers.Command;

public sealed class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    private readonly PhoneNumberUtil _phoneNumberUtil;
    private readonly IbanValidator _ibanValidator;

    public CreateCustomerCommandValidator(ICustomerRepository customerRepository)
    {
        _phoneNumberUtil = PhoneNumberUtil.GetInstance();
        _ibanValidator = new IbanValidator();

        RuleFor(x => x.PhoneNumber)
            .NotEmpty()
            .Must(BePhoneNumber)
            .WithMessage(CustomerValidationErrorMessages.PhoneNumberErrorMessage);

        RuleFor(x => x.BankAccountNumber)
            .NotEmpty()
            .Must(BeIban)
            .WithMessage(CustomerValidationErrorMessages.IbanErrorMessage);

        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress()
            .MustAsync(customerRepository.IsEmailUniqueAsync)
            .WithMessage(CustomerValidationErrorMessages.UniqueEmailErrorMessage);
    }

    private bool BePhoneNumber(CreateCustomerCommand x, string phoneNumberStr)
    {
        try
        {
            const string internationalRegion = "IR";
            var phoneNumber = _phoneNumberUtil.Parse(phoneNumberStr, internationalRegion);
            return _phoneNumberUtil.IsValidNumber(phoneNumber) &&
                   _phoneNumberUtil.GetNumberType(phoneNumber) == PhoneNumberType.MOBILE;
        }
        catch (NumberParseException)
        {
            return false;
        }

    }

    private bool BeIban(string ibanStr)
    {
        var validationResult = _ibanValidator.Validate(ibanStr);
        return validationResult.IsValid;
    }
}
