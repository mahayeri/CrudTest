using CrudTest.Application.Common.Interfaces.Messaging;
using CrudTest.Application.Common.Interfaces.Persistence;
using CrudTest.Application.Customers.Common;
using CrudTest.Domain.CustomerAggregate;
using ErrorOr;
using MapsterMapper;

namespace CrudTest.Application.Customers.Queries.GetCustomerList;
internal sealed class GetCustomerListQueryHandler : IQueryHandler<GetCustomerListQuery, List<CustomerResponseModel>>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public GetCustomerListQueryHandler(
        ICustomerRepository customerRepository,
        IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<List<CustomerResponseModel>>> Handle(GetCustomerListQuery request, CancellationToken cancellationToken)
    {
        List<Customer> customers = await _customerRepository.GetListAsync(cancellationToken);

        return _mapper.Map<List<CustomerResponseModel>>(customers);
    }
}
