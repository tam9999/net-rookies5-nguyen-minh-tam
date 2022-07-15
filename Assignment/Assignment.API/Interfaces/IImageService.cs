using Assignment.Domain.Entities;

namespace Assignment.API.Interfaces
{
    public interface IImageService
    {
        Task<List<Image>> GetAsync();
        Task<Image> GetByIdAsync(int id);
        Task<Image> PostAsync(Image image);
        Task<Image> PutAsync(int id, Image image);
        Task DeleteAsync(int id);
    }
}
