using MediatR;
using Microsoft.AspNetCore.Mvc;
using Product.InventoryManagement.Application.Features.InventoryTransaction.Commands.CreateTransaction;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Product.InventoryManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TransactionController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<TransactionController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<TransactionController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TransactionController>
        [HttpPost]
        public async Task<ActionResult> Post(CreateTransactionCommand createTransactionCommand)
        {
            var response = await _mediator.Send(createTransactionCommand);
            return CreatedAtAction(nameof(Get), new { Id = response });
        }

        // DELETE api/<TransactionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
