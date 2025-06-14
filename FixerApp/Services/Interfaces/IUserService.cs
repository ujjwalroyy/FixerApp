using FixerApp.Models.DTOs;
using FixerApp.Models.Entities;

namespace FixerApp.Services.Interfaces
{
    public interface IUserService
    {
        User? getByEmail(string email);

        UserDto? getUserById(long id);

        List<UserDto> getAllUsers();

        UserDto updateUser(long id, UserDto userDto);

        void deleteUser(long id);

        UserDto GetUser(long id);
    }
}
