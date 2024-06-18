using layerOne.models;

namespace layerTwo.DTO
{
    public class RentDTO
    {
        public int RentId { get; set; }
        public DateTime Date { get; set; }
        public int BookId { get; set; }
        public BookDTO? Book { get; set; }
        public int UserId { get; set; }
        public UserDTO? User { get; set; }
        public DateTime? DateOff { get; set; }
    }
}
