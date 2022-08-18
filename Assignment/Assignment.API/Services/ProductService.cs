using Assignment.API.Interfaces;
using Assignment.Domain.Data;
using Assignment.Domain.Entities;
using Assignment.SharedViewModels.Dtos;
using Assignment.SharedViewModels.Requests;
using Assignment.SharedViewModels.ViewModels;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Assignment.API.Services
{
    public class ProductService : IProductService
    {
        ApplicationDbContext db;
        private readonly IMapper _mapper;
        public ProductService(ApplicationDbContext _db, IMapper mapper)
        {
            this.db = _db;
            _mapper = mapper;
        }
        //public async Task<int> AddProductAsync(Product product)
        //{
        //    if (db != null)
        //    {
        //        await db.Products.AddAsync(product);
        //        await db.SaveChangesAsync();
        //        return product.Id;
        //    }
        //    return 0;
        //}

        public async Task<int> DeleteProductAsync(int? productId)
        {
            int result = 0;

            if (db != null)
            {
                var product = await db.Products.FirstOrDefaultAsync(x => x.Id == productId);

                if (product != null)
                {
                    db.Products.Remove(product);
                    result = await db.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }

        //public async Task<List<Product>> GetAllProductAsync()
        //{
        //    if (db != null)
        //    {
        //        return await db.Products.ToListAsync();
        //    }
        //    return null;
        //}

        //public async Task<Product> GetProductByIdAsync(int? Id)
        //{
        //    if (db != null)
        //    {
        //        return await(from p in db.Products
        //                     where p.Id == Id
        //                     select p
        //                     ).FirstOrDefaultAsync();
        //    }

        //    return null;
        //}

        public async Task<ProductViewModel> GetProductDetailAsync(int? productId)
        {
            var product = await db.Products.Where(x => x.Id == productId).FirstOrDefaultAsync();
            if (product == null)
            {
                throw new Exception($"Cannot find product with Id = {productId}");
            }
            var result = new ProductViewModel()
            {
                Id = product.Id,
                Name = product.ProductName,
                Price = product.Price,
                Description = product.Description,
                CreatedDate = product.CreatedDate,
                UpdatedDate = product.UpdatedDate,
                CategoryId = product.CategoryId,
                Image = product.Image
            };
            return result;
        }

        public async Task<List<SearchProductViewModel>> SearchByNameAsync(string productName)
        {
            IQueryable<Product> query = db.Products;
            if (!string.IsNullOrEmpty(productName))
            {
                query = query.Where(p => p.ProductName.Contains(productName));
            }
            var result = await query.ToListAsync();
            var searchDto = _mapper.Map<List<SearchProductViewModel>>(result);
            return searchDto;
        }

        public async Task<int> UpdateProductAsync(ProductUpdateRequest request)
        {
            var product = await db.Products.FindAsync(request.Id);
            if (product == null)
            {
                throw new Exception($"Cannot find product with Id: {request.Id}");
            }
            product.ProductName = request.ProductName;
            product.Price = request.Price;
            product.Qty = request.Qty;
            product.Description = request.Description;
            product.CategoryId = request.CategoryId;
            product.Image = request.Image;
            product.UpdatedDate = DateTime.Now;
            product.ImageId = request.ImageId;
            return await db.SaveChangesAsync();
        }

        public async Task<List<ProductViewModel>> GetTop8Async()
        {           
            return await db.Products.Select(product => _mapper.Map<ProductViewModel>(product)).Take(8).ToListAsync();
        }

        public async Task<int> AddProductAsync(ProductCreateRequest request)
        {
            var product = new Product()
            {
                ProductName = request.ProductName,
                Price = request.Price,
                Qty = request.Qty,
                Image = request.Image,
                ImageId = request.ImageId,
                Description = request.Description,
                CategoryId = request.CategoryId,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            };
            await db.AddAsync(product);
            await db.SaveChangesAsync();
            return product.Id;
        }

        public async Task<ProductDto> GetAllProductAsync(int? page, int? pageSize)
        {
            using (db)
            {
                var products = await db.Products.Include(c => c.Category)
                                                 .Include(s => s.Images)
                                                 .Include(r => r.ProductRatings)
                                                 .ToListAsync();
                if (products != null)
                {
                    var pageSizeCur = pageSize ?? 4;
                    var pageIndex = page ?? 1;
                    var totalPage = products.Count;
                    var numberPage = Math.Ceiling((float)totalPage / pageSizeCur);
                    var startPage = (pageIndex - 1) * pageSizeCur;
                    products = products.Skip(startPage).Take(pageSizeCur).ToList();
                    var ListProductsViewDto = _mapper.Map<List<ProductViewModel>>(products); 

                    var productsDto = _mapper.Map<ProductDto>(ListProductsViewDto);
                    productsDto.TotalItem = totalPage;
                    productsDto.CurrentPage = pageIndex;
                    productsDto.NumberPage = numberPage;
                    productsDto.PageSize = pageSizeCur;
                    return productsDto;
                }
            }
            return null;
            //return await db.Products.Select(product => new ProductViewModel()
            //{
            //    Id = product.Id,
            //    Name = product.ProductName,
            //    Qty = product.Qty,
            //    Price = product.Price,
            //    Description = product.Description,
            //    CreatedDate = product.CreatedDate,
            //    UpdatedDate = product.UpdatedDate,
            //    CategoryId = product.CategoryId,
            //    Image = product.Image,
            //    ImageId = product.ImageId
            //}).ToListAsync();
        }

        public async Task<ProductViewModel> GetProductByIdAsync(int? productId)
        {
            var product = await db.Products.Where(x => x.Id == productId).FirstOrDefaultAsync();
            if (product == null)
            {
                throw new Exception($"Cannot find product with Id = {productId}");
            }
            var result = new ProductViewModel()
            {
                Id = product.Id,
                Name = product.ProductName,
                Price = product.Price,
                Description = product.Description,
                CreatedDate = product.CreatedDate,
                UpdatedDate = product.UpdatedDate,
                CategoryId = product.CategoryId,
                Image = product.Image
            };
            return result;
        }
    }
}
