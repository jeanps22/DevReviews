using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Models;
using Persistence;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly DevReviewsDbContent _dbContext;
        private readonly IMapper _mapper;
        public ProductsController(DevReviewsDbContent dbContext, IMapper mapper)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        //GET PARA api/products/
        [HttpGet]
        public IActionResult getAll()
        {
            var products = _dbContext.Products;
            //var productsView = products
            //    .Select(p => new ProductViewModel(p.Id, p.Title, p.Price));
            var productsView = _mapper.Map<List<ProductViewModel>>(products);
            return Ok(productsView);
        }

        //GET PARA api/products/{id}
        [HttpGet("{id}")]
        public IActionResult getById(int id)
        {
            var products = _dbContext.Products.SingleOrDefault(p => p.Id == id);
            if (products == null)
            {
                return NotFound();
            }
            // var reviews = products
            //     .Reviews
            //     .Select(r => new ProductReviewViewModel(r.Id, r.Author, r.Rating, r.Comments, r.Registered))
            //     .ToList();
            // var productDetails = new ProductDetails
            // (
            //     products.Id,
            //     products.Title,
            //     products.Description,
            //     products.Price,
            //     products.Registered,
            //     reviews
            // );
            var productDetails = _mapper.Map<ProductDetails>(products);

            return Ok(productDetails);
        }
        //Post
        [HttpPost]
        public IActionResult post(AddProductDTO inputModel)
        {
            var product = new Product(inputModel.Title, inputModel.Description, inputModel.Price);
            _dbContext.Products.Add(product);
            return CreatedAtAction(nameof(getById), new { id = product.Id }, inputModel);
        }

        //Put PARA api/products/{id}
        [HttpPut("{id}")]
        public IActionResult put(int id, UpdateProductDTO inputModel)
        {
            //Se tiver erro de validação retornar Bad Request
            //Se nao tiver ID retornar NotFoud
            if (inputModel.Description.Length > 50)
            {
                return BadRequest();
            }
            var products = _dbContext.Products.SingleOrDefault(p => p.Id == id);
            if (products == null)
            {
                return NotFound();
            }
            products.Update(inputModel.Description, inputModel.Price);
            return NoContent();
        }

    }
}