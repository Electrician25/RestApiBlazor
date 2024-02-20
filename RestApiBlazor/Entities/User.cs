using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RESTapi.Users
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }
        [BsonElement("Email")]
        public string? Email { get; set; } = null!;
        public string? Password { get; set; } = null!;
    }
}