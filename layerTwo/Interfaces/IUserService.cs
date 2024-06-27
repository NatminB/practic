using layerTwo.DTO;

namespace layerTwo.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAllUsersAsync();
        Task<IEnumerable<UserDTO>> GetUsersWithRentsAsync();
        Task<UserDTO> GetUserByIdAsync(int userId);
        Task<UserDTO> AddUserAsync(UserDTO userDTO);
        Task DeleteUserAsync(int userId);
        Task UpdateUserAsync(UserDTO userDTO);
    }
}
