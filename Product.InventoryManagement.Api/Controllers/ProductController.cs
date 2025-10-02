using MediatR;
using Microsoft.AspNetCore.Mvc;
using Product.InventoryManagement.Application.DTOs;
using Product.InventoryManagement.Application.Features.Product.Queries.GetAllProducts;
using Product.InventoryManagement.Application.Features.Product.Queries.GetProduct;
using ProductItem = Product.InventoryManagement.Domain.Entities.Product;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Product.InventoryManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<ProductController>
        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> Get()
        {
            var products = await _mediator.Send(new GetAllProductsQuery());
            return Ok(products);
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductItem>> Get(Guid id)
        {
            var product = await _mediator.Send(new GetProductQuery(id));
            return Ok(product);
        }

        // POST api/<ProductController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
