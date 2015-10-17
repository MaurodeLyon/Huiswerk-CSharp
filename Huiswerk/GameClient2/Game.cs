using CommunicationLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameClient2
{
    class Game
    {
        public Game()
        {
            new Thread(ClientThread).Start();
        }
        private static void ClientThread()
        {
            TcpClient client = new TcpClient("192.168.3.102", 1330);
            bool done = false;
            while (!done)
            {
                string response = Communication.ReadTextMessage(client);//response from server
                Console.WriteLine(response);                            //write response in console
                string message = Console.ReadLine();                    //read line from console
                Communication.WriteTextMessage(client, message);        //send text to server
            }
        }
    }
}