using CrudTest.Application.Common.Interfaces.Messaging;
using CrudTest.Application.Customers.Common;

namespace CrudTest.Application.Customers.Queries.GetCustomer;

public sealed record GetCustomerQuery(Guid Id) : IQuery<CustomerResponseModel>;
