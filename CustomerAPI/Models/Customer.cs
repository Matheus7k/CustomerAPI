using MongoDB.Bson.Serialization.Attributes;

namespace CustomerAPI.Models
{
    public class Customer
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Phone { get; set; }
        public Address Address { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
