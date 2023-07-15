using CrudTest.Application.Customers.Command;
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

    }
}
