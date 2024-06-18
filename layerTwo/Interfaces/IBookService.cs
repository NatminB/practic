using layerTwo.DTO;

namespace layerTwo.Interfaces
{
    public interface IBookService: IService<BookDTO>
    {
        Task TakeOff(BookDTO book);
    }
}
