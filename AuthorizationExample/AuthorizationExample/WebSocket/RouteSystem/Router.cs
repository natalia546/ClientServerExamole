using System.Collections.Generic;
using System.Reflection;
using WebSocketProtocol.Server;
using WebSocketProtocol.Models;
using WebSocketSharp;

namespace WebSocketProtocol.RouteSystem
{
    //не надо менять, точно такой же как у крока
    public class Router
    {

        public class RouteInfo
        {
            public MethodInfo Method;
            public object Agent;
        }
        
        public Dictionary<string, RouteInfo> RegisteredRoutes;
        public Dictionary<string, Router> RegisteredSubRouters;


        public Router()
        {
            RegisteredRoutes = new Dictionary<string, RouteInfo>();
            RegisteredSubRouters = new Dictionary<string, Router>();
        }
        
        
        public void AddRoute(string path, MethodInfo method, object agent)
        {
            if (!RegisteredRoutes.ContainsKey(path))
            {
                RegisteredRoutes.Add(path, new RouteInfo()
                {
                    Method = method,
                    Agent = agent
                });
            }
        }

        public void AddSubRouter(string type, Router router)
        {
            if (!RegisteredSubRouters.ContainsKey(type))
            {
                RegisteredSubRouters.Add(type, router);
            }
        }

        public RouteInfo ResolveRequest(Request request)
        {
            if (request.type != null)
            {
                if (RegisteredSubRouters.ContainsKey(request.type))
                {
                    return RegisteredSubRouters[request.type].ResolveRequest(request);
                }
            }

            if (RegisteredRoutes.ContainsKey(request.path))
            {
                return RegisteredRoutes[request.path];
            }

            return null;
        }

        public bool HandleRequest(Request request, DefaultBehavior behaviour)
        {
            var route = ResolveRequest(request);
            if (route == null)
            {
                return false;
            }

            route.Method.Invoke(route.Agent, new object[]{behaviour, request});
            return true;
        }
        
        public bool HandleResponse(Request request, WebSocket webSocket)
        {
            var route = ResolveRequest(request);
            if (route == null)
            {
                return false;
            }

            route.Method.Invoke(route.Agent, new object[]{webSocket, request});
            return true;
        }
    }
}