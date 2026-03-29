using CommBank_Server.Models;
using CommBank_Server.Services;

namespace CommBank.Tests.Fake;

public class FakeUsersService : IUsersService
{
    private readonly List<User> _users;
    private readonly User? _user;

    public FakeUsersService(List<User> users, User? user)
    {
        _users = users;
        _user = user;
    }

    public async Task<List<User>> GetAsync() => await Task.FromResult(_users);

    public async Task<User?> GetAsync(string id) => await Task.FromResult(_user);

    public async Task CreateAsync(User newUser) => await Task.CompletedTask;

    public async Task UpdateAsync(string id, User updatedUser) => await Task.CompletedTask;

    public async Task RemoveAsync(string id) => await Task.CompletedTask;
}
