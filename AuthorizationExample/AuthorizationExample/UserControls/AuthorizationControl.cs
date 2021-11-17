using WebSocketExample;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocketProtocol.Client;
using System.Threading;
using System.Globalization;

namespace AuthorizationExample.UserControls
{
    public partial class AuthorizationControl : UserControl
    {
        WebSocketClient _client;
        public AuthorizationControl()
        {
            InitializeComponent();
            CreateClient("127.0.0.1", "8000", "Example");
            FileStreamClass.ServerGetMessageAction += FileStreamClass_ServerGetMessageAction;
            ChangeLanguage(LanguageEnum.ru);
        }

        void CreateClient(string ip, string port, string behaviour)
        {
            var _url = string.Concat("ws://", ip, ":", port, "/", behaviour);
            _client = new WebSocketClient(_url);
            _client.ConnectToServer();
        }

        private void FileStreamClass_ServerGetMessageAction(string obj)
        {
            MessageBox.Show(obj);
        }

        private void AuthorizationControl_Load(object sender, EventArgs e)
        {

        }

        private void sendbutton_Click(object sender, EventArgs e)
        {
            _client.ClientsResolver.SendLoginAndPassword(_client.Client, logintextBox.Text, passwordtextBox.Text);
        }

        private void seepasswordbutton_Click(object sender, EventArgs e)
        {
            passwordtextBox.UseSystemPasswordChar = !passwordtextBox.UseSystemPasswordChar;
            seepasswordbutton.Text = passwordtextBox.UseSystemPasswordChar ? Languages.Language.VisibleButton : Languages.Language.InvisibleButton;
        }

        private void langbutton_Click(object sender, EventArgs e)
        {
            if(langbutton.Text== LanguageEnum.en.ToString())
            {
                langbutton.Text = LanguageEnum.ru.ToString();
                ChangeLanguage(LanguageEnum.ru);
            }
            else
            {
                langbutton.Text = LanguageEnum.en.ToString();
                ChangeLanguage(LanguageEnum.en);
            }

            

        }

        void ChangeLanguage(LanguageEnum lang)
        {          
            switch (lang)
            {
                case LanguageEnum.en: Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-EN"); break;
                case LanguageEnum.ru: Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("ru-RU"); break;
            }
            loginlabel.Text = Languages.Language.LoginLable;
            passwordlabel.Text = Languages.Language.PasswordLabel;
            seepasswordbutton.Text = passwordtextBox.UseSystemPasswordChar ? Languages.Language.VisibleButton : Languages.Language.InvisibleButton;
            sendbutton.Text = Languages.Language.SendButton;
        }
    }
}
