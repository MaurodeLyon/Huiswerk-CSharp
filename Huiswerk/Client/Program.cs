using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using sharedLibrary;
using System.Threading;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            new Thread(ClientThread).Start();
        }

        private static void ClientThread()
        {
            TcpClient client = new TcpClient("192.168.3.102", 1330);
            bool done = false;
            Console.WriteLine("Type 'bye' to end connection");
            while (!done)
            {
                Console.Write("Enter a message to send to server: ");
                string message = Console.ReadLine();

                ClientServerUtil.WriteTextMessage(client, "client1",message);

                string response = ClientServerUtil.ReadTextMessage(client);
                Console.WriteLine("Response: " + response);
                done = response.Equals("BYE");
            }
        }
    }
}
