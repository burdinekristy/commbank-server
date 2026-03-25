using CommBank_Server.Models;

namespace CommBank_Server.Services;

public interface IUsersService
{
    Task<List<User>> GetAsync();
    Task<User?> GetAsync(string id);
    Task CreateAsync(User newUser);
    Task UpdateAsync(string id, User updatedUser);
    Task RemoveAsync(string id);
}
