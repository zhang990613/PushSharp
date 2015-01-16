using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PushSharp.Core
{
    public class ProxyInformation
    {
        public bool isProxyEnable { get; set; }
        public string ProxyUrl { get; set; }
        public string ProxyUser { get; set; }
        public string ProxyPassword { get; set; }
        public string DomainName { get; set; }

        public ProxyInformation(bool ProxyEnable)
        {
            this.isProxyEnable = ProxyEnable;
            this.ProxyUrl = "";
            this.ProxyUser = "";
            this.ProxyPassword = "";
            this.DomainName = "";

        }

        public ProxyInformation(bool ProxyEnable, string url, string user, string password, string domain)
        {
            this.isProxyEnable = ProxyEnable;
            this.ProxyUrl = url;
            this.ProxyUser = user;
            this.ProxyPassword = password;
            this.DomainName = domain;

        }
    }
}
