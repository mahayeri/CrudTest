using System.ComponentModel.DataAnnotations.Schema;
namespace CrudTest.Domain.Common.Models;
public abstract class Entity<TId> : IEquatable<Entity<TId>>
	where TId : notnull
{
	public TId Id { get; protected set; }
	protected Entity(TId id) => Id = id;
	private readonly List<Event> _domainEvents = new();

	public override bool Equals(object? obj) => obj is Entity<TId> entity && Id.Equals(entity.Id);
	public static bool operator ==(Entity<TId> left, Entity<TId> right) => Equals(left, right);
	public static bool operator !=(Entity<TId> left, Entity<TId> right) => Equals(left, right);
	public bool Equals(Entity<TId>? other) => Equals((object?)other);
	public override int GetHashCode() => Id.GetHashCode();


	[NotMapped]
	public IReadOnlyCollection<Event> DomainEvents => _domainEvents.AsReadOnly();
	public void AddDomainEvent(Event domainEvent) => _domainEvents.Add(domainEvent);
	public void RemoveDomainEvent(Event domainEvent) => _domainEvents.Remove(domainEvent);
	public void ClearDomainEvents() => _domainEvents.Clear();
}
