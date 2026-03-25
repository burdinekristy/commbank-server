using CommBank_Server.Models;

namespace CommBank_Server.Services;

public interface IAuthService
{
    Task<User?> Login(string email, string password);
    Task<User?> Register(User user);
}
