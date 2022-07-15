using Assignment.API.Interfaces;
using Assignment.Domain.Data;
using Assignment.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Assignment.API.Services
{
    public class ImageService: IImageService
    {
        ApplicationDbContext db;
        public ImageService(ApplicationDbContext _db)
        {
            this.db = _db;
        }
        public async Task DeleteAsync(int id)
        {
            var image = await db.Images.FirstOrDefaultAsync(image => image.Id == id);
            image.IsDeleted = true;
            await db.SaveChangesAsync();
        }

        public async Task<List<Image>> GetAsync()
        {
            return await db.Images.Where(image => image.IsDeleted == false).ToListAsync();
        }

        public async Task<Image> GetByIdAsync(int id)
        {
            return await db.Images.FirstOrDefaultAsync(image => image.Id == id);
        }

        public Task<Product> PostAsync(Product image)
        {
            throw new NotImplementedException();
        }

        //public async Task<Product> PostAsync(string image)
        //{
        //    await db.Products.AddAsync(image);
        //    await db.SaveChangesAsync();
        //    return image;
        //}

        //public Task<Product> PostAsync(string image)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<Image> PutAsync(int id, Image image)
        {
            var getImage = await db.Images.FirstOrDefaultAsync(image => image.Id == id);
            getImage.ImageName = image.ImageName;
            getImage.ImageURL = image.ImageURL;
            await db.SaveChangesAsync();
            return getImage;
        }
    }
}
