using ServerExample.Models;
using ServerExample.MongoDb;
using ServerNewArc2010;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketProtocol.Server;

namespace ServerExample
{
    class Program
    {
        static WebSocketServer _server;
        static void Main(string[] args)
        {
            FileStreamClass.ServerGetMessageAction += FileStreamClass_ServerGetMessageAction;
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
            WebSocketFunctions webSocketFunctions = new WebSocketFunctions(mdb);
            #endregion

            #region test websocket
            StartServer("127.0.0.1", 8000, "Example");

            #endregion

            //  Console.WriteLine(mdb.FindOne("FullName", "2"));
            Console.ReadLine();
        }
        private static void FileStreamClass_ServerGetMessageAction(string obj)
        {
            Console.WriteLine(obj);
        }

        static void StartServer(string ip, int port, string Behaviour)
        {
            var ipAddress = System.Net.IPAddress.Parse(ip);
            bool secure = false;
            _server = new WebSocketServer(ipAddress, port, secure);//создаем сервер
            _server.StartServer(Behaviour);
            Console.WriteLine("Сервер запущен");
        }
    }
}
