namespace IServer
{
    public interface InterfaceServer
    {
        void Connect(string dbName, string collectionName);
        string FindPersonTest(string parametr, string value);
        string FindPersonTest(string parametr0, string value0, string parametr1, string value1);
        string AddPersonTest(string value);
        bool RemoveTest(string parametr, string value);
        string UpdateUnitTest(string parametr, string oldvalue, string newvalue);
    }
}
