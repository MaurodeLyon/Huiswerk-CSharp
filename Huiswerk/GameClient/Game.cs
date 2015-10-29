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
    class Game
    {
        public Game()
        {
            new Thread(ClientThread).Start();
        }
        private TcpClient client;
        private void ClientThread()
        {
            client = new TcpClient("192.168.3.102", 1330);
            new Thread(responses).Start();
            new Thread(answers).Start();
        }

        private void answers()
        {
            while (true)
            {
                string answer = Console.ReadLine();
                Communication.WriteTextMessage(client, answer);
            }
        }

        private void responses()
        {
            while (true)
            {
                string response = Communication.ReadTextMessage(client);
                Console.WriteLine(response);
            }
        }
    }
}