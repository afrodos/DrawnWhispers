using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;

namespace DWhttpserv
{
    class Program
    {
        static List<string> activeLobbies = new List<string>();
        static string responseString;
        static string ip = "http://localhost:4004/";
        static void Main(string[] args)
        {
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add(ip);
            listener.Start();
            Console.WriteLine("Server started on: " + ip);
            bool temp = true;
            while (true)
            {
                HttpListenerContext context = listener.GetContext();
                HttpListenerRequest request = context.Request;
                HttpListenerResponse response = context.Response;
                string reqData = GetRequestData(request);
                if (!reqData.StartsWith("/createLobby"))
                {
                    Console.WriteLine("Unknown command received: " + reqData);
                    responseString = "Unknown command";
                    temp = false;
                }
                if(activeLobbies.Contains(reqData.Split(' ')[1]))
                {
                    responseString = "joinlobby";
                    temp = false;
                }
                if (temp)
                {
                    StartTheThread(reqData);
                    responseString = "joinlobby";
                }
                foreach (var i in activeLobbies)
                {
                    Console.WriteLine(i);
                }
                byte[] buffer = Encoding.UTF8.GetBytes(responseString);
                using (Stream outStream = response.OutputStream)
                {
                    outStream.Write(buffer, 0, buffer.Length);
                    Console.WriteLine("response sent: " + responseString);
                }
                temp = true;
            }

            string GetRequestData(HttpListenerRequest request)
            {
                if (!request.HasEntityBody)
                {
                    return "No client data was sent with the request.";
                }
                Stream body = request.InputStream;
                Encoding encoding = request.ContentEncoding;
                StreamReader reader = new StreamReader(body, encoding);
                string s = reader.ReadToEnd();
                body.Close();
                reader.Close();
                return s;
            }

            Thread StartTheThread(string param1)
            {
                var t = new Thread(() => startLobby(param1));
                t.Start();
                return t;
            }

            void startLobby(string lobbyCommand)
            {
                string responseStr = "";
                string lobbyName = lobbyCommand.Split(' ')[1];
                List<string> clientNames = new List<string>();
                activeLobbies.Add(lobbyName);
                Console.WriteLine("Lobby created with lobby name: " + lobbyName);
                HttpListener listen = new HttpListener();
                listen.Prefixes.Add(ip + lobbyName + "/");
                listen.Start();
                while (true)
                {
                    HttpListenerContext context = listen.GetContext();
                    HttpListenerRequest request = context.Request;
                    HttpListenerResponse response = context.Response;
                    string clientIP = context.Request.RemoteEndPoint.ToString();
                    string command = GetRequestData(request);
                    string[] com = command.Split(' ');
                    switch (com[0])
                    {
                        case "/join":
                            if (clientNames.Contains(com[1]))
                            {
                                responseStr = "Username already taken";
                                Console.WriteLine("User " + clientIP + " wanted to join with username: " + com[1]);
                                break;
                            }
                            clientNames.Add(com[1]);
                            responseStr = "Successfully joined";
                            break;

                        case "/leave":
                            try
                            {
                                clientNames.Remove(com[1]);
                                if (!clientNames.Any())
                                {
                                    Console.WriteLine("Closing lobby: " + lobbyName);
                                    Thread.CurrentThread.Abort();
                                }
                            }
                            catch
                            {
                                responseStr = "User not in lobby";
                            }
                            break;

                        default:
                            Console.WriteLine("Unknown command: " + command);
                            responseStr = "Error";
                            break;
                    }



                    byte[] buffer = Encoding.UTF8.GetBytes(responseStr);
                    using (Stream outStream = response.OutputStream)
                    {
                        outStream.Write(buffer, 0, buffer.Length);
                        Console.WriteLine("response sent: " + responseStr);
                    }

                }

            }
        }
    }
}
