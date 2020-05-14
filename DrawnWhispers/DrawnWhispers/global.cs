using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DrawnWhispers
{
    class global
    {
        public void init(string IP)
        {
            ip = IP;
        }

        static string ip = "";
        public static TcpClient tcpclient = new TcpClient(ip, 4004);

    }
}
