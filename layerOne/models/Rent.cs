namespace layerOne.models
{
    public class Rent
    {
        public int RentId { get; set; }
        public DateTime Date { get; set; }
        public int BookId { get; set; }
        public Book? Book { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public DateTime? DateOff { get; set; }
    }
}
