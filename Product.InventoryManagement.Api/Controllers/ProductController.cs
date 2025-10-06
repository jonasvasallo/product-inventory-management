using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Product.InventoryManagement.Application.DTOs;
using Product.InventoryManagement.Application.Features.Product.Commands.CreateProduct;
using Product.InventoryManagement.Application.Features.Product.Commands.DeleteProduct;
using Product.InventoryManagement.Application.Features.Product.Commands.UpdateProduct;
using Product.InventoryManagement.Application.Features.Product.Queries.GetAllProducts;
using Product.InventoryManagement.Application.Features.Product.Queries.GetAllProductsWithDetails;
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
        private readonly IMapper _mapper;
        public ProductController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        // GET: api/<ProductController>
        [HttpGet]
        public async Task<ActionResult<List<Domain.Entities.Product>>> Get()
        {
            var products = await _mediator.Send(new GetAllProductsWithDetailsQuery());
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
        public async Task<ActionResult> Post(CreateProductCommand createProductCommand)
        {
            var response = await _mediator.Send(createProductCommand);
            return CreatedAtAction(nameof(Get), new { Id = response });
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<UpdateProductCommand>> Put(Guid id, UpdateProductDto dto)
        {
            var command = new UpdateProductCommand
            {
                Id = id,
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                Quantity = dto.Quantity
            };
            await _mediator.Send(command);
            return Ok(command);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(Guid id)
        {
            var deleteProductCommand = new DeleteProductCommand { Id = id };
            var response = await _mediator.Send(deleteProductCommand);
            return NoContent();
        }
    }
}
