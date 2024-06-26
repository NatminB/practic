using AutoMapper;
using layerOne.models;
using layerTwo.DTO;

namespace layerTwo.profiles
{
    public class RentProfile: Profile
    {
        public RentProfile() { CreateMap<Rent, RentDTO>().ReverseMap(); }
    }
}
