using CommunicationLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameClient
{
    class Program
    {
        static void Main(string[] args)
        {
            new Thread(ClientThread).Start();
        }

        private static void ClientThread()
        {
            TcpClient client = new TcpClient("145.48.226.96", 1330);
            bool done = false;
            Console.WriteLine("Type 'bye' to end connection");
            while (!done)
            {
                Console.Write("Enter a message to send to server: ");
                string message = Console.ReadLine();

                Communication.WriteTextMessage(client, message);

                string response = Communication.ReadTextMessage(client);
                Console.WriteLine("Response: " + response);
                done = response.Equals("BYE");
            }
        }
    }
}
