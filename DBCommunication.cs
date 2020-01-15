using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Lab3DB
{
    class DBCommunication
    {

        public MongoClient localClient;
        public IMongoDatabase database;
        public IMongoCollection<Business> collection;

        /// <summary>
        ///  Creates and connects to a database and collection when an instance of this class is created.
        /// </summary>
        public DBCommunication()
        {
            localClient = new MongoClient("mongodb://localhost:27017");
            database = localClient.GetDatabase("Lab3");
            collection = database.GetCollection<Business>("restaurants");
        }

        /// <summary>
        /// Inserts a List of "Business" objects into the database collection.
        /// </summary>
        /// <param name="businesses"></param>
        public void InsertBusinesses(List<Business> businesses)
        {
            collection.InsertMany(businesses);
        }


        /// <summary>
        /// Retrieves all current documents in the collection, and prints the result to the console.
        /// </summary>
        public async void PrintAll()
        {
            Console.WriteLine("All businesses:\n");
            await collection.Find(new BsonDocument()).ForEachAsync(
                x => Console.WriteLine(x.ToBsonDocument()));
        }
        
        /// <summary>
        /// Retrieves all documents with the category "Cafe" in the collection, and prints the result to the console.
        /// </summary>
        public void PrintCafes()
        {
            Console.WriteLine("All Cafes:\n");
            var filter = Builders<Business>.Filter.Eq("categories", "Cafe");
            var findCafes = collection.Find(filter).
                Project(Builders<Business>.Projection.Exclude("_id").Exclude("stars").Exclude("categories")).ForEachAsync(x => Console.WriteLine(x));
        }


        /// <summary>
        /// Finds one document with the "name" value of "XYZ Coffee Bar", and increments its "stars" value by 1.
        /// It then prints all current documents in the collection to the console.
        /// </summary>
        public void UpdateXYZCoffeeBar()
        {
            Console.WriteLine("Incremented 'stars' rating of XYZ Coffee Bar.\n");
            var filter = Builders<Business>.Filter.Eq("name", "XYZ Coffee Bar");
            var incMatched = Builders<Business>.Update.Inc("stars", 1);
            collection.UpdateOne(filter, incMatched);

            PrintAll();
        }


        /// <summary>
        /// Finds one document with the "name" value of "456 Cookies Shop", and changes the "name" value to "123 Cookies Heaven"
        /// It then prints all current documents in the collection to the console.
        /// </summary>
        public void Update456CookiesShop()
        {
            Console.WriteLine("Changed the name of '456 Cookies Shop' to '123 Cookies Heaven'\n");
            var filter = Builders<Business>.Filter.Eq("name", "456 Cookies Shop");
            var renameMatched = Builders<Business>.Update.Set("name" ,"123 Cookies Heaven");
            collection.UpdateOne(filter, renameMatched);

            PrintAll();
        }

        /// <summary>
        /// Finds all current documents in the collection with a "stars" value of equal to, or greater than 4
        /// </summary>
        public void PrintGreaterThan4Stars()
        {
            Console.WriteLine("Showing all businesses with equal to, or greater than 4 stars:\n");
            var filter = Builders<Business>.Filter.Gt("stars", 3);
            var result = collection.Find(filter).Project(Builders<Business>.Projection.Exclude("_id").Exclude("categories")).ToList();
            result.ForEach(x => Console.WriteLine(x));
            Console.WriteLine("\n\nPress any key to exit the program...");
        }
    }
}
