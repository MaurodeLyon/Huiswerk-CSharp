using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using sharedLibrary;

namespace Server
{
    class Program
    {
        private static void Main(string[] args)
        {
            IPAddress localhost;
            bool IsIPOk = IPAddress.TryParse("192.168.3.102", out localhost);
            TcpListener listener = new System.Net.Sockets.TcpListener(localhost, 1330);

            // Starts listening for incoming connection requests in the listener-thread:
            listener.Start();

            while (true)
            {
                Console.WriteLine("Waiting for connection");

                //AcceptTcpClient waits for a connection from the client:
                TcpClient client = listener.AcceptTcpClient();

                // handle this client in a new worker-thread 
                // and continue accepting new clients:
                Thread thread = new Thread(HandleClientThread);
                thread.Start(client);
            }

        }

        private static void HandleClientThread(object obj)
        {
            TcpClient client = obj as TcpClient;
            bool done = false;
            while (!done)
            {
                string received = ClientServerUtil.ReadTextMessage(client);
                string[] split = received.Split('|');
                Console.WriteLine("{0}: {1}", split[0], split[1]);

                done = split[1].Equals("bye");
                if (done) ClientServerUtil.WriteTextMessage(client, "BYE");
                else ClientServerUtil.WriteTextMessage(client, "OK");
            }
            client.Close();
            Console.WriteLine("Connection closed");
        }
    }
}
