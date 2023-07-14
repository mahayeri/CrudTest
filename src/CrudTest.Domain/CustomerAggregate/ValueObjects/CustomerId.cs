using CrudTest.Domain.Common.Models;

namespace CrudTest.Domain.CustomerAggregate.ValueObjects;

public sealed class CustomerId : ValueObject
{
	public Guid Value { get; }
	private CustomerId(Guid value) => Value = value;
	public static CustomerId CreateUnique() => new(Guid.NewGuid());
	public override IEnumerable<object> GetEqualityComponents()
	{
		yield return Value;
	}
}
