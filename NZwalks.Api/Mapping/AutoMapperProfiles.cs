
using AutoMapper;
using NZwalks.Api.Models.Domain;
using NZwalks.Api.Models.DTO;

namespace NZwalks.Api.Mapping
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Region,RegionDto>().ReverseMap();
            CreateMap<Region,AddRequestRegionDto>().ReverseMap();
            CreateMap<Region,UpdateRequestRegionDto>().ReverseMap();
            CreateMap<Walk,AddRequestWalkDto>().ReverseMap();
            CreateMap<Walk,WalkDto>().ReverseMap();
            CreateMap<Difficulty,DifficultyDto>().ReverseMap();
            CreateMap<Walk,UpdateRequestWalkDto>().ReverseMap();

            
        }
    }
}