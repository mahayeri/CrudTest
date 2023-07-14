using CrudTest.Application.Common.Interfaces.Persistence;
using CrudTest.Domain.CustomerAggregate;
using CrudTest.Domain.CustomerAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace CrudTest.Infrastructure.Persistence.Repositories;
public sealed class CustomerRepository : ICustomerRepository
{
    private readonly ApplicationDbContext _context;

    public CustomerRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Customer?> GetByIdAsync(CustomerId customerId, CancellationToken cancellationToken)
    {
        Customer? customer = await _context.Customers
            .FirstOrDefaultAsync(c => c.Id == customerId, cancellationToken);

        return customer;
    }

    public async Task<bool> IsEmailUniqueAsync(string email, CancellationToken cancellationToken)
    {
        var isEmailUnique = await _context.Customers
            .AllAsync(c => c.Email != email, cancellationToken);

        return isEmailUnique;
    }

    public async Task Add(Customer customer)
    {
        await _context.AddAsync(customer);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Customer customer)
    {
        await _context.SaveChangesAsync();
    }

    public async Task Delete(CustomerId customerId)
    {
        Customer? customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == customerId);

        if (customer is null) return;

        _context.Customers.Remove(customer);
    }
}
