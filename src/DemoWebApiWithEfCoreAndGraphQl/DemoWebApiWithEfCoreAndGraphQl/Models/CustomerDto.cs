namespace DemoWebApiWithEfCoreAndGraphQl.Models;

public class CustomerDto
{
    public string FullName { get; set; }
    public AddressDto Address { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public IEnumerable<OrderDto> Orders { get; set; }
}