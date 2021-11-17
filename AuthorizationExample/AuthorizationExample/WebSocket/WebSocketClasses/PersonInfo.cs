using System.Collections.Generic;
using WebSocketProtocol.Models;

namespace ServerNewArc2010.RtsimClasses
{
    public class PersonInfo : Data
    {
        public string Id { set; get; }
        public string Login { set; get; }
        public string Password { set; get; }
        public string FullName { set; get; }
        public string Position { set; get; }
        public string Rating { set; get; }
        public List<ExerciseInfo> Exercises { set; get; }

        public override string ToString()
        {
            return "Login: " + Id +
                "\nPassword: " + Password +
                "\nFullName: " + FullName +
                "\nPosition: " + Position +
                "\nRating: " + Rating;
        }

    }
}
