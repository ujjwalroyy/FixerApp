using FixerApp.Models.DTOs;
using FixerApp.Models.Entities;
using FixerApp.Repositories.Interfaces;
using FixerApp.Services.Interfaces;

namespace FixerApp.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void deleteUser(long id)
        {
            var user = _userRepository.GetById(id);
            if (user != null)
            {
                _userRepository.Delete(user);
            }
        }

        public List<UserDto> getAllUsers()
        {
            return _userRepository.GetAll()
                .Where(u => u != null)
                .Select(u => new UserDto
                {
                    Id = u.Id,
                    Name = u.Name ?? string.Empty,
                    Email = u.Email ?? string.Empty,
                    Phone = u.Phone ?? string.Empty,
                    Address = u.Address ?? string.Empty,
                    Role = u.Role,
                    Latitude = null,
                    Longitude = null
                })
                .ToList();
        }

        public User? getByEmail(string email)
        {
            return _userRepository.FindByEmail(email);
        }

        public UserDto? getUserById(long id)
        {
            var user = _userRepository.GetById(id);
            if (user == null) return null;

            return new UserDto
            {
                Id = user.Id,
                Name = user.Name ?? string.Empty,
                Email = user.Email ?? string.Empty,
                Phone = user.Phone ?? string.Empty,
                Address = user.Address ?? string.Empty,
                Role = user.Role
            };
        }

        public UserDto updateUser(long id, UserDto dto)
        {
            var user = _userRepository.GetById(id);
            if (user == null) throw new Exception("User not found");

            user.Name = dto.Name;
            user.Email = dto.Email ?? user.Email;
            user.Phone = dto.Phone ?? user.Phone;
            user.Address = dto.Address ?? user.Address;
            user.Role = dto.Role ?? user.Role;

            var updated = _userRepository.Update(user);

            return new UserDto
            {
                Id = updated.Id,
                Name = updated.Name ?? string.Empty,
                Email = updated.Email ?? string.Empty,
                Phone = updated.Phone ?? string.Empty,
                Address = updated.Address ?? string.Empty,
                Role = updated.Role 
            };
        }

        public UserDto GetUser(long id)
        {
            return getUserById(id)!;
        }
    }
}
