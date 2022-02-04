using DemoWebApiWithEfCoreAndGraphQl.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DemoWebApiWithEfCoreAndGraphQl.Data;

public class MyDbContext:DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"DataSource=mydatabase.db;");
    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
}