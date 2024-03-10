
using Microsoft.AspNetCore.Mvc;
using ProductsCrudApi.Products.Model;
using ProductsCrudApi.Products.Repository.Interfaces;

namespace ProductsCrudApi.Products.Controller
{
    [ApiController]
    [Route("controller")]

    public class ProductsController:ControllerBase
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
        public async Task<ActionResult<Product>> GetName([FromRoute]string name)
        {
            var product = await _productRepository.GetByNameAsync(name);
            return Ok(product);
        }
        
      

    }
}



