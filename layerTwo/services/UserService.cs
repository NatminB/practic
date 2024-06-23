using AutoMapper;
using layerOne.interfaces;
using layerOne.models;
using layerTwo.DTO;
using layerTwo.Interfaces;

namespace layerTwo.services
{
    public class UserService : IService<UserDTO>
    {
        private readonly IRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public UserService(IRepository<User> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<bool> AddAsync(UserDTO entity)
        {
            var user = _mapper.Map<User>(entity);
            return await _userRepository.AddAsync(user);
        }

        public async Task DeleteAsync(int id)
        {
            await _userRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<UserDTO>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync(x => x.Rents);
            return _mapper.Map<IEnumerable<UserDTO>>(users);
        }

        public async Task<UserDTO> GetByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return _mapper.Map<UserDTO>(user);
        }

        public async Task UpdateAsync(UserDTO entity)
        {
            var user = _mapper.Map<User>(entity);
            await _userRepository.UpdateAsync(user);
        }
    }
}
