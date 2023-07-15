using CrudTest.Application.Common.Interfaces.Messaging;
using CrudTest.Application.Common.Interfaces.Persistence;
using CrudTest.Application.Customers.Common;
using CrudTest.Domain.Common.Errors;
using CrudTest.Domain.CustomerAggregate;
using CrudTest.Domain.CustomerAggregate.ValueObjects;
using ErrorOr;
using MapsterMapper;

namespace CrudTest.Application.Customers.Queries.GetCustomer;
internal sealed class GetCustomerQueryHandler : IQueryHandler<GetCustomerQuery, CustomerResponseModel>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public GetCustomerQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<CustomerResponseModel>> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
    {
        Customer? customer = await _customerRepository.GetByIdAsync(CustomerId.Create(request.Id), cancellationToken);

        if (customer is null)
        {
            return Errors.Customer.CustomerNotFound;
        }

        CustomerResponseModel result = _mapper.Map<CustomerResponseModel>(customer);

        return result;
    }
}
