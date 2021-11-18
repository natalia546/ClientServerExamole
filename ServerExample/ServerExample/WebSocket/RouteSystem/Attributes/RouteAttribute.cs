using System;

namespace WebSocketProtocol.RouteSystem.Attributes
{
    //�� ���� ������, ����� ����� �� ��� � �����
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