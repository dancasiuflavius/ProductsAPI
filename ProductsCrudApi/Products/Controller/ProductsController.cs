
using Microsoft.AspNetCore.Mvc;
using ProductsCrudApi.Products.Dto;
using ProductsCrudApi.Products.Model;
using ProductsCrudApi.Products.Repository;
using ProductsCrudApi.Products.Repository.Interfaces;

namespace ProductsCrudApi.Products.Controller
{
    [ApiController]
    [Route("products")]

    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;

        private readonly IProductRepository _productRepository;

        public ProductsController(ILogger<ProductsController> logger, IProductRepository productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
        }



        [HttpGet("api/v1/all")]
        public async Task<ActionResult<IEnumerable<Product>>> GetAll()
        {

            var products = await _productRepository.GetAllAsync();
            return Ok(products);

        }


        [HttpGet("api/v1/getName/{name}")]
        public async Task<ActionResult<Product>> GetName([FromRoute] string name)
        {
            var product = await _productRepository.GetByNameAsync(name);
            return Ok(product);
        }
        [HttpGet("api/v1/getAllByPrice")]
        public async Task<ActionResult<Double>> GetAllAsyncPrice()
        {
            var productPrices = await _productRepository.GetAllAsyncPrice();
            return Ok(productPrices);
        }

        [HttpPost("api/v1/create")]

        public async Task<ActionResult<Product>> CreateProduct([FromBody]CreateProductRequest createProductRequest)
        {
            var product = await _productRepository.CreateAsync(createProductRequest);


            return Ok(product);






        }
    }
}



