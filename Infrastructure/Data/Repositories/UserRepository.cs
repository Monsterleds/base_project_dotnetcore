using curso.api.Models.User;
using curso.api.Business.Entities;
using curso.api.Business.Repositories;
using System.Linq;

namespace curso.api.Infrastructure.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CourseDbContext _context;

        public UserRepository(CourseDbContext context) {
            _context = context;
        }
        public void Add(User user) {
            _context.User.Add(user);
        }

        public User FindOne(string email) {
            return _context.User.FirstOrDefault(u => u.Email == email);
        }
        public void Commit() {
            _context.SaveChanges();
        }
    }
}