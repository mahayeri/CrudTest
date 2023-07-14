using CrudTest.Domain.Common.Models;

namespace CrudTest.Domain.CustomerAggregate.Events;

public sealed record CustomerCreatedEvent(Customer Customer) : IDomainEvent;
