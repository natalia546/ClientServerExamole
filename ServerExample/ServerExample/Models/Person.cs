using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerExample.Models
{
    public class Person : DbData
    {
        string name;
        public string Name { get => name; }
        string login;
        public string Login { get => login; }
        string password;
        public string Password { get => password; }
        public List<Exersice> Exersices;

        public Person(string name, string login, string password)
        {
            this.name = name;
            this.login = login;
            this.password = password;
            Exersices = new List<Exersice>();
        }

        public void EditName(string editname)
        {
            name = editname;
        }
        
        public void EditLogin(string editlogin)
        {
            login = editlogin;
        }

        public void EditPassword(string editpassword)
        {
            password = editpassword;
        }

        public override string ToString()
        {
            return "Login: " + Id +
                "\nLogin: " + Login +
                "\nPassword: " + Password +
                "\nName: " + Name;


        }

        public string GetValueOfParametr(string paramert)
        {
            string value = "";
            switch (paramert)
            {
                case "Login": value = Login; break;
                case "Password": value = Password; break;
                case "Id": value = Id.ToString(); break;
                case "Name": value = Name; break;
            }
            return value;
        }

    }

}
