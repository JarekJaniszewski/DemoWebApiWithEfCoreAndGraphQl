using System.ComponentModel.DataAnnotations;

namespace DemoWebApiWithEfCoreAndGraphQl.Data.Entities;

public class Order
{
    [Key]
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public Decimal OrderValue { get; set; }
    public bool Shipped { get; set; }
}