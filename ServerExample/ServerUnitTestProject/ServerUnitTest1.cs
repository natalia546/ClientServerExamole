using IServer;
using NUnit.Framework;
using System;
using ServerExample;

namespace ServerUnitTestProject
{
    [TestFixture]
    public class ServerUnitTest1
    {
        string dbname = ServerExample.MongoDb.DbInfo.DbName;
        string collectionname = ServerExample.MongoDb.DbInfo.CollectionName;

        [TestCase("0")]
        [TestCase("1")]
        [TestCase("5")]
        public void TestFindOne(string value)
        {
            InterfaceServer iserv = new ServerExample.MongoDb.TestClass();
            iserv.Connect(dbname, collectionname);

            var res = iserv.FindPersonTest("Login", value);
            Assert.AreEqual(res, value);
        }

        [TestCase("Login", "Password", "0")]
        [TestCase("Login", "Password", "1")]
        [TestCase("Login", "Password", "5")]
        public void TestFindOne(string parametr0, string parametr1, string value)
        {
            InterfaceServer iserv = new ServerExample.MongoDb.TestClass();
            iserv.Connect(dbname, collectionname);

            var res = iserv.FindPersonTest(parametr0, value, parametr1, value);
            Assert.AreEqual(res, value);
        }

        [TestCase("5")]
        public void TestAdd(string value)
        {
            InterfaceServer iserv = new ServerExample.MongoDb.TestClass();
            iserv.Connect(dbname, collectionname);
            var res = iserv.AddPersonTest(value);
            Assert.AreEqual(res, value);
        }

        [TestCase("Login", "5")]
        public void TestRemove(string parametr, string value)
        {
            InterfaceServer iserv = new ServerExample.MongoDb.TestClass();
            iserv.Connect(dbname, collectionname);
            var res = iserv.RemoveTest(parametr, value);
            Assert.IsTrue(res);
        }

        [TestCase("Name", "3", "5")]
        public void TestUpdate(string parametr, string oldvalue, string newvalue)
        {
            InterfaceServer iserv = new ServerExample.MongoDb.TestClass();
            iserv.Connect(dbname, collectionname);
            var res = iserv.UpdateUnitTest(parametr, oldvalue, newvalue);
            Assert.AreEqual(res, newvalue);
        }
    }
}
