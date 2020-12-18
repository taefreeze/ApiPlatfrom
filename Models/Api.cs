using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Platform.Models
{
    public class Api
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        public string Privacy { get; set; }

        public string Category { get; set; }

        public string Author { get; set; }
    }
}