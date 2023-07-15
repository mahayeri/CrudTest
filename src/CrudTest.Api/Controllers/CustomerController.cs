using CrudTest.Application.Customers.Command.CreateCustomer;
using CrudTest.Application.Customers.Command.DeleteCustomer;
using CrudTest.Application.Customers.Command.UpdateCustomer;
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
            onValue: Ok,
            Problem);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCustomer(
        Guid id,
        UpdateCustomerRequest request,
        CancellationToken ct)
    {
        var command = _mapper.Map<UpdateCustomerCommand>((id, request));

        ErrorOr<bool> updateCustomerResult = await Mediator.Send(command, ct);

        return updateCustomerResult.Match(
            onValue: updateCustomerResult => NoContent(),
            Problem);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCustomer(
        Guid id,
        CancellationToken ct)
    {
        var command = new DeleteCustomerCommand(id);

        ErrorOr<bool> deleteCustomerResult = await Mediator.Send(command, ct);

        return deleteCustomerResult.Match(
            onValue: deleteCustomerResult => NoContent(),
            Problem);
    }
}
