using layerOne.models;

namespace layerTwo.DTO
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public List<RentDTO> Rents { get; set; }
    }
}
