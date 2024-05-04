using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ECommerce.Catalog.Entities
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProdcutID { get; set; }
        public string ProdcutName { get; set; }
        public Decimal ProdcutPrice { get; set; }
        public int ProdcutStock { get; set; }
        public string ProdcutImageUrl { get; set; }
        public string ProdcutDescription{ get; set; }
        public string CategoryID{ get; set; }

        [BsonIgnore]
        public Category Category { get; set; }
    }
}
