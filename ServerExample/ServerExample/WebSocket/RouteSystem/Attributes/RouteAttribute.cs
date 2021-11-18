using System;

namespace WebSocketProtocol.RouteSystem.Attributes
{
    //не надо менять, точно такой же как у крока
    [AttributeUsage(AttributeTargets.Method)]
    public class RouteAttribute : Attribute
    {
        public readonly string Type;
        public readonly string Path;

        public RouteAttribute(string type, string path)
        {
            Type = type;
            Path = path;
        }
        
    }
}