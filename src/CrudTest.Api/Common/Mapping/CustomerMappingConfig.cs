using CrudTest.Application.Customers.Command.CreateCustomer;
using CrudTest.Application.Customers.Command.UpdateCustomer;
using CrudTest.Contracts.Customers;
using Mapster;

namespace CrudTest.Api.Common.Mapping;

public class CustomerMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateCustomerRequest, CreateCustomerCommand>()
            .Map(d => d, s => s)
            .MapToConstructor(true);

        config.NewConfig<(Guid Id, UpdateCustomerRequest request), UpdateCustomerCommand>()
            .Map(d => d.Id, s => s.Id)
            .Map(d => d, s => s.request)
            .MapToConstructor(true);
    }
}
