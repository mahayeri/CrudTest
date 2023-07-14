using CrudTest.Domain.Common.Models;

namespace CrudTest.Domain.CustomerAggregate.Events;
public sealed record CustomerUpdatedEvent(Customer Customer) : IDomainEvent;
