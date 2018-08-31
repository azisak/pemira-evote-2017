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
        private int MAX_RECV_BUFFER = 8;

        private TcpClient client;
        private Stream clientStream;
        private string ipAddr;
        private int port;

        public ConnectionManager(string ipAddr, int port)
        {
            this.ipAddr = ipAddr;
            this.port = port;

            createConnection();
        }

        private void createConnection()
        {
            Console.WriteLine("Connecting to " + ipAddr + ":" + port);
            client = new TcpClient();

            bool notConnected = true;
            while (notConnected)
            {
                try
                {
                    client.Connect(ipAddr, port);
                    Console.WriteLine("Connected.");
                    notConnected = false;
                }
                catch (SocketException exp)
                {
                    Console.WriteLine("Unable to connect.");
                }
            }

            try
            {
                clientStream = client.GetStream();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        } 

        public bool send(string msg)
        {
            try
            {
                clientStream.Write(Encoding.ASCII.GetBytes(msg), 0, msg.Length);
                return true;
            } catch(Exception e)
            {
                return false;
            }
        }

        public ReceiveResponse recv()
        {
            byte[] msgBytes = new byte[MAX_RECV_BUFFER];
            try
            {
                clientStream.Read(msgBytes, 0, MAX_RECV_BUFFER);
                Console.WriteLine("NIM : " + System.Text.Encoding.ASCII.GetString(msgBytes));
                return new ReceiveResponse(true, System.Text.Encoding.ASCII.GetString(msgBytes));
            } catch(Exception e)
            {
                createConnection();
                return new ReceiveResponse(false, "");
            }
        }

        public void cancel()
        {
            client.Close();
        }

    }
}
