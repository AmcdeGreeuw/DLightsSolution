using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WindowsUdpPacket
{
    public partial class WindowsUdp : Form
    {
        Thread t = null;
        bool running = false; 
        long tickreceived = 0;
        ServerListener listener = null;

        public WindowsUdp()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //init
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            startListening();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            stopListening();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            sendMessage();
        }

        private void AddText(string text)
        {
            if (txtReceived.InvokeRequired)
            {
                this.Invoke(new ReceivedText(AddText), new object[] { text });
            }
            else
            {
                txtReceived.AppendText(text);
            }
        }
        private void lblText(string text)
        {
            if (lblreceivedAddres.InvokeRequired)
            {
                this.Invoke(new ReceivedText(lblText), new object[] { text });
            }
            else
            {
                lblreceivedAddres.Text = text;
            }
        }
        private void AddTextWithIp(IPEndPoint ep, string text)
        {

            AddText(text);
            lblText(ep.Address.ToString());

        }
        void startListening()
        {
            if (!running)
            {
                listener = new ServerListener();

                int serverPort = Int32.Parse(txtPort.Text);// 4546;
                listener.ServerPort = serverPort;

                listener.OnReceived = new ReceivedText(AddText);
                listener.OnReceivedFrom = new ReceivedFrom(AddTextWithIp);

                if (!checkBox1.Checked)
                {
                    listener.receiveSocket = new UdpClient(serverPort);
                }
                else
                {
                    listener.tcpListener = new TcpListener(IPAddress.Parse(txtUrl.Text), serverPort);
                }

                //{
                //    if (txtReceived.InvokeRequired)
                //    {
                //        this.Invoke( this.AddText,new object[]{ x});  

                //    }
                //});

                t = new Thread(new ThreadStart(listener.DoWork));
                running = true;
                t.Start();

            }
        }

        void stopListening()
        {
            if (running)
            {
                if (listener.receiveSocket != null)
                {
                    listener.receiveSocket.Close();
                }
                if (listener.tcpListener != null)
                {
                    listener.tcpListener.Stop();
                }
                t.Abort();
                running = false;
                AddText("Stopped");
            }
        }

        void sendMessage()
        {
            Socket sendSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPAddress clientIPAddress = IPAddress.Parse(txtSendAddress.Text); //("127.0.0.1");
            int clientPort = int.Parse(txtSendToPort.Text); // 4568;

            IPEndPoint clientEP = new IPEndPoint(clientIPAddress, clientPort);
            string s = txtToSend.Text;
            byte[] message = Encoding.ASCII.GetBytes(s);
            sendSocket.SendTo(message, clientEP);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            string[] addresses = new string[] { "127.0.0.1", "192.168.253.2" };
            if (txtSendAddress.Text == addresses[0])
            {
                txtSendAddress.Text = addresses[1];
            }
            else
                txtSendAddress.Text = addresses[0];
        }
    }
}
