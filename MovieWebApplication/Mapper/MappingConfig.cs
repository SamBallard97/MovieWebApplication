using AutoMapper;
using MovieWebApplication.Models;

namespace MovieWebApplication.Mapper
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<ElephantRequest, Elephant>();
        }
    }
}
