using CrudTest.Domain.CustomerAggregate.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CrudTest.Application.Customers.Events;
internal sealed class CustomerCreatedEventHandler : INotificationHandler<CustomerCreatedEvent>
{
    private readonly ILogger<CustomerCreatedEventHandler> _logger;

    public CustomerCreatedEventHandler(ILogger<CustomerCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(CustomerCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"CrudTest Domain Event: {notification.Customer.FirstName} {notification.Customer.LastName} Created.");

        return Task.CompletedTask;
    }
}
