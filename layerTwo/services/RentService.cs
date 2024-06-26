using AutoMapper;
using layerOne.interfaces;
using layerOne.models;
using layerTwo.DTO;
using layerTwo.Interfaces;

public class RentService: IRentService
{
    private readonly IRepository<Rent> _rentRepository;
    private readonly IRepository<Book> _bookRepository;
    private readonly IRepository<User> _userRepository;
    private readonly IMapper _mapper;

    public RentService(IRepository<Rent> rentRepository, IRepository<Book> bookRepository, IRepository<User> userRepository, IMapper mapper)
    {
        _rentRepository = rentRepository;
        _bookRepository = bookRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<RentDTO> StartRentAsync(int bookId, int userId, DateTime date)
    {
        var book = await _bookRepository.GetByIdAsync(bookId);
        var user = await _userRepository.GetByIdAsync(userId);

        var rent = new Rent
        {
            BookId = bookId,
            Book = book,
            UserId = userId,
            User = user,
            Date = date
        };

        var createdRent = await _rentRepository.AddAsync(rent);
        return _mapper.Map<RentDTO>(createdRent);
    }

    public async Task ReturnBookAsync(int rentId, DateTime date)
    {
        var rent = await _rentRepository.GetByIdAsync(rentId, r => r.Book, r => r.User);
        rent.DateOff = date;
        await _rentRepository.UpdateAsync(rent);
    }
}