using Newtonsoft.Json.Converters;

namespace WebSocketProtocol
{
    //не надо менять, точно такой же как у крока
    class DateTimeConverter :IsoDateTimeConverter
    {
            public DateTimeConverter()
            {
                base.DateTimeFormat = "yyyy-MM-ddT HH:mm:ss.fffZ";
            }
    }
}