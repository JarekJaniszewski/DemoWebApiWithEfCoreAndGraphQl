using DemoWebApiWithEfCoreAndGraphQl.Data.Entities;

namespace DemoWebApiWithEfCoreAndGraphQl.Services;

public interface IDatabaseRepository
{
    IEnumerable<Customer> GetCustomers();
}