using System.ComponentModel.DataAnnotations;

namespace DemoWebApiWithEfCoreAndGraphQl.Data.Entities;

public class Customer
{
    [Key]
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName  { get; set; }
    public Address Address { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public IEnumerable<Order> Orders { get; set; }
}