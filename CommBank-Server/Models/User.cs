using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace CommBank_Server.Models;

public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? Password { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public List<string>? GoalIds { get; set; } = new();
}
