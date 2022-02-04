namespace DemoWebApiWithEfCoreAndGraphQl.Models;

public class OrderDto
{
    public DateTime Date { get; set; }
    public Decimal OrderValue { get; set; }
    public bool Shipped { get; set; }
}