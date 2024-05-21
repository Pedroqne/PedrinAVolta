using AutoMapper;

namespace WebApplication1.DTOs.Mapping
{
    public class ProductDTOMappingProfile : Profile
    {
        public ProductDTOMappingProfile()
        {
            CreateMap<ProductDTO, ProductDTO>().ReverseMap();
        }
    }
}
