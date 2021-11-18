using Newtonsoft.Json;
using WebSocketProtocol.Models;
using WebSocketProtocol.RouteSystem;
using WebSocketSharp;
using ServerNewArc2010.Server.Resolver;
using ServerNewArc2010;

namespace WebSocketProtocol.Server
{
    //адаптированное
    public class TSBehaviour : DefaultBehavior
    {
        
        public ServerResolver serverResolver;

        public Router routeSystem;

        public void Initialize()
        {
            GenerateRouter();
        }
        private void GenerateRouter()
        {
            var generator = RouterGenerator.CreateRouter();
            generator.GenerateRouterFromAttributesOfClass(serverResolver.GetType());
            routeSystem = generator.GetRouter();
        }
        
        protected override void OnOpen()
        {
            OnOnOpenEvent(this);
            Logger.Log("Client connected {this.ID}");
            
        }
        
        protected override void OnClose(CloseEventArgs e)
        {
            OnOnCloseEvent(this);
            Logger.Log("Client disconnected {this.ID}");

            if (Sessions.Count == 0)
                OnOnLastClientDisconnected();
        }

        protected override void OnError(ErrorEventArgs e)
        {
            OnOnErrorEvent(e.Exception);
            Logger.Log("Client error {e.Message}");
        }

        protected override void OnMessage(MessageEventArgs e)
        {
           // FileStreamClass.WriteToFormAction(e.Data);
            Request request = JsonConvert.DeserializeObject<Request>(e.Data);
            routeSystem.HandleRequest(request, this);
        }
    }
}