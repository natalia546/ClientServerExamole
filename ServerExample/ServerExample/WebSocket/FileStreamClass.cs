using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerNewArc2010
{
    /// <summary>
    /// класс для записи логов
    /// </summary>
    static class FileStreamClass
    {
        //событие вызова функции и передача текста
        public static event Action<string> ServerGetMessageTimer;
        public static event Action<string> ServerGetMessageAction;


        static public void WriteToFormTimer(string text)
        {
            //событие произошло и передает текст
            if (ServerGetMessageTimer != null) ServerGetMessageTimer(text);
           
        }

        static public void WriteToFormAction(string text)
        {
            //событие произошло и передает текст
            if (ServerGetMessageAction != null) ServerGetMessageAction(text);

        }
    }
}
