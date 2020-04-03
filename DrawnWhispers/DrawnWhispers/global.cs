using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace DrawnWhispers
{
    class global
    {
        public static TcpClient client = new TcpClient();

        public static void send(string message)
        {
            using (StreamWriter writer = new StreamWriter(client.GetStream(), Encoding.ASCII))
            {
                writer.Write(message);
            }
        }

    }
}
