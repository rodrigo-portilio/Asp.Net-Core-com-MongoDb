using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCoreMongoDb.Models;

namespace WebApiCoreMongoDb
{
    public class Context
    {
        private readonly IMongoDatabase database;

        public Context()
        {
            database = new MongoClient("mongodb://localhost:27017").GetDatabase("WebApiCoreMongoDb");
        }

        public IMongoCollection<Post> Posts
        {
            get
            {
                return database.GetCollection<Post>("Posts");
            }
        }
    }
}
