using Mango.Services.ProductAPI.Models.Dto;

namespace Mango.Services.ProductAPI.Contracts
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDto>> GetProducts();
        Task<ProductDto> GetProductById(int ProductId);
        Task<ProductDto> CreateUpdateProduct(ProductDto product);
        Task<bool> DeleteProduct(int ProductId);

    }
}
