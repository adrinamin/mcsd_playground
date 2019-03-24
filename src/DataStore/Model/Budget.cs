using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DataStore.Model
{
    public class Budget
    {
        [BsonId]
        public ObjectId ID { get; set; }
        
        [BsonElement("name")]
        public string name{ get; set;}
        
        [BsonElement("amount")]
        public double amount {get; set;}
    }
}