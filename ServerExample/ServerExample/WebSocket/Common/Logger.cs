#if UNITY_5_3_OR_NEWER
using UnityEngine;
#else
using System;
#endif 

namespace WebSocketProtocol
{
    //не надо менять, точно такой же как у крока
    public static class Logger
    {
        public static void Log(string message)
        {
#if UNITY_5_3_OR_NEWER
            Debug.Log(message);
#else
            Console.WriteLine(message);
#endif            
        }
    }
}