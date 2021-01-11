using curso.api.Business.Entities;

namespace curso.api.Configurations
{
    public interface IJwtAuthenticationService
    {
        string GenerateToken(User user);
    }
}