using AutoMapper;
using FlagExplorer.Application.DTO;
using FlagExplorer.Domain.Entities;

namespace FlagExplorer.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<Country, CountryDetailsDto>();
        }
    }
}
