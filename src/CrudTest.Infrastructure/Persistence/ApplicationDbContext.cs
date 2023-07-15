using CrudTest.Domain.Common.Models;
using CrudTest.Domain.CustomerAggregate;
using CrudTest.Infrastructure.Persistence.Interceptors;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CrudTest.Infrastructure.Persistence;

public sealed class ApplicationDbContext : DbContext
{
    private readonly PublishDomainEventsInterceptor _publishDomainEventsInterceptor;
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options, PublishDomainEventsInterceptor publishDomainEventsInterceptor)
        : base(options)
    {
        _publishDomainEventsInterceptor = publishDomainEventsInterceptor;
    }

    public DbSet<Customer> Customers => Set<Customer>();


    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder
            .Ignore<List<IDomainEvent>>()
            .ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_publishDomainEventsInterceptor);
        base.OnConfiguring(optionsBuilder);
    }
}