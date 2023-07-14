namespace CrudTest.Domain.Common.Models;
public abstract class Entity<TId> : IEquatable<Entity<TId>>, IHasDomainEvents
	where TId : notnull
{
	public TId Id { get; protected set; }
	private readonly List<IDomainEvent> _domainEvents = new();

	protected Entity(TId id) => Id = id;
	public override bool Equals(object? obj) => obj is Entity<TId> entity && Id.Equals(entity.Id);
	public static bool operator ==(Entity<TId> left, Entity<TId> right) => Equals(left, right);
	public static bool operator !=(Entity<TId> left, Entity<TId> right) => Equals(left, right);
	public bool Equals(Entity<TId>? other) => Equals((object?)other);
	public override int GetHashCode() => Id.GetHashCode();
	public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();
	public void AddDomainEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);
	public void RemoveDomainEvent(IDomainEvent domainEvent) => _domainEvents.Remove(domainEvent);
	public void ClearDomainEvents() => _domainEvents.Clear();


	// for ef core configuration and migration
#pragma warning disable CS8618
	protected Entity()
	{
	}
#pragma warning restore CS8618
}
