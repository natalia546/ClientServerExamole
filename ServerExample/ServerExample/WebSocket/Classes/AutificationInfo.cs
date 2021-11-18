using WebSocketProtocol.Models;

namespace ServerNewArc2010.RtsimClasses
{
    public class AutificationInfo:Data
    {
        public string Login;
        public string Password;
        public string ParametrLog = "Login";
        public string ParametrPas = "Password";

        public AutificationInfo(string login, string password)
        {
            Login = login;
            Password = password;
        }
    }
}
