using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography.X509Certificates;


namespace WebSocketProtocol.Server
{
    //адаптированное
    public class WebSocketServer
    {
        public event Action<string> ConnectionErrorEvent;
        public event Action LastClientDisconnectedEvent;
        public event Action OnOpenEvent;

        private readonly WebSocketSharp.Server.WebSocketServer _webSocketServer;
        
        public List<DefaultBehavior> clients = new List<DefaultBehavior>();
        

        public Func<DefaultBehavior> BehaviorFabric = DefaultFabric;
        
        public WebSocketServer(IPAddress ipAddress, 
                                    int port,
                                    bool secure=false, 
                                    string certPath = "", 
                                    string certKey = "")
        {
            _webSocketServer = new WebSocketSharp.Server.WebSocketServer(ipAddress, port, secure);
            if (secure)
            {
                if (certPath.Length <= 0)
                {
                    if (ConnectionErrorEvent != null) ConnectionErrorEvent.Invoke("Certificate path not set.");
                    return;
                }
                // todo: Пока сертификат не валидируется
                _webSocketServer.SslConfiguration.ServerCertificate =
                    new X509Certificate2 (certPath, certKey);
            }
        }

        public void StartServer(string behaviour)
        {
            _webSocketServer.AddWebSocketService('/' + behaviour, AddBehaviorHandler);
            _webSocketServer.Start();
            Logger.Log("Start server... ");
        }

        private DefaultBehavior AddBehaviorHandler()
        {
            var newBehaviour = BehaviorFabric!=null?BehaviorFabric.Invoke():null;

            newBehaviour.OnOpenEvent += behaviour => { clients.Add(behaviour); if(OnOpenEvent!=null) OnOpenEvent.Invoke(); };
            newBehaviour.OnCloseEvent += behaviour => clients.Remove(behaviour);
            newBehaviour.OnLastClientDisconnected += () => { if (LastClientDisconnectedEvent != null)LastClientDisconnectedEvent.Invoke(); };
            return newBehaviour;
        }

        public static DefaultBehavior DefaultFabric()
        {
            TSBehaviour tsBehaviour = new TSBehaviour
            {
                serverResolver = new ServerNewArc2010.Server.Resolver.ServerResolver()
                
            };
            
            tsBehaviour.Initialize();
            
            return tsBehaviour;
        }
        
        public void StopServer(string behaviour)
        {
            _webSocketServer.RemoveWebSocketService('/' + behaviour);
            _webSocketServer.Stop();
            Logger.Log("Stop server... ");
        }

        public bool IsListening()
        {
            return _webSocketServer.IsListening;
        }
    }
}