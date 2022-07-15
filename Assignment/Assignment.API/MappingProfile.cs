using Assignment.Domain.Entities;
using Assignment.SharedViewModels.ViewModels;
using AutoMapper;
namespace Assignment.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductViewModel>();
            CreateMap<Image, ImageViewModel>();
            CreateMap<ImageViewModel, Image>()
                .ForMember(dest => dest.Id, o => o.Ignore())
                .ForMember(dest => dest.IsDeleted, o => o.Ignore());
        }
    }
}
