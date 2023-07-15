using CrudTest.Application.Customers.Command.CreateCustomer;
using CrudTest.Application.Customers.Command.DeleteCustomer;
using CrudTest.Application.Customers.Command.UpdateCustomer;
using CrudTest.Application.Customers.Common;
using CrudTest.Application.Customers.Queries.GetCustomer;
using CrudTest.Application.Customers.Queries.GetCustomerList;
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

    [HttpGet]
    public async Task<IActionResult> GetCustomers(CancellationToken ct)
    {
        var query = new GetCustomerListQuery();

        ErrorOr<List<CustomerResponseModel>> customersResult = await Mediator.Send(query, ct);

        return customersResult.Match(
            onValue: customersResult => Ok(_mapper.Map<List<CustomerResponse>>(customersResult)),
            Problem);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCustomers(Guid id, CancellationToken ct)
    {
        var query = new GetCustomerQuery(id);

        ErrorOr<CustomerResponseModel> customerResult = await Mediator.Send(query, ct);

        return customerResult.Match(
            onValue: customerResult => Ok(_mapper.Map<CustomerResponse>(customerResult)),
            Problem);
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
