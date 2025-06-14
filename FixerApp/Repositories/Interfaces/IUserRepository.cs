using System.Data;
using FixerApp.Models.Entities;
using FixerApp.Models.Entities.Enums;

namespace FixerApp.Repositories.Interfaces
{
    public interface IUserRepository
    {
        User? FindByEmail(string email);
        User? FindByUsername(string username);
        List<User> FindByRole(UserRole role);
        bool ExistsByEmail(string email);
        bool ExistsByUsername(string username);
        List<User> SearchWorkersByCategoryAndLocation(string category, string location);
        User? GetById(long id);
        List<User> GetAll();
        User Update(User user);
        void Delete(User user);
    }
}
