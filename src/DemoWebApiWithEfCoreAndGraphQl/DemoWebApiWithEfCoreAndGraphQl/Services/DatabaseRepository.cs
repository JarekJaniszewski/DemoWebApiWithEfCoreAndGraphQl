using DemoWebApiWithEfCoreAndGraphQl.Data;
using DemoWebApiWithEfCoreAndGraphQl.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DemoWebApiWithEfCoreAndGraphQl.Services;

public class DatabaseRepository: IDatabaseRepository
{
    private readonly MyDbContext _context;

    public DatabaseRepository(MyDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Customer> GetCustomers()
    {
        return _context.Customers
            .Include(a => a.Address)
            .Include(a => a.Orders)
            .OrderBy(a => a.FirstName)
            .ThenBy(a => a.LastName)
            .ToList();
    }

}