using ServerExample.Models;

namespace ServerExample.MongoDb
{
    public class TestClass : IServer.InterfaceServer
    {
        MongoDbClass mdb;
        public void Connect(string dbName, string collectionName)
        {
            mdb = new MongoDbClass();
            mdb.Connect("");
            mdb.GetDataBase(dbName, collectionName);
        }

         public string FindPersonTest(string parametr, string value)
           {
               try
               {
                   Person p = (Person)mdb.FindOne(parametr, value);
                   return p.GetValueOfParametr(parametr);
               }
               catch
               {
                   return null;
               }
           }

           public string FindPersonTest(string parametr0, string value0, string parametr1, string value1)
           {
               try
               {
                   Person p = (Person)mdb.FindOne(parametr0, value0, parametr1, value1);
                   return p.GetValueOfParametr(parametr0);
               }
               catch
               {
                   return null;
               }
           }

           public string AddPersonTest(string value)
           {
               var p = new Models.Person(value,value,value);
               mdb.AddUnit(p);
               return FindPersonTest("Login", value);
           }

           public bool RemoveTest(string parametr, string value)
           {
               mdb.RemoveUnit(parametr, value);
               var p = FindPersonTest(parametr, value);
               if (p != null)
                   return false;
               else return true;
           }

           public string UpdateUnitTest(string parametr, string oldvalue, string newvalue)
           {
               mdb.UpdateUnit(parametr, oldvalue, newvalue);
               return FindPersonTest(parametr, newvalue);


           }
    }
}
