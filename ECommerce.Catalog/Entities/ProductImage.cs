using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ECommerce.Catalog.Entities
{
    public class ProductImage
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductImageID { get; set; }
        public string Iamge1 { get; set; }
        public string Iamge2 { get; set; }
        public string Iamge3 { get; set; }

        public string ProductID { get; set; }
        [BsonIgnore]
        public Product Product { get; set; }
    }
}
