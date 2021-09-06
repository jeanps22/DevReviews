using System.Collections.Generic;
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
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        public ProductsController(IProductRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        //GET PARA api/products/
        [HttpGet]
        public async Task<IActionResult> getAll()
        {
            var products = await _repository.GetAllAsync();
            //var productsView = products
            //    .Select(p => new ProductViewModel(p.Id, p.Title, p.Price));
            var productsView = _mapper.Map<List<ProductViewModel>>(products);
            return Ok(productsView);
        }

        //GET PARA api/products/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> getById(int id) // Assincrono
        //public IActionResult getById(int id) - Não Assincrono
        {
            var products = await _repository.GetDetailsByIdAsync(id);

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
        public async Task<IActionResult> post(AddProductDTO inputModel)
        {
            var product = new Product(inputModel.Title, inputModel.Description, inputModel.Price);
            await _repository.AddAsync(product);
            return CreatedAtAction(nameof(getById), new { id = product.Id }, inputModel);
        }

        //Put PARA api/products/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> put(int id, UpdateProductDTO inputModel)
        {
            //Se tiver erro de validação retornar Bad Request
            //Se nao tiver ID retornar NotFoud
            if (inputModel.Description.Length > 50)
            {
                return BadRequest();
            }
            var products = await _repository.GetByIdAsync(id);
            if (products == null)
            {
                return NotFound();
            }

            products.Update(inputModel.Description, inputModel.Price);

            //_dbContext.Products.Update(products);
            //_dbContext.Entry(products).State = EntityState.Modified;
            await _repository.UpdateAsync(products);
            return NoContent();
        }

    }
}