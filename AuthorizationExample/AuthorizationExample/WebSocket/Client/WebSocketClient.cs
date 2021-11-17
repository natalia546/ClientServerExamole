using System;
using Newtonsoft.Json;
using WebSocketProtocol.Client.Resolver;
using WebSocketProtocol.Models;
using WebSocketProtocol.RouteSystem;
using WebSocketSharp;

namespace WebSocketProtocol.Client
{
   //не надо менять, адаптированный
    public class WebSocketClient
    {
        private readonly string _host;
        private readonly WebSocket _webSocketClient;

        public event Action<string> ConnectedEvent;
        public event Action DisconnectedEvent;
        public event Action<string> ConnectionErrorEvent;
        
        private ClientResolver _clientResolver;
      

        public Router routeSystem;

        public WebSocket Client {get {return _webSocketClient;}}
        public ClientResolver ClientsResolver
        {
            get {return _clientResolver;}
            set { _clientResolver = value; }
        }

        public WebSocketClient(string host)
        {
            _host = host;
            _webSocketClient = new WebSocket(_host);
        }

        private void InitializeVariables()
        {
            _clientResolver = _clientResolver ?? new ClientResolver();
            
            AddClientEvents();
            GenerateRouter();
        }

        private void GenerateRouter()
        {
            var generator = RouterGenerator.CreateRouter();
            generator.GenerateRouterFromAttributesOfClass(_clientResolver.GetType());
             routeSystem = generator.GetRouter();
        }
        
        private void AddClientEvents()
        {
            _webSocketClient.OnOpen += OnOpenHandler;          // соединение с сервером установлено
            _webSocketClient.OnMessage += OnMessageHandler;    // все сообщения приходящие с сервера
            _webSocketClient.OnError += OnErrorHandler;        // все приходящие ошибки
            _webSocketClient.OnClose += OnCloseHandler;        // соединение с сервером закрыто
        }
        private void OnErrorHandler(object sender, ErrorEventArgs e)
        {
            Logger.Log("WebSocket Error: " + e.Message);
            if(ConnectionErrorEvent!=null)ConnectionErrorEvent.Invoke(e.Message);
        }
        private void OnCloseHandler(object sender, CloseEventArgs e)
        {
            Logger.Log("WebSocket close " + e.Code + " " + e.Reason);
            if (DisconnectedEvent != null) DisconnectedEvent.Invoke();
        }
        public WebSocketState GetWebSocketClientState()
        {
            return _webSocketClient.ReadyState;
        }
        public void ConnectToServer()
        {
            InitializeVariables();
            _webSocketClient.Connect();
            
           
        }
        public void DisconnectFromServer()
        {
            _webSocketClient.Close();
        }
        private void OnOpenHandler(object sender, EventArgs e)
        {
            string connectedMsg = "Client connected to Server " + _host;
            if (ConnectedEvent != null) ConnectedEvent.Invoke(connectedMsg); 
        }
        private void OnMessageHandler(object sender, MessageEventArgs e)
        {
           // FileStreamClass.WriteToFormAction(e.Data);
            Request request = JsonConvert.DeserializeObject<Request>(e.Data);
            routeSystem.HandleResponse(request, _webSocketClient);
        }
    }
}