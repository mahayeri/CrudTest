using CrudTest.Contracts.Customers;
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

        return Ok();
    }
}
