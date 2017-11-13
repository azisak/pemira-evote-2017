using System;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Text;

namespace PemiraServer {
    
    class SocketClient {
        private TcpClient client;
        private NetworkStream netStream;
        private string host;
        private int port;
        private int MAXBUFF = 1024;
        public SocketClient(string h, int p) {
            host = h;
            port = p;
            client = new TcpClient();
        }

        public void connect() {
            client.Connect(host, port);
            netStream = client.GetStream();
            client.ReceiveBufferSize = MAXBUFF;
        }

        public void send(string s) {
            byte[] outStream = Encoding.ASCII.GetBytes(s);
            netStream.Write(outStream, 0, outStream.Length);
            
        }

        public string recv() {
            byte[] inStream = new byte[MAXBUFF];

            netStream.Read(inStream, 0, client.ReceiveBufferSize);
            string s = "";
            s = Encoding.ASCII.GetString(inStream);

            return s;
        }
    }
}
