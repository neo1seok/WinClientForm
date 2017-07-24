using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsRemote
{
    public partial class Remote : Form
    {

        private Socket client;
        
        private byte[] data = new byte[1024];
        private int size = 1024;
        Pad pad ;
        //TcpClientHandler tcpHandler;
        TcpClient tcpclient;
        UdpClient udpClient;
        IAsyncResult asyncRes;
        Action<string> work;
        object obj = new object();

        public Remote()
        {
            InitializeComponent();
            //tcpHandler = new TcpClientHandler();
            //tcpHandler.SetStateFuncion(cbstatu);
            
            work = ShowDlg;
      
        }

  

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            // tcpHandler.Connect(textBox_ip.Text,5510);
            udpClient = new UdpClient();
            udpClient.Connect(textBox_ip.Text, 5510);
            conStatus.Text = "Connected";
            asyncRes = work.BeginInvoke("", null, null);
            //return;
            //conStatus.Text = "Connecting...";
            //Socket newsock = new Socket(AddressFamily.InterNetwork,
            //                      SocketType.Stream, ProtocolType.Tcp);

            //IPEndPoint iep = new IPEndPoint(IPAddress.Parse(textBox_ip.Text), 5510);
            //newsock.BeginConnect(iep, new AsyncCallback(Connected), newsock);


        }
     
        public void SendToServer(byte[] buffer)
        {
            udpClient.Send(buffer, buffer.Length);
            //lock (obj)
            {
                //tcpHandler.Send(msg);
            }
            this.Invoke((MethodInvoker)delegate {
                

                //return;
                //byte[] message = Encoding.UTF8.GetBytes(msg);
                
                //client.BeginSend(message, 0, message.Length, SocketFlags.None,
                //             new AsyncCallback(SendData), client);
                //this.Invoke((MethodInvoker)delegate
                //{
                //    conStatus.Text = "Sendig : " + msg;
                //});
            });
         
        }
        void cbstatu(string state, string msg)
        {
            this.Invoke((MethodInvoker)delegate
            {
                conStatus.Text = string.Format("{0} :{1}", state, msg);
            });

            switch (state)
            {
                case "connected":
                   
                    

                    // 델리게이트객체로부터 BeginInvoke() 실행
                    // 두 개의 입력 파라미터 10, 20 지정
                    asyncRes = work.BeginInvoke("", null, null);

                    Console.WriteLine("Do something in Main thread");

                    // 델리게이트객체로부터 EndInvoke(IAsyncResult) 실행
                    // EndInvoke는 쓰레드가 완료되길 기다린다.
                    // 완료후 리턴 값을 돌려받는다.            
                    

                    //Console.WriteLine("Result: {0}", result);
                    break;
                case "received":
                    break;

            }
        }
        void ShowDlg(string msg)
        {
            pad.ShowDialog();
            work.EndInvoke(asyncRes);

        }

        void ButtonDisconOnClick(object obj, EventArgs ea)
        {
            client.Close();
            conStatus.Text = "Disconnected";
        }
#if false
              private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Remote_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void Remote_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void Remote_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void Remote_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Remote_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Remote_KeyUp(object sender, KeyEventArgs e)
        {

        }
        void Connected(IAsyncResult iar)
        {
            client = (Socket)iar.AsyncState;
            try
            {
                client.EndConnect(iar);
                this.Invoke((MethodInvoker)delegate
                {
                    conStatus.Text = "Connected to: " + client.RemoteEndPoint.ToString();
                });
                
                pad.ShowDialog();
                //client.BeginReceive(data, 0, size, SocketFlags.None,
                //              new AsyncCallback(ReceiveData), client);
            }
            catch (SocketException)
            {
                conStatus.Text = "Error connecting";
            }
        }

        void ReceiveData(IAsyncResult iar)
        {
            Socket remote = (Socket)iar.AsyncState;
            int recv = remote.EndReceive(iar);
            string stringData = Encoding.ASCII.GetString(data, 0, recv);
            this.Invoke((MethodInvoker)delegate
            {
                results.Items.Add(stringData);
            });
           
        }


        void SendData(IAsyncResult iar)
        {
            Socket remote = (Socket)iar.AsyncState;
            int sent = remote.EndSend(iar);
            remote.BeginReceive(data, 0, size, SocketFlags.None,
                          new AsyncCallback(ReceiveData), remote);
        }

#endif
        private void Remote_Load(object sender, EventArgs e)
        {
            pad = new Pad();
            this.textBox_ip.Text = "192.168.0.3";
            //this.textBox_ip.Text = "localhost";

        }

        private void Remote_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                udpClient.Close();
                //tcpHandler.ResetSetStateFuncion();
                //tcpHandler.Close();
            }
            catch (Exception)
            {

               
            }
        }
    }
}
