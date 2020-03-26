using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WatsonTcp;

namespace DrawnWhispers
{
    class global
    {
        public static WatsonTcpClient client = new WatsonTcpClient("192.168.0.185", 5002);
    }
}
