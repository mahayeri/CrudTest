using CrudTest.Domain.Common.Models;

namespace CrudTest.Domain.CustomerAggregate.Events;
public sealed class CustomerUpdatedEvent : Event
{
	public CustomerUpdatedEvent(Customer customer)
	{
		Customer = customer;
	}

	public Customer Customer { get; private set; }
}
