using AutoMapper;
using Mango.Services.ProductAPI.Contracts;
using Mango.Services.ProductAPI.DbContexts;
using Mango.Services.ProductAPI.Models;
using Mango.Services.ProductAPI.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public ProductRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ProductDto> CreateUpdateProduct(ProductDto product)
        {
            
            var Product = _mapper.Map<ProductDto, Product>(product);

            if (Product.ProductId > 0)
            {
                _db.Products.Update(Product);
            }
            else
            {
                _db.Products.Add(Product);
            }

            await _db.SaveChangesAsync();
            return _mapper.Map<Product, ProductDto>(Product);

        }

        public async Task<bool> DeleteProduct(int ProductId)
        {
            try
            {
                var Product = await _db.Products.Where(q => q.ProductId == ProductId).FirstOrDefaultAsync();
                if (Product == null)
                {
                    return false;
                }
              
                _db.Products.Remove(Product);
                await _db.SaveChangesAsync();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
            
        }

        public async Task<ProductDto> GetProductById(int ProductId)
        {
            var Product = await _db.Products.Where(q => q.ProductId == ProductId).FirstOrDefaultAsync();
            var ProductMap = _mapper.Map<ProductDto>(Product);
            return ProductMap;
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            var Products = await _db.Products.ToListAsync();
            var ProductsMap = _mapper.Map<List<ProductDto>>(Products);
            return ProductsMap;
        }
    }
}
