using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerExample.Models
{
    public class DbData
    {
        [BsonId]
        public ObjectId Id {get; } = ObjectId.GenerateNewId();
    }
}
