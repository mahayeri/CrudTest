using CrudTest.Application.Common.Interfaces.Messaging;
using CrudTest.Application.Customers.Common;

namespace CrudTest.Application.Customers.Queries.GetCustomerList;

public sealed record GetCustomerListQuery() : IQuery<List<CustomerResponseModel>>;
