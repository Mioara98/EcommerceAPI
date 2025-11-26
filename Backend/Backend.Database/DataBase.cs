using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Domain;
using MongoDB.Driver;

namespace Backend.Database
{
    public class DataBase
    {
        public string ConnectionString { get; set; } = "mongodb+srv://Licenta:licenta@cluster0.0fh6p.mongodb.net/";
        public string DatabaseName { get; set; } = "LicentaDB";
        public string UsersCollection{ get; set; } = "UsersCollection";
        public string ProductCollection { get; set; } = "ProductCollection";
     

        public IMongoCollection<User>GetUsersCollection()
        {
            IMongoClient mongoClient = new MongoClient(ConnectionString);
            IMongoDatabase database = mongoClient.GetDatabase(DatabaseName);
            return database.GetCollection<User>(UsersCollection);
        }
        public IMongoCollection<Product> GetProductCollection()
        {
            IMongoClient mongoClient = new MongoClient(ConnectionString);
            IMongoDatabase database = mongoClient.GetDatabase(DatabaseName);
            return database.GetCollection<Product>(ProductCollection); 
        }


    }
}




