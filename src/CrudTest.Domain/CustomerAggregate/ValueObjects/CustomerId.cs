using CrudTest.Domain.Common.Models;

namespace CrudTest.Domain.CustomerAggregate.ValueObjects;

public sealed class CustomerId : AggregateRootId<Guid>
{
	public override Guid Value { get; protected set; }
	private CustomerId(Guid value) => Value = value;
	public static CustomerId CreateUnique() => new(Guid.NewGuid());
	public static CustomerId Create(Guid value) => new(value);
	public override IEnumerable<object> GetEqualityComponents()
	{
		yield return Value;
	}
}
