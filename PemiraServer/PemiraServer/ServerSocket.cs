using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;

namespace PemiraServer
{
    class ServerSocket {
        private TcpClient client;
        private NetworkStream netStream;
        private string host;
        private int port;
        private int MAXBUFF = 1024;
        public ServerSocket(string h, int p) {
            host = h;
            port = p;
        }

        public void connect() {
            client = new TcpClient();
            client.Connect(host, port);
            netStream = client.GetStream();
            client.ReceiveBufferSize = MAXBUFF;
           
        }

        public void disconnect() {
            netStream.Close(1);
            
            client.Close();
        }

        public void send(string s) {
            try {
                Debug.WriteLine("Send: " + s);
                byte[] outStream = Encoding.ASCII.GetBytes(s);
                netStream.Write(outStream, 0, outStream.Length);
            } catch (NullReferenceException e) {
                MessageBox.Show("Client is not connected!");
            }
        }

        public string recv() {
            string s = "";
            if (client.Connected) {
                byte[] inStream = new byte[MAXBUFF];

                int bytesRead = netStream.Read(inStream, 0, client.ReceiveBufferSize);
                s = Encoding.ASCII.GetString(inStream, 0, bytesRead);
            }
            //            Debug.WriteLine(s.Length);
            Debug.WriteLine("Recv: " + s);
            return s;
        }
    }
}
