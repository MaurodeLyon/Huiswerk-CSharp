using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationLibrary
{
    public class Communication
    {   /*
        //simple writeline and readline
        public static void WriteTextMessage(TcpClient client, string message)
        {
            var stream = new StreamWriter(client.GetStream(), Encoding.Unicode);
            string joined = string.Join("|", message);
            stream.WriteLine(joined);
            stream.Flush();
        }
        */
        public static void WriteTextMessage(TcpClient client, string message)
        {
            StreamWriter stream = new StreamWriter(client.GetStream(), Encoding.Unicode);
            stream.WriteLine(message);
            stream.Flush();
        }

        public static string ReadTextMessage(TcpClient client)
        {
            StreamReader stream = new StreamReader(client.GetStream(), Encoding.Unicode);
            return stream.ReadLine();
        }
        /*
        //byte streaming
        public static void SendMessage(TcpClient client, string message)
        {
            client.GetStream().Write(Encoding.Unicode.GetBytes(message), 0, Encoding.Unicode.GetBytes(message).Length);
        }
        //read incoming message
        public static string ReadMessage(TcpClient client)
        {
            byte[] buffer = new byte[256];
            int totalRead = 0;
            do { totalRead += client.GetStream().Read(buffer, totalRead, buffer.Length - totalRead); }
            while (client.GetStream().DataAvailable);
            return Encoding.Unicode.GetString(buffer, 0, totalRead);
        }
        */
    }
}
