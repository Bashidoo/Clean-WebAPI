using Application_Layer.Dtos;
using Application_Layer.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerservice)
        {
            _customerService = customerservice;
        }
        // GET: api/<CustomerController>
        [HttpGet]
        public ActionResult<CustomerDto> GetCurrentCustomers()
        {
            return Ok(_customerService.GetCurrentCustomers());
        }



    }
}
