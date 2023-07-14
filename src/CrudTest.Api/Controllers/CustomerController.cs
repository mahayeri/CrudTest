using CrudTest.Application.Customers.Command;
using CrudTest.Contracts.Customers;
using ErrorOr;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace CrudTest.Api.Controllers;

[Route("[controller]")]
public class CustomerController : ApiController
{
    private readonly IMapper _mapper;

    public CustomerController(IMapper mapper)
    {
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCustomer(
        CreateCustomerRequest request,
        CancellationToken ct)
    {
        var command = _mapper.Map<CreateCustomerCommand>(request);

        ErrorOr<string> createCustomerResult = await Mediator.Send(command, ct);

        return createCustomerResult.Match(
            onValue: createCustomerResult => Ok(_mapper.Map<CustomerIdResponse>(createCustomerResult)),
            Problem);
    }
}
