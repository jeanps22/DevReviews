using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [ApiController]
    [Route("api/products/{productId}/productsreviews")]
    public class ProductReviewController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult getById(int productId, int id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post(int productId, AddProductReviewDTO inputModel)
        {
            return CreatedAtAction(nameof(getById), new {id = 1, productId = 2}, inputModel);
        }

    }
}