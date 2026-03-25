using CommBank_Server.Models;
using MongoDB.Driver;

namespace CommBank_Server.Services;

public class AuthService : IAuthService
{
    private readonly IMongoCollection<User> _usersCollection;

    public AuthService(IMongoDatabase mongoDatabase)
    {
        _usersCollection = mongoDatabase.GetCollection<User>("Users");
    }

    public async Task<User?> Login(string email, string password) => 
        await _usersCollection.Find(u => u.Email == email && u.Password == password).FirstOrDefaultAsync();

    public async Task<User?> Register(User user)
    {
        await _usersCollection.InsertOneAsync(user);
        return user;
    }
}
