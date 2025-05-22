using Application_Layer.Dtos;
using Application_Layer.Dtos.ReponseDtos;
using Application_Layer.Queries.ProductQueries.CreateAProduct;
using Application_Layer.Queries.ProductQueries.DeleteProduct;
using Application_Layer.Queries.ProductQueries.GetAllCurrentProducts;
using Application_Layer.Queries.ProductQueries.GetProductByID;
using Application_Layer.Queries.ProductQueries.UpdateAProduct;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<ProductControllerr>
    
        [HttpGet("getAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            var result = await _mediator.Send(new GetAllProductQuery());
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        // GET api/<ProductControllerr>/5
        [HttpGet("Get-Product-By-id")]
        public async Task<IActionResult> GetProductByID(double id)
        {
            var result = await _mediator.Send(new GetProductByIDQuery(id));

            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }

            return NotFound(result.Message);
        }

        // POST api/<ProductControllerr>
        [HttpPost("Create A Product")]
        public async Task<IActionResult> CreateProduct([FromBody] ProductDto productdto)
        {
            var result = await _mediator.Send(new CreateProductCommandQuery(productdto));

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(new { Message = $"Product Created Succesfully", result.Data });
        }

        // PUT api/<ProductControllerr>/5
        [HttpPatch("Edit Product details")]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductResponseDto productdto)
        {
            if (productdto == null)
                return BadRequest("Patch attributes are null or incorrect.");

            var result = await _mediator.Send(new UpdateProductQuery(productdto));

            if (!result.IsSuccess || result.Data == null)
                return NotFound(result.Message);

            return Ok(result);


        }

        // DELETE api/<ProductControllerr>/5
        [HttpDelete("Delete-Product-By-id")]
        public async Task<IActionResult> DeleteProduct(double id)
        {
            var result = await _mediator.Send(new DeleteProductQuery(id));

            if (!result.IsSuccess)
            {
                return NotFound(result.Message);
            }
            return Ok(result);
        }
    }
}
