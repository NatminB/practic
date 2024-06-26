using layerTwo.DTO;

namespace layerTwo.Interfaces
{
    public interface IRentService
    {
        Task<RentDTO> StartRentAsync(int bookId, int userId, DateTime date);
        Task ReturnBookAsync(int rentId, DateTime date);
    }
}
