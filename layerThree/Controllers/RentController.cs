using layerTwo.DTO;
using layerTwo.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace layerThree.Controllers
{
    [Route("/Rent/")]
    [ApiController]
    public class RentController : Controller
    {
        private readonly IRentService _rentService;
        private readonly IBookService _bookService;
        private readonly IUserService _userService;

        public RentController(IRentService rentService, IBookService bookService, IUserService userService)
        {
            _rentService = rentService;
            _bookService = bookService;
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<RentDTO>> StartRent(int bookId, int userId, DateTime date)
        {
            var user = await _userService.GetUserByIdAsync(userId);
            if (user is null)
            {
                return NotFound($"Пользователь с ID {userId} не найден.");
            }
            var books = await _bookService.GetAllBooksAsync();
            var book = books.FirstOrDefault(x => x.BookId == bookId);
            if (book is null)
            {
                return NotFound($"Книга с ID {bookId} не найдена.");
            }
            var rentDto = await _rentService.StartRentAsync(bookId, userId, date);
            return Ok(rentDto);
        }

        [HttpPut("{rentId}")]
        public async Task<ActionResult> ReturnBook(int rentId, DateTime date)
        {
            var rents = await _rentService.GetAll();
            if (rents is null)
            {
                return NotFound();
            }
            await _rentService.ReturnBookAsync(rentId, date);
            return Ok();
        }
    }
}