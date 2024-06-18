using AutoMapper;
using layerOne.models;
using layerTwo.DTO;

namespace layerTwo.profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
