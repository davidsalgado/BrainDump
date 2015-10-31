using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SampleEchoServer
{
    public class Server
    {
        const string Message = "Echo!";

        public void Start(int port)
        {

            TcpListener server = new TcpListener(IPAddress.Any, port);
            server.Start();
            Console.WriteLine($"Server started on port {port}");
            while (true)
            {
              HandleConnection(server);
            }
        }

        private void HandleConnection(TcpListener server) => HandleClient(server.AcceptTcpClient());   
        
        public void HandleClient(TcpClient c)
        {
            string msg = null;
            bool connected = true;

            Console.WriteLine($"Connection accepted {DateTime.Now.ToShortTimeString()}");
            using (var output = new StreamWriter(c.GetStream(), UTF32Encoding.ASCII) { AutoFlush = true })
            {
                using (var input = new StreamReader(c.GetStream(), UTF32Encoding.ASCII))
                {
                    while (connected)
                    {
                        switch (msg = input.ReadLine())
                        {
                            case "done":
                                connected = false;
                                break;                               
                            default:
                                output.WriteLine(Message);
                                break;
                        }
                    }
                }
            }
            c.Close();
            Console.WriteLine("bye...");
        }
    }


    class Program
    {
        static void Main(string[] args) => new Server().Start(8888);        
    }
}
