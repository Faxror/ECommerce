using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ECommerce.Catalog.Entities
{
    public class ProductDetail
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProdcutDetailID { get; set; }
        public string ProdcutDescription { get; set; }
        public string ProdcutInformation { get; set; }

        public string ProdcutID { get; set; }
        [BsonIgnore]
        public Product product { get; set; }
    }
}
