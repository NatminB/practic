using layerOne.interfaces;
using layerOne.models;
using layerTwo.DTO;
using AutoMapper;
using layerTwo.Interfaces;

namespace layerTwo.Services
{
    public class BookService : IBookService
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IRepository<Book> bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookDTO>> GetAllBooksAsync()
        {
            var books = await _bookRepository.GetAllAsync(x => x.Rents);
            return _mapper.Map<IEnumerable<BookDTO>>(books);
        }

        public async Task<bool> AddBookAsync(BookDTO bookDTO)
        {
            var book = _mapper.Map<Book>(bookDTO);
            return await _bookRepository.AddAsync(book);
        }

        public async Task DeleteBookAsync(int bookId)
        {
            await _bookRepository.DeleteAsync(bookId);
        }

        public async Task UpdateBookAsync(BookDTO bookDTO)
        {
            var book = _mapper.Map<Book>(bookDTO);
            await _bookRepository.UpdateAsync(book);
        }

        public async Task CutBookAsync(int bookId)
        {
            var book = await _bookRepository.GetByIdAsync(bookId);
            if (book != null)
            {
                book.DateOfCut = DateTime.Now;
                await _bookRepository.UpdateAsync(book);
            }
        }
    }
}