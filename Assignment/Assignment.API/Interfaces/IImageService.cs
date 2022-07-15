using Assignment.Domain.Entities;

namespace Assignment.API.Interfaces
{
    public interface IImageService
    {
        Task<Product> PostAsync(Product image);
    }
}
