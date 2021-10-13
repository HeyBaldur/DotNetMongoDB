using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace MongoSQL.API.Collections.Versions.V1.Models
{
    public class Category
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }
        public string Description { get; set; }

        [BsonElement("Author")]
        public string Author { get; set; }
        public string EmailAddress { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Notes { get; set; }
        public string Image { get; set; }
        public bool IsActive { get; set; }
        public Category()
        {
            CreatedDate = DateTime.Now;
        }
    }
}
