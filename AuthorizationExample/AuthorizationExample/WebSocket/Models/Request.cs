using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace WebSocketProtocol.Models
{
    //изменено только RequestType
    public class Request
    {
        [JsonProperty ("type")]
        public string type;

        [JsonProperty("path")] public string path;
        
        [JsonConverter(typeof(DateTimeConverter))]
        [JsonProperty ("timestamp")]
        public DateTime timestamp;
        
        [JsonProperty ("GUID")]
        public Guid GUID;
        
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty ("from")]
        public Direction from;
        
        [JsonProperty ("data")]
        public string data;

        public Request() { }
        public Request(string requestType, string requestPath, DateTime timestamp, Guid GUID, Direction from, string data)
        {
            this.type = requestType;
            this.path = requestPath;
            this.timestamp = timestamp;
            this.GUID = GUID;
            this.from = from;
            this.data = data;
        }
        
        //изменено толлько это, остальное как у крока. Переименовала, чтобы не путаться
        public enum RtsimRequestType
        {
           appInfo,
           studentInfo,
           viewInfo,
           controlInfo,
           instrInfo,
           opcSignal,
           auntification
        }
        
        public enum Direction
        {
            server,
            client
        }
    }
}