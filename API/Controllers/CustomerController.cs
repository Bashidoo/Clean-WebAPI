using Application_Layer.Dtos;
using Application_Layer.Queries.CustomerQueries;
using Application_Layer.Queries.CustomerQueries.CreateACustomer;
using Application_Layer.Services;
using Domain_Layer.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application_Layer.Queries.CustomerQueries.GetAllCurrentCustomer;
using Application_Layer.Queries.CustomerQueries.DeleteCustomer;
using Application_Layer.Queries.CustomerQueries.UpdateACustomer;
using Application_Layer.Queries.CustomerQueries.GetCurrentCustomer;

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
        [HttpGet("Get-First-Customer-")]
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

        [HttpDelete]

        public async Task<ActionResult> DeleteACustomer(string customerName)
        {
            var result = await _mediator.Send(new DeleteCustomerQuery(customerName));

            if (result == null)
                return NotFound(result);

            return Ok(result);
        }

        [HttpPatch]
        public async Task<ActionResult> UpdateACustomer([FromBody] CustomerDto customerToUpdate)
        {
            var result = await _mediator.Send(new UpdateACustomerQuery(customerToUpdate));

            if (result == null)
                return NotFound(result);
            else
                return Ok(result);
         
        }
    }
}
