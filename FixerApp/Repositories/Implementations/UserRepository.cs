using FixerApp.Models.Entities;
using FixerApp.Models.Entities.Enums;
using FixerApp.Repositories.Interfaces;
using FixrApp.Data;

namespace FixerApp.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public User? FindByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }

        public User? FindByUsername(string username)
        {
            return _context.Users.FirstOrDefault(u => u.Name == username);
        }

        public List<User> FindByRole(UserRole role)
        {
            return _context.Users.Where(u => u.Role == role).ToList();
        }

        public bool ExistsByEmail(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }

        public bool ExistsByUsername(string username)
        {
            return _context.Users.Any(u => u.Name == username);
        }

        public List<User> SearchWorkersByCategoryAndLocation(string category, string location)
        {
            return _context.Users.Where(u => u.Role == UserRole.WORKER &&
                                             u.Address!.ToLower().Contains(location.ToLower()) &&
                                             u.DocumentUrl!.ToLower().Contains(category.ToLower())).ToList();
        }

        public User? GetById(long id)
        {
            return _context.Users.Find(id);
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User Update(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
            return user;
        }

        public void Delete(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }
}
