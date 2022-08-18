using Assignment.Domain.Entities;
using Assignment.SharedViewModels.Dtos;
using Assignment.SharedViewModels.ViewModels;
using AutoMapper;
namespace Assignment.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductViewModel>()
                .ForMember(dest => dest.Name, o => o.MapFrom(src => src.ProductName))
                .ForMember(dest => dest.CategoryName, o => o.MapFrom(src => src.Category.CategoryName))
                .ReverseMap(); 
            CreateMap<Image, ImageViewModel>();
            CreateMap<ImageViewModel, Image>()
                .ForMember(dest => dest.Id, o => o.Ignore())
                .ForMember(dest => dest.IsDeleted, o => o.Ignore());
            CreateMap<Product, SearchProductViewModel>()
                .ReverseMap();
            CreateMap<List<ProductViewModel>, ProductDto>()
                .ForMember(dest => dest.Products, o => o.MapFrom(src => src));

        }
    }
}
