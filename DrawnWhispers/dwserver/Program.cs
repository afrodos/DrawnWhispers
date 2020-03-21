using System;
using System.Collections.Generic;
using System.Text;
using WatsonTcp;

namespace dwserver
{
    class Program
    {
        gameUtils util = new gameUtils();
        static List<string> clients = new List<string>();
        static void Main(string[] args)
        {
            WatsonTcpServer server = new WatsonTcpServer("0.0.0.0", 5002);
            server.ClientConnected += Server_ClientConnected; ;
            server.ClientDisconnected += Server_ClientDisconnected; ;
            server.MessageReceived += Server_MessageReceived; 
            server.Start();


            Console.Read();
        }
        
        private static void Server_MessageReceived(object sender, MessageReceivedFromClientEventArgs e)
        {
            string response = Encoding.UTF8.GetString(e.Data);
            if (response.StartsWith("nm!"))
            {
                string sp = response.Substring(3) + "|" + e.IpPort;
                clients.Add(sp);
                Console.WriteLine("User: " + response.Substring(3) + " joined!");
            }
            Console.WriteLine("Message received from " + e.IpPort + ": " + response);
        }

        private static void Server_ClientDisconnected(object sender, ClientDisconnectedEventArgs e)
        {
            foreach (var i in clients)
            {
                if (i.Contains(e.IpPort))
                    clients.Remove(i);
            }
            Console.WriteLine("Client disconnected: " + e.IpPort + ": " + e.Reason.ToString());
        }

        private static void Server_ClientConnected(object sender, ClientConnectedEventArgs e)
        {
            Console.WriteLine("Client connected: " + e.IpPort);
        }
    }
}
