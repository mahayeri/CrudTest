﻿using CrudTest.Infrastructure.Persistence.Configurations;
using FluentAssertions;

namespace CrudTest.UnitTests.Infrastructure.Persistence.Configuration;
public class CustomerConfigurationTests
{
    [Theory]
    [InlineData("+989198504880", 989198504880)]
    public void PhoneNumber_ShouldMapToUlong(string phoneNumber, ulong u64)
    {
        var result = CustomerConfiguration.PhoneNumberAsULong(phoneNumber);
        result.Should().Be(u64);
    }

    [Theory]
    [InlineData(989198504880, "+989198504880")]
    public void ULong_ShouldMapToPhoneNumber(ulong u64, string phoneNumber)
    {
        var result = CustomerConfiguration.ULongAsPhoneNumber(u64);
        result.Should().Be(phoneNumber);
    }
}