﻿using System.Collections.Generic;
using WebSocketProtocol.Models;

namespace WebSocketExample.RtsimClasses
{
    public class PersonInfo : Data
    {

        public string Id { set; get; }
        public string Login { set; get; }
        public string Password { set; get; }
        public string Name { set; get; }

        public override string ToString()
        {
            return "Login: " + Login +
                "\nPassword: " + Password +
                "\nName: " + Name;
        }
    }
}
