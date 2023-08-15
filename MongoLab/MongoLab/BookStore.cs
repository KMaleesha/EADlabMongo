using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoLab
{
    public class BookStore
    {
        [BsonId]
        public string ISBN { get; set; }
        public string BookTitle { get; set; }
        public string Auther { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        [BsonIgnoreIfNull]
        public int? TotalPages { get; set; }
    }

}
