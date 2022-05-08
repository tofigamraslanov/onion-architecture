using Application.Features.ProductFeatures.Commands;
using Application.Features.ProductFeatures.Queries;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.v1
{
    /// <summary>
    /// Product Controller
    /// </summary>
    [ApiVersion("1.0")]
    public class ProductController : BaseApiController
    {
        /// <summary>
        /// Gets all Products.
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator!.Send(new GetAllProductsQuery()));
        }

        /// <summary>
        /// Gets Product Entity by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator!.Send(new GetProductByIdQuery(id)));
        }

        /// <summary>
        /// Creates a New Product.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<IActionResult> Create(CreateProductCommand command)
        {
            return Ok(await Mediator!.Send(command));
        }

        /// <summary>
        /// Deletes Product Entity based on Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator!.Send(new DeleteProductByIdCommand(id)));
        }

        /// <summary>
        /// Updates the Product Entity based on Id.   
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromQuery] int id, UpdateProductCommand command)
        {
            if (id != command.Id)
                return BadRequest();

            return Ok(await Mediator!.Send(command));
        }
    }
}
