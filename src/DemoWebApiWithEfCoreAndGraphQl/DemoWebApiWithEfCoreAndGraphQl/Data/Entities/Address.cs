using System.ComponentModel.DataAnnotations;

namespace DemoWebApiWithEfCoreAndGraphQl.Data.Entities;

public class Address
{
    [Key]
    public Guid Id { get; set; }
    public string City { get; set; }
    public string StreetAddress { get; set; }
    public string County { get; set; }
    public string Country { get; set; }
    public string CountryCode { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
}