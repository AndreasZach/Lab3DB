using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace Lab3DB
{
    class Business
    {
        [BsonId]
        public ObjectId _id { get; private set; }

        public string name { get; private set; }

        public int stars { get; private set; }

        public List<string> categories {get; set;} 

        public Business(string id, string name, int stars, List<string> categories)
        {
            this.categories = categories;
            _id = new ObjectId(id);
            this.name = name;
            this.stars = stars;
        }
    }
}
