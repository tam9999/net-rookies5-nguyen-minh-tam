using Assignment.Domain.Entities;

namespace Assignment.API.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProduct();
        Task<Product> GetProduct(int? productId);
        Task<int> AddProduct(Product product);
        Task<int> DeleteProduct(int? productId);
        Task UpdateProduct(Product product);
    }
}
