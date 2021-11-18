using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketProtocol.Server;
using WebSocketProtocol.RouteSystem.Attributes;
using Newtonsoft.Json;
using WebSocketProtocol.Models;
using ServerNewArc2010.RtsimClasses;

namespace ServerNewArc2010.Server.Resolver
{
    /// <summary>
    /// класс отправки запросов от сервера и обработки, ничего не надо менять
    /// </summary>
    public class ServerResolver
    {
        public delegate PersonInfo AuntificationDelegate(AutificationInfo autinfo);
        static public event AuntificationDelegate CheckAuntification;

        /// <summary>
        /// успешная аунтификация
        /// </summary>
        /// <param name="client"></param>
        /// <param name="guid"></param>
        public virtual void GoodAuntificationRequest(DefaultBehavior client, Guid guid, PersonInfo person)
        {
            client.SendDataToOne(JsonServerRequests.GoodAuntificationResponseJson(guid, person));
        }

        /// <summary>
        /// ошибка
        /// </summary>
        /// <param name="client"></param>
        /// <param name="guid"></param>
        /// <param name="error"></param>
        public virtual void ErrorRequest(DefaultBehavior client, Guid guid, string error)
        {
            client.SendDataToOne(JsonServerRequests.ErrorResponseJson(guid, error));
        }


        /// <summary>
        /// Auntification
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        [Route("auntification", "AuntificationRequest")]
        public virtual void AuntificationResponse(DefaultBehavior client, Request request)
        {//обновление

            AutificationInfo autinf = JsonConvert.DeserializeObject<AutificationInfo>(request.data);
            var res = CheckAuntification?.Invoke(autinf);
            if (res != null) GoodAuntificationRequest(client, new Guid(), res);
            else ErrorRequest(client, new Guid(), "Неверно введен логин или пароль");

            FileStreamClass.WriteToFormAction(request.data);
            // OpcSignalRequest(client, new Guid());


        }

    }
}
