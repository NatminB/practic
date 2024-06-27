using layerTwo.DTO;

namespace layerTwo.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<BookDTO>> GetAllBooksAsync();
        Task<BookDTO> AddBookAsync(BookDTO bookDTO);
        Task DeleteBookAsync(int bookId);
        Task UpdateBookAsync(BookDTO bookDTO);
        Task CutBookAsync(int bookId);
    }
}
