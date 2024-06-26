using layerTwo.DTO;
using layerTwo.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace layerThree.Controllers
{
    [Route("/Book/")]
    [ApiController]
    public class BookController : Controller
    {
        private IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDTO>>> GetBooks()
        {
            var books = await _bookService.GetAllBooksAsync();
            return books is not null ? Ok(books) : NoContent();
        }
        [HttpPut]
        public async Task<ActionResult<BookDTO>> Update(BookDTO item)
        {
            if (item is null)
            {
                return BadRequest();
            }
            var books = await _bookService.GetAllBooksAsync();
            var book = books.FirstOrDefault(x => x.BookId == item.BookId);
            if (book is null)
            {
                return NotFound();
            }
            await _bookService.UpdateBookAsync(item);
            return Ok(item);
        }
        [HttpPost]
        public async Task<ActionResult<BookDTO>> Create(BookDTO item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            await _bookService.AddBookAsync(item);
            return Ok(item);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<BookDTO>> Delete(int id)
        {
            var books = await _bookService.GetAllBooksAsync();
            var book = books.FirstOrDefault(x => x.BookId == id);
            if (book is null)
            {
                return NotFound();
            }
            await _bookService.DeleteBookAsync(id);
            return Ok(book);
        }
        [HttpPut("CutBook/{id}")]
        public async Task<ActionResult<BookDTO>> CutBook(int id)
        {
            var books = await _bookService.GetAllBooksAsync();
            var book = books.FirstOrDefault(x => x.BookId == id);
            if (book is null)
            {
                return NotFound();
            }
            await _bookService.CutBookAsync(id);
            return Ok(book);
        }
    }
}
