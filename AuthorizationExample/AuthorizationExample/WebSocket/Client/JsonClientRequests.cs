using System;
using Newtonsoft.Json;
using WebSocketExample.RtsimClasses;
using WebSocketProtocol.Models;

namespace WebSocketProtocolz.Client
{
    //не надо менять, адаптированный
    static class JsonClientRequests
    {
       

        /// <summary>
        /// информация о аунтификации
        /// </summary>
        /// <returns></returns>
        public static string AuntificationRequest(AutificationInfo autInf)
        {
            string response = JsonConvert.SerializeObject(autInf);
            Request opcRequest = new Request(
                Request.RtsimRequestType.auntification.ToString(), "AuntificationRequest",
                DateTime.Now,
                Guid.NewGuid(),
                Request.Direction.client,
                response);
            return JsonConvert.SerializeObject(opcRequest);
        }

      

    }
}