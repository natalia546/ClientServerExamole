using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerExample.Models
{
    class DbData
    {
        [BsonId]
        public ObjectId Id { set; get; }
    }
}
