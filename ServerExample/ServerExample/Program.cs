using ServerExample.Models;
using ServerExample.MongoDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerExample
{
    class Program
    {
        static void Main(string[] args)
        {
          //  FileStreamClass.ServerGetMessageAction += FileStreamClass_ServerGetMessageAction;
            #region test mongodb
            MongoDbClass mdb = new MongoDbClass();
            mdb.Connect("");
            mdb.GetDataBase(DbInfo.DbName, DbInfo.CollectionName);
            for(int i=0;i<5;i++)
            {
                mdb.AddUnit(new Person(i.ToString(), i.ToString(), i.ToString()));
            }
            foreach (var l in mdb.GetCollection())
            {
                 Console.WriteLine(l);
            }

            // var m= mdb.FindOne("Login", "1");
            //    Console.WriteLine(m);
            var test = new TestClass();
            test.Connect(DbInfo.DbName, DbInfo.CollectionName);
            var p=test.FindPersonTest("Login", "1");
            Console.WriteLine(p);
            #endregion

            #region test websocket
          
            #endregion

            //  Console.WriteLine(mdb.FindOne("FullName", "2"));
            Console.ReadLine();
        }
    }
}
