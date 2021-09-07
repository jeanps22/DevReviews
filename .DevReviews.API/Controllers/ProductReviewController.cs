using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Persistence;
using Persistence.Repository;

namespace Controllers
{
    [ApiController]
    [Route("api/products/{productId}/productsreviews")]
    public class ProductReviewController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _repository;

        public ProductReviewController(IProductRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getById(int productId, int id)
        {
            var productReview = await _repository.GetReviewByIdAsync(id);
            if (productReview == null)
            {
                return NotFound();
            }
            var productDetails = _mapper.Map<ProductReviewDetailsViewModel>(productReview);

            return Ok(productDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Post(int productId, AddProductReviewDTO inputModel)
        {
            //var productReview = _mapper.Map<AddProductReviewDTO,ProductReview>(inputModel);
            var productReview = new ProductReview(inputModel.Author, inputModel.Name, inputModel.Comments, inputModel.Rating, productId);
            await _repository.AddReviewAsync(productReview);
            return CreatedAtAction(nameof(getById), new { id = 1, productId = productId }, inputModel);
        }

    }
}