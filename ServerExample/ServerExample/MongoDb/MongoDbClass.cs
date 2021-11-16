using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using ServerExample.Models;

namespace ServerExample.MongoDb
{
    public class MongoDbClass
    {
        string connectionString;
        MongoClient client;
        MongoServer server;
        MongoCollection<DbData> collection;
        MongoDatabase database;
        public void Connect(string url)
        {
            if (url == "") connectionString = "mongodb://localhost:27017";
            else
                connectionString = url;
            client = new MongoClient(connectionString);
            server = client.GetServer();

        }

        public void AddUnit(DbData dbData)
        {
            collection.Insert(dbData);
        }

        public void RemoveUnit(string parametr, string value)
        {
            var query = new QueryDocument(parametr, value);
            collection.Remove(query);
        }
        public DbData FindOne(string parametr, string value)
        {
            var query = new QueryDocument(parametr, value);

            return collection.Find(query).First();
        }

        public DbData FindOne(string parametr0, string value0, string parametr1, string value1)
        {
            try
            {
                var query = Query.And(
                     Query.EQ(parametr0, value0),
                     Query.EQ(parametr1, value1)
                 );
                return collection.Find(query).First();
            }
            catch
            {
                return null;
            }
        }
        public void UpdateUnit(string parametr, string oldvalue, string newvalue)
        {
            var query = Query.EQ(parametr, oldvalue);
            var update = Update.Set(parametr, newvalue);
            var updatedUnit = collection.Update(query, update);
        }
        public void GetDataBase(string dbname, string collectionName)
        {
            database = server.GetDatabase(dbname);
            collection = database.GetCollection<DbData>(collectionName);
        }
        public List<DbData> GetCollection()
        {
            MongoCursor<DbData> cursor = collection.FindAllAs<DbData>();

            return cursor.ToList();
        }
    }
}
