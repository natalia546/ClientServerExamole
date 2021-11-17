using Newtonsoft.Json;
using ServerNewArc2010;
using ServerNewArc2010.RtsimClasses;
using System;
using WebSocketProtocol.Models;
using WebSocketProtocol.RouteSystem.Attributes;
using WebSocketProtocolz.Client;
using WebSocketSharp;

namespace WebSocketProtocol.Client.Resolver
{
    //не надо менять
    public class ClientResolver
    {
        #region отправка запросов от клиента, не надо ничего менять

        /// <summary>
        /// отправить логин и пароль
        /// </summary>
        /// <param name="webSocketClient"></param>
        /// <param name="modelData"></param>
        public virtual void SendLoginAndPassword(WebSocket webSocketClient, string login, string password)
        {
            webSocketClient.Send(JsonClientRequests.AuntificationRequest(new AutificationInfo(login,password)));
        }


        #endregion

        #region обработка запросов от сервера, надо менять

        /// <summary>
        /// успешная аунтификация
        /// </summary>
        /// <param name="webSocket"></param>
        /// <param name="request"></param>
        [Route("goodAunt", "GoodAuntification")]
        public virtual void AuntificationResponse(WebSocket webSocket, Request request)
        {
            PersonInfo per = JsonConvert.DeserializeObject<PersonInfo>(request.data);
            FileStreamClass.WriteToFormAction(request.data);
        }

        /// <summary>
        /// error
        /// </summary>
        /// <param name="webSocket"></param>
        /// <param name="request"></param>
        [Route("error", "Error")]
        public virtual void ErrorResponse(WebSocket webSocket, Request request)
        {
            FileStreamClass.WriteToFormAction(request.data);
        }


        #endregion

    }
}