using AutoMapper;
using ParkAutoCrudApi.Cars.Model;
using ParkAutoCrudApi.Dto;

namespace ParkAutoCrudApi.Mappings
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateCarRequest, Car>();
            CreateMap<UpdateCarRequest, Car>();
            CreateMap<CarDto, Car>().ReverseMap();
        }
    }
}
