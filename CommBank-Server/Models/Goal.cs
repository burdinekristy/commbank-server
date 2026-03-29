using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace CommBank_Server.Models;

[BsonIgnoreExtraElements]
public class Goal
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("Name")]
    public string? Name { get; set; }

    public string? Description { get; set; }

    [BsonIgnoreIfNull]
    public string? Icon { get; set; }
    
    public decimal? TargetAmount { get; set; }
    public DateTime TargetDate { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public List<string>? TransactionIds { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public List<string>? TagIds { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string? UserId { get; set; }
}
