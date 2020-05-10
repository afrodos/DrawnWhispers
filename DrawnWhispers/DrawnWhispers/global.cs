using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DrawnWhispers
{
    class global
    {
        public static TcpClient tcpclient = new TcpClient("192.168.0.185", 4004);

    }
}
