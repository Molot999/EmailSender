using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EmailSender.Model
{
    class SmtpOptions
    {
        public string SmtpHost;
        public int SmtpPort;
        public string Login = "";
        public string Password = "";
        public bool UseSSL;

        public bool GetUseDefaultCredentials()
        {
            return string.IsNullOrEmpty(Login) && string.IsNullOrEmpty(Password);
        }

        public SmtpOptions()
        {

        }
        public SmtpOptions(string smtpHost, int smtpPort, string login, string password, bool useSSL)
        {
            SmtpHost = smtpHost;
            SmtpPort = smtpPort;
            Login = login;
            Password = password;
            UseSSL = useSSL;
        }

        public void Deconstruct(out string SmtpHost, out int SmtpPort, out string Login, out string Password, out bool UseSSL)
        {
            SmtpHost = this.SmtpHost;
            SmtpPort = this.SmtpPort;
            Login = this.Login;
            Password = this.Password;
            UseSSL = this.UseSSL;
        }
    }
}
