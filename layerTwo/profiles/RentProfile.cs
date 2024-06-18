using AutoMapper;
using layerOne.models;
using layerTwo.DTO;

namespace layerTwo.profiles
{
    public class RentProfile: Profile
    {
        RentProfile() { CreateMap<Rent, RentDTO>().ReverseMap(); }
    }
}
