using MongoDB.Bson.Serialization.Attributes;

namespace CustomerAPI.Models
{
    public class City
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
