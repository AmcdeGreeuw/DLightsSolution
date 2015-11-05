using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace WindowsUdpPacket
{


    public delegate void ReceivedText(string text);
    public delegate void ReceivedFrom(IPEndPoint ipendpoint, string text);

    public class ServerListener
    {


        public UdpClient receiveSocket = null;
        public TcpListener tcpListener = null;

        NetworkStream ns = null;

        public int ServerPort { get; set; }
        public ReceivedText OnReceived { get; set; }
        public ReceivedFrom OnReceivedFrom { get; set; }

        void OnReceivedFromHandler(IPEndPoint ipendpoint, string text)
        {
            if (OnReceivedFrom != null)
                OnReceivedFrom(ipendpoint, text);
        }

        void OnReceivedHandler(string msg)
        {
            if (this.OnReceived != null)
                OnReceived(msg);
        }

        

        public void DoWork()
        {            
            IPEndPoint clientEP = new IPEndPoint(IPAddress.Any, ServerPort);

            while (true)
            {
                Console.Write("Waiting for message: ");
                OnReceivedHandler("Listening on port:" + ServerPort.ToString());  
                
                byte[] bytes = new byte[4096];
                
                try
                {
                    if (receiveSocket != null)
                    {
                        bytes = receiveSocket.Receive(ref clientEP);
                        string received = Encoding.ASCII.GetString(bytes, 0, bytes.Length);
                        OnReceivedFromHandler(clientEP, received);
                        OnReceivedHandler(received);

                    }
                    else
                    {
                        tcpListener.Start();
                        TcpClient client = tcpListener.AcceptTcpClient();
                        HttpHandler httpHandler = new HttpHandler(client, this);
                        httpHandler.OnReceived = this.OnReceived;
                        httpHandler.body = "<html><head><title>custom response</title></head><body><b>sooooo</b></body></html>";
                        Thread thread = new Thread(new ThreadStart(httpHandler.Process));
                        thread.Start();
                        Thread.Sleep(1);  
                        //ns = client.GetStream();
                        //while((bytesRead = ns.Read(bytes, 0, bytes.Length)) > 0)
                        //{
                        //    OnReceivedHandler(Encoding.ASCII.GetString(bytes, 0, bytes.Length));
                        //}
                        //if (ns.CanWrite)
                        //{
                        //    string body = 
                        //    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(ns))
                        //    {
                        //        sw.Write(DefaultResponse(body.Length));
                        //        sw.WriteLine(body);  
                        //        sw.Flush(); 
                        //    }
                        //}
                        //client.Close(); 
                    }
                }
                catch (Exception ex)
                {
                    Console.Write("Exception.message: " + ex.Message);
                    //throw;
                }

                //receiveSocket.Send(bytes, bytes.Length);    
            }
        }

 
        string DefaultResponse(int length)
        {
            System.Text.StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}\r\n", "HTTP/1.1 200 OK" );
            sb.AppendFormat("{0}\r\n", "Content-Type: text/html; charset=utf-8");
            sb.AppendFormat("{0}\r\n", "Connection: close");
            sb.AppendFormat("{0}: {1}\r\n", "Content-Length", length);


            sb.Append("\r\n");
            return sb.ToString(); 
        }

    }
}
