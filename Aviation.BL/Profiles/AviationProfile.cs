using AutoMapper;
using Aviation.BL.Dto;
using Aviation.DAL.Model;

namespace Aviation.BL.Profiles
{
    public class AviationProfile : Profile
    {
        public AviationProfile()
        {
            CreateMap<AirCraft, AirCraftGet>();
            CreateMap<AirCraftCreate, AirCraft>();
        }
    }
}