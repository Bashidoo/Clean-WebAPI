using Application_Layer.Dtos;
using Application_Layer.Queries.GetCurrentCustomer;
using Application_Layer.Queries.CreateACustomer;
using Application_Layer.Services;
using Domain_Layer.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application_Layer.Queries.GetAllCurrentCustomer;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<CustomerController>
        [HttpGet("Get-Customer-ID-0")]
        public async Task<ActionResult> GetCurrentCustomers()
        {
            var result = await _mediator.Send(new GetCurrentCustomerQuery());
            return Ok(result);
        }

        [HttpGet("Get-All-Customers")]
        public async Task<ActionResult> GetAllCurrentCustomers()
        {
            var result = await _mediator.Send(new GetAllCurrentCustomerQuery());
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> CreateACustomer([FromBody] CustomerDto customerToCreate)
        {
            var result = await _mediator.Send(new CreateCustomerCommandQuery(customerToCreate));
                return Ok(result);
        }
    }
}
