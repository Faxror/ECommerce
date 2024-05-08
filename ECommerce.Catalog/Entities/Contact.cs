using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ECommerce.Catalog.Entities
{
    public class Contact
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ContactId { get; set; }

        public string AdSoyad { get; set; }

        public string Email { get; set; }

        public string Title { get; set; }

        public string Message { get; set; }
    }
}
