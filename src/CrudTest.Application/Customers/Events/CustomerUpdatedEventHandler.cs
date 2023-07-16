using CrudTest.Domain.CustomerAggregate.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CrudTest.Application.Customers.Events;
internal sealed class CustomerUpdatedEventHandler : INotificationHandler<CustomerUpdatedEvent>
{
    private readonly ILogger<CustomerUpdatedEventHandler> _logger;

    public CustomerUpdatedEventHandler(ILogger<CustomerUpdatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(CustomerUpdatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"CrudTest Domain Event: {notification.Customer.FirstName} {notification.Customer.LastName} Information Updated.");

        return Task.CompletedTask;
    }
}
