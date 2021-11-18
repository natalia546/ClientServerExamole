using System;
using Newtonsoft.Json;
using ServerNewArc2010.RtsimClasses;
using WebSocketProtocol.Models;

namespace WebSocketProtocol.Server
{
    /// <summary>
    /// заворачивание в тип Request
    /// </summary>
    static class JsonServerRequests
    {

        /// <summary>
        /// аунтификация прошла успешно
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public static string GoodAuntificationResponseJson(Guid guid, PersonInfo person)
        {
            string response = JsonConvert.SerializeObject(person);
            Request appResponse = new Request(
                Request.RequestType.goodAunt.ToString(),
                "GoodAuntification",
                DateTime.Now,
                guid,
                Request.Direction.server,
                response);
            return JsonConvert.SerializeObject(appResponse);
        }
        /// <summary>
        /// ошибка
        /// </summary>
        /// <param name="guid"></param>
        /// <param name="person"></param>
        /// <returns></returns>
        public static string ErrorResponseJson(Guid guid, string error)
        {
            Request appResponse = new Request(
                Request.RequestType.error.ToString(),
                "Error",
                DateTime.Now,
                guid,
                Request.Direction.server,
                error);
            return JsonConvert.SerializeObject(appResponse);
        }


    }
}