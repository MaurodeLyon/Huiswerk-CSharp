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
        private List<Client> clients = new List<Client>();
        public Server()
        {

            // Starts listening for incoming connection requests in the listener-thread:
            IPAddress localhost;
            IPAddress.TryParse("192.168.3.102", out localhost);
            TcpListener listener = new System.Net.Sockets.TcpListener(localhost, 1330);
            listener.Start();

            //accept 2 players
            bool done = false;
            while (!done)
            {
                Console.WriteLine("Waiting for connection");
                TcpClient client = listener.AcceptTcpClient();  //wait and accept connection

                Console.WriteLine("Accept Connection");
                new Thread(HandleClientThread).Start(client); ; //handle connection in new thread
                amount_of_clients++;
                clients.Add(new Client(client, 0));
                Console.WriteLine("Client " + amount_of_clients + " connected");
                if (amount_of_clients == 2)
                {
                    Console.WriteLine("second client received");
                    done = true;
                    new Thread(StartGame).Start();              //start game and stop receiving
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

        private string question;
        private int answer;
        private void getNewQuestion()
        {
            Random random = new Random();
            int random_1 = random.Next(100);
            int random_2 = random.Next(100);
            answer = 0;
            question = "";
            switch (random.Next(4))
            {
                //optellen
                case 0:
                    answer = random_1 + random_2;
                    question = $"{random_1} + {random_2} = ?";
                    break;
                //aftrekken
                case 1:
                    answer = random_1 - random_2;
                    question = $"{random_1} - {random_2} = ?";
                    break;
                //vermenigvuldigen
                case 2:
                    answer = random_1 * random_2;
                    question = $"{random_1} * {random_2} = ?";
                    break;
                //delen
                case 3:
                    do
                    {
                        random_1 = random.Next(100);
                        random_2 = random.Next(1, 100);

                        answer = random_1 / random_2;
                        question = $"{random_1} / {random_2} = ?";
                    } while (!(random_1 % random_2 == 0));
                    break;
            }
        }

        private string response;
        private bool need_new_answer = true;
        private void StartGame()
        {
            while (true)
            {
                if (need_new_answer)
                    getNewQuestion();
                Console.WriteLine($"question is {question} and the anwer is {answer}.");

                foreach (Client client in clients)
                {
                    Communication.WriteTextMessage(client.tcp, question);
                    client.receive = new Thread(() => getResponse(client));
                    client.receive.Start();
                }
                response = "";
                while (response == "") ;
                Console.WriteLine($"the score is player1 = {clients[0].score} and player2 = {clients[1].score}.");
            }
        }

        private void getResponse(Client client)
        {
            response = Communication.ReadTextMessage(client.tcp);
            int result;
            Int32.TryParse(response, out result);
            if (answer == result)
            {
                client.score++;
                need_new_answer = true;
            }
            else
            {
                need_new_answer = false;
            }
        }
    }

    class Client
    {
        public TcpClient tcp;
        public int score;
        public Thread receive;

        public Client(TcpClient tcp, int score)
        {
            this.tcp = tcp;
            this.score = score;
        }
    }
}

