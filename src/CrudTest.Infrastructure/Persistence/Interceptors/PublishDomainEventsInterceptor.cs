using CrudTest.Domain.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace CrudTest.Infrastructure.Persistence.Interceptors;
public sealed class PublishDomainEventsInterceptor : SaveChangesInterceptor
{
	private readonly IPublisher _mediator;

	public PublishDomainEventsInterceptor(IPublisher mediator)
	{
		_mediator = mediator;
	}

	public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
	{
		PublishDomainEvents(eventData.Context).GetAwaiter().GetResult();
		return base.SavingChanges(eventData, result);
	}

	public async override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result,
		CancellationToken cancellationToken = new CancellationToken())
	{
		await PublishDomainEvents(eventData.Context);
		return await base.SavingChangesAsync(eventData, result, cancellationToken);
	}

	private async Task PublishDomainEvents(DbContext context)
	{
		if (context is null)
			return;

		var entities = context.ChangeTracker
			.Entries<IHasDomainEvents>()
			.Where(entry => entry.Entity.DomainEvents.Any())
			.Select(entry => entry.Entity)
			.ToList();

		var domainEvents = entities
			.SelectMany(e => e.DomainEvents)
			.ToList();

		entities.ToList()
			.ForEach(e => e.ClearDomainEvents());

		foreach (var domainEvent in domainEvents)
			await _mediator.Publish(domainEvent);
	}
}
