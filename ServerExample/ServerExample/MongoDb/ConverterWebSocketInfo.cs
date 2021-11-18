using ServerExample.Models;
using ServerNewArc2010.RtsimClasses;

namespace ServerExample.MongoDb
{
    public static class ConverterWebSocketInfo
    {
        public static PersonInfo ToPersonInfo(Person person)
        {
            var perInfo = new PersonInfo() { Id = person.Id.ToString(), Name = person.Name, Login = person.Login, Password = person.Password };
          
            return perInfo;
        }
    }
}
