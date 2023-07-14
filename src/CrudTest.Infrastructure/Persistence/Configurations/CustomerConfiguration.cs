using CrudTest.Domain.CustomerAggregate;
using CrudTest.Domain.CustomerAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CrudTest.Infrastructure.Persistence.Configurations;
public sealed class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
	public void Configure(EntityTypeBuilder<Customer> builder)
	{
		builder.HasKey(c => c.Id);

		builder.Property(c => c.Id)
			.ValueGeneratedNever()
			.HasConversion(
				id => id.Value,
				value => CustomerId.Create(value));

		builder.Property(c => c.FirstName)
			.IsRequired()
			.HasMaxLength(50);

		builder.Property(c => c.LastName)
			.IsRequired()
			.HasMaxLength(50);

		builder.Property(c => c.Email)
			.IsRequired()
			.HasMaxLength(50);

		builder.HasIndex(
				c => new
				{
					c.FirstName,
					c.LastName,
					c.DateOfBirth
				})
			.IsUnique();

		builder.HasIndex(c => c.Email)
			.IsUnique();

		builder.Property(c => c.PhoneNumber)
			.IsRequired()
			.HasConversion(
				str => PhoneNumberAsULong(str),
				u64 => ULongAsPhoneNumber(u64));

	}

	public static ulong PhoneNumberAsULong(string phoneNumber)
	{
		var plusRemoved = phoneNumber[1..];
		var u64 = ulong.Parse(plusRemoved);
		return u64;
	}

	public static string ULongAsPhoneNumber(ulong u64)
	{
		var plusAdded = $"+{u64}";
		return plusAdded;
	}
}
