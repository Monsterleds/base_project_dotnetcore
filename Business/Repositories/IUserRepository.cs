using curso.api.Business.Entities;

namespace curso.api.Business.Repositories
{
    public interface IUserRepository
    {
        void Add(User user);
        User FindOne(string email);
        void Commit();
    }
}