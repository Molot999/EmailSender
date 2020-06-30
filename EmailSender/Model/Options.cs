using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EmailSender.Model
{
    class Options
    {
        public string SmtpHost;
        public int SmtpPort = 234;
        public string Login = "";
        public string Password = "";
        public bool UseSSL;

        public bool GetUseDefaultCredentials()
        {
            return string.IsNullOrEmpty(Login) && string.IsNullOrEmpty(Password);
        }

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
