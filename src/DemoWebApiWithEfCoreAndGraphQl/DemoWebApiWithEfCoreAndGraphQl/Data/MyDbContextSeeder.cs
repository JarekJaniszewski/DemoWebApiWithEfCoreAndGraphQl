using Bogus;
using DemoWebApiWithEfCoreAndGraphQl.Data.Entities;

namespace DemoWebApiWithEfCoreAndGraphQl.Data;

public static class MyDbContextSeeder
{
    public static IHost SeedDatabase(this IHost host)
    {
        using var scope = host.Services.CreateScope();
        using var context = scope.ServiceProvider.GetRequiredService<MyDbContext>();

        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        var customers = GetCustomers();
        context.Customers.AddRange(customers);
        context.SaveChanges();

        return host;
    }

    private static IEnumerable<Customer> GetCustomers()
    {
        Randomizer.Seed = new Random(123456);
        var addressGenerator = new Faker<Address>()
            .RuleFor(a => a.Id, f => f.Random.Guid())
            .RuleFor(a => a.City, f => f.Address.City())
            .RuleFor(a => a.StreetAddress, f => f.Address.StreetAddress())
            .RuleFor(a => a.County, f => f.Address.County())
            .RuleFor(a => a.Country, f => f.Address.Country())
            .RuleFor(a => a.CountryCode, f => f.Address.CountryCode())
            .RuleFor(a => a.State, f => f.Address.State())
            .RuleFor(a => a.ZipCode, f => f.Address.ZipCode());

        var orderGenerator = new Faker<Order>()
            .RuleFor(o => o.Id, f => f.Random.Guid())
            .RuleFor(o => o.Date, f => f.Date.Past(3))
            .RuleFor(o => o.OrderValue, f => f.Finance.Amount(0, 10000))
            .RuleFor(o => o.Shipped, f => f.Random.Bool(0.9f));
        var customerGenerator = new Faker<Customer>()
            .RuleFor(c => c.Id, f => f.Random.Guid())
            .RuleFor(c => c.FirstName, f => f.Person.FirstName)
            .RuleFor(c => c.LastName, f => f.Person.LastName)
            .RuleFor(c => c.Address, f => addressGenerator.Generate())
            .RuleFor(c => c.Phone, f => f.Phone.PhoneNumber())
            .RuleFor(c => c.Email, f => f.Internet.Email())
            .RuleFor(c => c.Orders, f => orderGenerator.Generate(f.Random.Number(10)).ToList());
        return customerGenerator.Generate(100);
    }
}