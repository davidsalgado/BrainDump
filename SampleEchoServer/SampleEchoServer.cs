using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SampleEchoServer
{
    class Program
    {
	//Let's assume that port 8888 is available
        static void Main(string[] args) => Task.WaitAll(new Server().StartAsync(8888));
    }

    public class Server
    {

        public async Task StartAsync(int port)
        {

            TcpListener server = new TcpListener(IPAddress.Any, port);
            server.Start();
            Console.WriteLine($"Server started on port {port}");
            while (true)
            {
                try
                { 
                    await HandleClientAsync(await server.AcceptTcpClientAsync());
                }
                catch (Exception ex)
                { 
                    Console.WriteLine($"That hurt... trying to recover from an exception:'{ex.Message}'");
                }
            }
        }

        public async Task HandleClientAsync(TcpClient c)
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
                        switch (msg = await input.ReadLineAsync())
                        {
                            case "done":
                                connected = false;
                                break;
                            default:
                                await output.WriteLineAsync(msg);
                                break;
                        }
                    }
                }

            }
            c.Close();
            Console.WriteLine("bye...");
        }
    }
}
