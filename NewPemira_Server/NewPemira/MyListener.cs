using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NewPemira
{
    class MyListener
    {
        private IPAddress myIpAd;
        private int myPort;
        TcpListener myList;
        bool isOK;
        Socket mySocket;

        public MyListener(string _ipAd, int _port)
        {
            isOK = false;
            myIpAd = IPAddress.Parse(_ipAd);
            myPort = _port;
            myList = new TcpListener(myIpAd, myPort);
        }
        
        public bool checkOK()
        {
            return isOK;
        }

        public bool startServer()
        {
            try
            {
                myList.Start();
                Console.WriteLine("The server is running at port ." + myPort + " ..");
                Console.WriteLine("The local End point is  :" + myList.LocalEndpoint);
                Console.WriteLine("Waiting for a connection.....");

                mySocket = myList.AcceptSocket();
                Console.WriteLine("Connection accepted from " + mySocket.RemoteEndPoint);
                isOK = true;
            } catch (Exception ex) {
                isOK = false;
                Console.WriteLine("Error : " + ex.StackTrace);
            }
            return isOK;
        }

        public void sendMsg(string msg)
        {
            if (isOK)
            {
                try
                {
                    ASCIIEncoding asen = new ASCIIEncoding();
                    mySocket.Send(asen.GetBytes(msg));
                    Console.WriteLine("\nSent Acknowledgement");
                } catch (Exception ex)
                {
                    isOK = false;
                    Console.WriteLine("Error : " + ex.StackTrace);
                }
            } else
            {
                Console.WriteLine("Can't connect to end point");
            }
        }

        // Blocking method
        public string getMsg()
        {
            string msg = "ERROR";
            try
            {
                byte[] b = new byte[100];
                int k = mySocket.Receive(b);
                Console.WriteLine("Recieved...");
                msg = "";
                for (int i = 0; i < k; i++)
                    msg += Convert.ToChar(b[i]);
            }
            catch (Exception ex)
            {
                isOK = false;
                Console.WriteLine("Error : " + ex.StackTrace);
            }
            
            return msg;
        }
        


    }
}
