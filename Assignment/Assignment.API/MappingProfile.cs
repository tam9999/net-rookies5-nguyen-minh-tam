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
        }
    }
}
