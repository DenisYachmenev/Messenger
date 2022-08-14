using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsClient
{
    internal class Settings
    {
        public string ServiceUri { get; set; } = string.Empty;
        //public Proxy Proxy { get; set; } = new Proxy();
    }

   /* internal class Proxy
    {
        public bool UseProxy { get; set; } = false;
        public string Host { get; set; } = string.Empty;
        public int Port { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }*/
}
