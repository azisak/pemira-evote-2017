using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PemiraClient
{
    class ConnectionManager
    {
        private int MAX_RECV_BUFFER = 100;

        private TcpClient client;
        private Stream clientStream;

        public ConnectionManager(string ipAddr, int port)
        {
            Console.WriteLine("Connecting to " + ipAddr + ":" + port);
            client = new TcpClient();
            client.Connect(ipAddr, port);
            Console.WriteLine("Connected.");

            try
            {
                clientStream = client.GetStream();
            } catch(IOException exp)
            {}
        }

        public bool send(string msg)
        {
            clientStream.Write(Encoding.ASCII.GetBytes(msg), 0, msg.Length);
            return true;
        }

        public string recv()
        {
            byte[] msgBytes = new byte[MAX_RECV_BUFFER];
            clientStream.Read(msgBytes, 0, MAX_RECV_BUFFER);
            Console.WriteLine("NIM : " + System.Text.Encoding.ASCII.GetString(msgBytes));
            return System.Text.Encoding.ASCII.GetString(msgBytes);
        }
    }
}
