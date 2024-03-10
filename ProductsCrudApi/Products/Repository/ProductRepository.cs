

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductsCrudApi.Data;
using ProductsCrudApi.Products.Dto;
using ProductsCrudApi.Products.Model;
using ProductsCrudApi.Products.Repository.Interfaces;


namespace ProductsCrudApi.Products.Repository
{
    public class ProductRepository : IProductRepository
    {


        private readonly AppDbContext _context;

        private readonly IMapper _mapper;




        public ProductRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }


        public  async Task<IEnumerable<Product>> GetAllAsync()
        {
           return await _context.Products.ToListAsync();
        }
        public async Task<Product>GetByNameAsync(string name)
        {
            return await _context.Products.FirstOrDefaultAsync(product => product.Name.Equals(name));
            
        }

        public async Task<IEnumerable<Double>> GetAllAsyncPrice()
        {

            return await _context.Products.Select(product => product.Price).ToListAsync();
        }

        public async Task<Product> CreateAsync(CreateProductRequest productRequest)
        {
          
            var product = _mapper.Map<Product>(productRequest); 


            _context.Products.Add(product);

            await _context.SaveChangesAsync();

            return product;


        }
    }
}
