using AutoMapper;
using layerOne.models;
using layerTwo.DTO;

namespace layerTwo.profiles
{
    public class BookProfile : Profile
    {
        public BookProfile() { CreateMap<Book, BookDTO>().ReverseMap(); }
    }
}
