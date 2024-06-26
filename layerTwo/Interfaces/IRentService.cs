using layerTwo.DTO;

namespace layerTwo.Interfaces
{
    public interface IRentService
    {
        Task<IEnumerable<RentDTO>> GetAll();
        Task<RentDTO> StartRentAsync(int bookId, int userId, DateTime date);
        Task ReturnBookAsync(int rentId, DateTime date);
    }
}
