using CrudTest.Application.Common.Interfaces.Messaging;
using CrudTest.Application.Common.Interfaces.Persistence;
using CrudTest.Domain.Common.Errors;
using CrudTest.Domain.CustomerAggregate;
using CrudTest.Domain.CustomerAggregate.ValueObjects;
using ErrorOr;

namespace CrudTest.Application.Customers.Command.DeleteCustomer;
internal sealed class DeleteCustomerCommandHandler : ICommandHandler<DeleteCustomerCommand, bool>
{
    private readonly ICustomerRepository _customerRepository;

    public DeleteCustomerCommandHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<ErrorOr<bool>> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        CustomerId customerId = CustomerId.Create(request.Id);

        Customer? customer = await _customerRepository.GetByIdAsync(
            customerId,
            cancellationToken);

        if (customer is null)
        {
            return Errors.Customer.CustomerNotFound;
        }

        await _customerRepository.Delete(customerId);

        return true;
    }
}
