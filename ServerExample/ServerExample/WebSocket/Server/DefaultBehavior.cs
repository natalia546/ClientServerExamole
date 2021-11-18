using System;
using WebSocketSharp.Server;

namespace WebSocketProtocol.Server
{
    //не надо менять, отличается от крока, так как добавлен новый метод
    public abstract class DefaultBehavior: WebSocketBehavior
    {
        public event Action<DefaultBehavior> OnOpenEvent;
        public event Action<DefaultBehavior> OnCloseEvent;
        public event Action<Exception> OnErrorEvent;
        public event Action OnLastClientDisconnected;
        /// <summary>
        /// отправка всем
        /// </summary>
        /// <param name="data"></param>
        public void SendDataToAll(string data)
        {
           
            Sessions.Broadcast(data);//рассылка всем 
            //Send(data);//рассылка только одному
        }
        /// <summary>
        /// отправка только одному
        /// </summary>
        /// <param name="data"></param>
        public void SendDataToOne(string data)
        {
            Send(data);//рассылка только одному
        }

        protected virtual void OnOnOpenEvent(DefaultBehavior obj)
        {
            if (OnOpenEvent != null) OnOpenEvent.Invoke(obj);
            
        }

        protected virtual void OnOnCloseEvent(DefaultBehavior obj)
        {
            if (OnCloseEvent != null) OnCloseEvent.Invoke(obj);
        }

        protected virtual void OnOnErrorEvent(Exception obj)
        {
            if (OnErrorEvent != null) OnErrorEvent.Invoke(obj);
        }

        protected virtual void OnOnLastClientDisconnected()
        {
            if (OnLastClientDisconnected != null) OnLastClientDisconnected.Invoke();
        }
    }
}