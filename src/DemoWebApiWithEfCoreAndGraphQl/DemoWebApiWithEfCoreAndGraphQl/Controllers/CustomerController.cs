using System.Net;
using AutoMapper;
using DemoWebApiWithEfCoreAndGraphQl.Models;
using DemoWebApiWithEfCoreAndGraphQl.Services;
using Microsoft.AspNetCore.Mvc;

namespace DemoWebApiWithEfCoreAndGraphQl.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class CustomerController : ControllerBase
{
    private readonly IDatabaseRepository _databaseRepository;
    private readonly IMapper _mapper;
    public CustomerController(IDatabaseRepository databaseRepository, IMapper mapper)
    {
        _databaseRepository = databaseRepository;
        _mapper = mapper;
    }

    [HttpGet(Name = "GetAllCustomersCollection")]
    [ProducesResponseType(typeof(CustomerDto), (int)HttpStatusCode.OK)]
    public IActionResult Get()
    {
        var customerEntities = _databaseRepository.GetCustomers();

        var customersToReturn = _mapper.Map<IEnumerable<CustomerDto>>(customerEntities);
        return Ok(customersToReturn);
    }


}