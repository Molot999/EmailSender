using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSender.Model
{
    class Options
    {
        public string smtpHost;
        public string smtpPort;
        public string login;
        public string password;
        public bool useSSL;

        public Options(string smtpHost, string smtpPort, string login, string password, bool useSSL)
        {
            this.smtpHost = smtpHost;
            this.smtpPort = smtpPort;
            this.login = login;
            this.password = password;
            this.useSSL = useSSL;
        }
    }
}
