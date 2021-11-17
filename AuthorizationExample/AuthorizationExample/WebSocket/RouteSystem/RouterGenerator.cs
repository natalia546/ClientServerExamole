using System;
using System.Linq;
using System.Reflection;
using WebSocketProtocol.RouteSystem.Attributes;


namespace WebSocketProtocol.RouteSystem
{
    //не надо менять, точно такой же как у крока
    public class RouterGenerator
    {
        
        private Router _router;
        private IRouteAgentTypeResolver _typeResolver;

        public static RouterGenerator CreateRouter(IRouteAgentTypeResolver typeResolver = null)
        {
            var generator = new RouterGenerator();
            generator._router = new Router();
            
            if (typeResolver == null)
            {
                generator._typeResolver = new DefaultTypeResolver();
            }
            else
            {
                generator._typeResolver = typeResolver;
            }
            return generator;
        }
        
        public RouterGenerator GenerateRouterFromAttributesOfClass(Type resolverClass)
        {
            var methodsRaw = resolverClass.GetMethods();
            var methods = methodsRaw
            .Where(m => m.GetCustomAttributes(typeof(RouteAttribute)).Any())
            .ToList();
            foreach (var methodInfo in methods)
            {
                var routeAttribute = (RouteAttribute)methodInfo.GetCustomAttribute(typeof(RouteAttribute));
                if (routeAttribute.Type == null)
                {
                    _router.AddRoute(routeAttribute.Path, methodInfo, _typeResolver.CreateInstance(resolverClass));
                }
                else
                {
                    if (!_router.RegisteredSubRouters.ContainsKey(routeAttribute.Type))
                    {
                        _router.RegisteredSubRouters.Add(routeAttribute.Type, new Router());
                    }
                    _router.RegisteredSubRouters[routeAttribute.Type].AddRoute(routeAttribute.Path, methodInfo, _typeResolver.CreateInstance(resolverClass));
                }
            }

            return this;
        }

        public Router GetRouter()
        {
            return _router;
        }
    }

    public interface IRouteAgentTypeResolver
    {
        object CreateInstance(Type t);
    }

    public class DefaultTypeResolver : IRouteAgentTypeResolver
    {
        public object CreateInstance(Type t)
        {
            return System.Activator.CreateInstance(t);
        }
    }
}