using CommunicationLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameServer
{
    class Server
    {
        private int amount_of_clients = 0;
        private List<TcpClient> tcpClients = new List<TcpClient>();
        public Server()
        {
            IPAddress localhost;
            IPAddress.TryParse("192.168.3.102", out localhost);
            TcpListener listener = new System.Net.Sockets.TcpListener(localhost, 1330);

            // Starts listening for incoming connection requests in the listener-thread:
            listener.Start();
            //get 2 players
            bool done = false;
            while (!done)
            {
                Console.WriteLine("Waiting for connection");
                TcpClient client = listener.AcceptTcpClient();  //wait and accept connection
                Console.WriteLine("Accept Connection");
                new Thread(HandleClientThread).Start(client); ; //handle connection in new thread
                amount_of_clients++;
                tcpClients.Add(client);
                Console.WriteLine("Client " + amount_of_clients + " connected");
                if (amount_of_clients == 2)
                {
                    Console.WriteLine("second client received");
                    done = true;
                    new Thread(StartGame).Start();
                }
            }

        }

        private void HandleClientThread(object obj)
        {
            TcpClient client = obj as TcpClient;
            bool done = false;
            while (!done)
            {
                string received = Communication.ReadTextMessage(client);
            }
            client.Close();
        }

        private void StartGame()
        {
            while (true)
            {


                Random random = new Random();
                int random_1 = random.Next(100);
                int random_2 = random.Next(100);
                int answer = 0;
                string question = "";

                switch (random.Next(4))
                {
                    //optellen
                    case 1:
                        answer = random_1 + random_2;
                        question = $"{random_1} + {random_2} = ?";
                        break;
                    //aftrekken
                    case 2:
                        answer = random_1 - random_2;
                        question = $"{random_1} - {random_2} = ?";
                        break;
                    //vermenigvuldigen
                    case 3:
                        answer = random_1 * random_2;
                        question = $"{random_1} * {random_2} = ?";
                        break;
                    //delen
                    case 4:
                        answer = random_1 / random_2;
                        question = $"{random_1} / {random_2} = ?";
                        break;
                }
                Console.WriteLine($"question is {question} and the anwer is {answer}.");

                foreach (TcpClient tcp in tcpClients)
                {
                    Communication.WriteTextMessage(tcp, question);
                    string response = Communication.ReadTextMessage(tcp);
                    int responseInt;
                    Int32.TryParse(response, out responseInt);
                    if (responseInt == answer)
                    {
                        Communication.WriteTextMessage(tcp, "Correct");
                        //next question
                    }
                }
            }
        }
    }
}
