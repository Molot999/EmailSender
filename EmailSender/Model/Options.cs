using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSender.Model
{
    class Options
    {
        public string SmtpHost;
        public int SmtpPort;
        public string Login;
        public string Password;
        public bool UseSSL;
        public bool UseDefaultCredentials => Login.Length == 0 && Password.Length == 0;

        public Options()
        {

        }
        public Options(string smtpHost, int smtpPort, string login, string password, bool useSSL)
        {
            SmtpHost = smtpHost;
            SmtpPort = smtpPort;
            Login = login;
            Password = password;
            UseSSL = useSSL;
        }
    }
}
