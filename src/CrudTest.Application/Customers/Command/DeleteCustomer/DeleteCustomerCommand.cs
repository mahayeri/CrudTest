using CrudTest.Application.Common.Interfaces.Messaging;

namespace CrudTest.Application.Customers.Command.DeleteCustomer;

public sealed record DeleteCustomerCommand(Guid Id) : ICommand<bool>;
