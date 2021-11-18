using ServerExample.Models;
using ServerNewArc2010.RtsimClasses;
using ServerNewArc2010.Server.Resolver;

namespace ServerExample.MongoDb
{
    public class WebSocketFunctions
    {
        MongoDbClass mdb;

        public WebSocketFunctions(MongoDbClass mongof)
        {
            mdb = mongof;
            ServerNewArc2010.Server.Resolver.ServerResolver.CheckAuntification += RtsimServerResolver_CheckAuntification;
        }

        private PersonInfo RtsimServerResolver_CheckAuntification(ServerNewArc2010.RtsimClasses.AutificationInfo autinfo)
        {
            var person = mdb.FindOne(autinfo.ParametrLog, autinfo.Login, autinfo.ParametrPas, autinfo.Password);
            return ConverterWebSocketInfo.ToPersonInfo((Person)person);

        }


    }
}
