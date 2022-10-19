using AutoMapper;
using Category.API.Core.Models.Domain;
using Category.API.Core.Models.Request;
using Category.API.Core.Models.Response;

namespace Category.API.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CategoryModel, CategoryResponseModel>();
            CreateMap<CategoryRequestModel, CategoryModel>();
        }
    }
}
