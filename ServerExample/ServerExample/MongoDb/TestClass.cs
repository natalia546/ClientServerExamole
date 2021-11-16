namespace ServerExample.MongoDb
{
    public class TestClass : InterfaceServer
    {
        MongoDbClass mdb;

        public void Connect(string dbName, string collectionName)
        {
            mdb = new MongoDbClass();
            mdb.Connect("");
            mdb.GetDataBase(dbName, collectionName);
        }

        public string FindTest(string parametr, string value)
        {
            try
            {
                var p = mdb.FindOne(parametr, value);
                return p.GetValueOfParametr(parametr);
            }
            catch
            {
                return null;
            }
        }

        public string FindTest(string parametr0, string value0, string parametr1, string value1)
        {
            try
            {
                var p = mdb.FindOne(parametr0, value0, parametr1, value1);
                return p.GetValueOfParametr(parametr0);
            }
            catch
            {
                return null;
            }
        }

        public string AddTest(string value)
        {
            mdb.AddUnit(new Model.Person(value));
            return FindTest("Login", value);
        }

        public bool RemoveTest(string parametr, string value)
        {
            mdb.RemoveUnit(parametr, value);
            var p = FindTest(parametr, value);
            if (p != null)
                return false;
            else return true;
        }

        public string UpdateUnitTest(string parametr, string oldvalue, string newvalue)
        {
            mdb.UpdateUnit(parametr, oldvalue, newvalue);
            return FindTest(parametr, newvalue);


        }
    }
}
