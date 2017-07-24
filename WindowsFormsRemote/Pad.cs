using ClassLibrary4Remote;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsRemote
{
    public partial class Pad : Form
    {
		bool isStart = false;
		IRemote irmote = new ClassRemoteUDP();
       // Remote main;
        Stopwatch sw = new Stopwatch();
        Point lastmove = new Point();
        private int curtick;
        private int repeat;
        UdpClient udpClient;

        public Pad(/*Remote main*/)
        {
            InitializeComponent();
            this.Focus();
           // this.main = main;
            
            
           // textBoxStatus.Hide();
        }

        private void Pad_MouseDown(object sender, MouseEventArgs e)
        {
           // textBoxStatus.Text += "MouseDown\r\n";

        }

        private void Pad_MouseMove(object sender, MouseEventArgs e)
        {

            
          
        }

        private void Pad_MouseUp(object sender, MouseEventArgs e)
        {
           // textBoxStatus.Text += "Pad_MouseUp\r\n";
        }

        private void Pad_KeyDown(object sender, KeyEventArgs e)
        {
           textBoxStatus.Text = "Pad_KeyDown\r\n";
        }

        private void Pad_KeyUp(object sender, KeyEventArgs e)
        {
            textBoxStatus.Text = "Pad_KeyUp\r\n";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Pad_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            textBoxStatus.Text = "Pad_PreviewKeyDown\r\n";
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            return base.ProcessCmdKey(ref msg, keyData);
            //if (keyData == Keys.Up)
            //{
            //    // Handle key at form level.
            //    // Do not send event to focused control by returning true.
            //    textBoxStatus.Text = "ProcessCmdKey key up\r\n";
            //    return true;
            //}
            //if (keyData == Keys.Do)
            //{
            //    // Handle key at form level.
            //    // Do not send event to focused control by returning true.
            //    textBoxStatus.Text = "ProcessCmdKey key down\r\n";
            //    return true;
            //}
            System.Diagnostics.Debug.WriteLine("ProcessCmdKey");
            int vkkey = 0;
            int.TryParse(msg.WParam.ToString(), out vkkey);
			//#textBoxStatus.Text = string.Format("ProcessCmdKey key down {0} ", keyData.ToString());
            irmote.KeyDown(vkkey);
//#SendPost();
//			Thread.Sleep(10);
            irmote.KeyUp(vkkey);
            SendPost();


            return true;
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Pad_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxStatus.Text = "Pad_KeyPress\r\n";
        }
        //void DoInvoke()
        //{
            
        //}

        private void Pad_Load(object sender, EventArgs e)
        {

            //this.timerInvoke.Start();
            this.textBox_ip.Text = "192.168.0.3";

        }


        int index = 0;
        
        void SendPost(bool isForceSend =false)
        {

			while (irmote.IS_INPUTQUE)
			{
				byte[] sndbuff = irmote.InputEventBytes();
				if (sndbuff == null)
				{
					int asd = 0;
				}
				if (!isForceSend && !isStart) continue;


				// string sndbuff = irmote.InputEvent();
				string status = string.Format("irmote.STATUS:{0}", irmote.STATUS);
				textBoxStatus.Text = string.Format("{1} irmote.STATUS:{0}\r\n", irmote.STATUS, index++);
				//SendToServer(sndbuff);
                udpClient.Send(sndbuff, sndbuff.Length);

                System.Diagnostics.Debug.WriteLine(status);
				//this.timerInvoke.Stop();

			}

			
			//this.timerInvoke.Start();
           
          

        }
        private void timerInvoke_Tick(object sender, EventArgs e)
        {
			return;
           // this.timerInvoke.Stop();

           // if (!irmote.IS_INPUTQUE ) return;
           // if(lastmove.X >= 0) irmote.MouseMove(lastmove.X, lastmove.Y);
           // byte[] sndbuff = irmote.InputEventBytes();
           //// string sndbuff = irmote.InputEvent();
           // textBoxStatus.Text += string.Format("{0}\r\n", sndbuff);
           // main.SendToServer(sndbuff);
           // sw.Reset();
           // this.repeat = 0;
         
        }

        private void panel_MouseMove(object sender, MouseEventArgs e)
        {

			//textBoxStatus.Text = string.Format("Pad_MouseMove {0} {1} {2} {3}\r\n", e.X, e.Y, panel.Size.Width, panel.Size.Height);
			//int result = Environment.TickCount & Int32.MaxValue;
			irmote.MouseMove(e.X, e.Y);
            SendPost();
        }

        private void panel_MouseDown(object sender, MouseEventArgs e)
        {
           
            //textBoxStatus.Text = "MouseDown\r\n";
			System.Diagnostics.Debug.WriteLine("MouseDown");
            if(e.Button == MouseButtons.Left)
                irmote.MouseLeftDown(e.X, e.Y);
            else
                irmote.MouseRigthDown(e.X, e.Y);
            SendPost();
        }

        private void panel_MouseUp(object sender, MouseEventArgs e)
        {
			System.Diagnostics.Debug.WriteLine("MouseUp");
            //textBoxStatus.Text = "MouseUp\r\n";
            //irmote.MouseLeftUp(e.X, e.Y);
            if (e.Button == MouseButtons.Left)
                irmote.MouseLeftUp(e.X, e.Y);
            else
                irmote.MouseRightUp(e.X, e.Y);
            SendPost();
        }
        private void pane_MouseWheel(object sender, MouseEventArgs e)
        {
            bool IsReduce = true;

            // 휠을 아래로 내리면
            // 축소(Reduce)가 아닌 확대(Expand) 이므로 false 대입
            if (e.Delta < 0)
            {
                IsReduce = false;
            }
            System.Diagnostics.Debug.WriteLine(string.Format("pane_MouseWheel {0}", e.Delta));

            irmote.MouseWheel(e.Delta);
            SendPost();

            /* 셀의 크기가 셀의 한계 범위 안에 든다면
            * ->  MinCellSize < 셀 사이즈 < MaxCellSize
            * ResizeCellSize함수는 셀의 크기를 1씩 증가 혹은 감소 하고
            * true를 리턴한다.
            * 하지만, 셀 사이즈가 한계 크기와 같다면
            * 셀 크기에는 변동이 없고 false를 리턴
            * 리턴값이 true라면 화면을 다시 그린다.
            */
            //if (MainBoard.ResizeCellSize(IsReduce) == true)
            //{
            //    // 가로, 세로 셀의 개수를 다시 계산
            //    MainBoard.CalcCellNum();
            //    // 메인보드 다시 그림
            //    this.Invalidate();
            //}
        }

        private void button_toggle_Click(object sender, EventArgs e)
		{
			if (!isStart)
			{
                udpClient = new UdpClient();
                udpClient.Connect(textBox_ip.Text, 5510);

                isStart = true;
				irmote.SetSize(panel.Size.Width, panel.Size.Height);
				SendPost();
           
                this.button_toggle.Text = "정지";
			}
			else
			{
				isStart = false;
				this.button_toggle.Text = "시작";

			}
			
		}

		private void btn_center_Click(object sender, EventArgs e)
		{
            udpClient = new UdpClient();
            udpClient.Connect(textBox_ip.Text, 5510);
            irmote.SetSize(panel.Size.Width, panel.Size.Height);
            irmote.MouseMove(panel.Size.Width/2, panel.Size.Height/2);
            SendPost(true);
            //byte[] sndbuff = irmote.InputEventBytes();
            //    // string sndbuff = irmote.InputEvent();
            //string status = string.Format("irmote.STATUS:{0}", irmote.STATUS);
            //textBoxStatus.Text = string.Format("irmote.STATUS:{0}\r\n", irmote.STATUS);
            //SendToServer(sndbuff);
        }

        private void Pad_Scroll(object sender, ScrollEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Pad_Scroll");
        }

        private void panel_SizeChanged(object sender, EventArgs e)
        {
            irmote.SetSize(panel.Size.Width, panel.Size.Height);
            SendPost();
            System.Diagnostics.Debug.WriteLine("panel_SizeChanged");

        }
        //public void SendToServer(byte[] buffer)
        //{
          
        //    //lock (obj)
        //    {
        //        //tcpHandler.Send(msg);
        //    }
        //    this.Invoke((MethodInvoker)delegate {


        //        //return;
        //        //byte[] message = Encoding.UTF8.GetBytes(msg);

        //        //client.BeginSend(message, 0, message.Length, SocketFlags.None,
        //        //             new AsyncCallback(SendData), client);
        //        //this.Invoke((MethodInvoker)delegate
        //        //{
        //        //    conStatus.Text = "Sendig : " + msg;
        //        //});
        //    });

        //}

        private void panel_KeyDown(object sender, KeyEventArgs e)
        {
            irmote.KeyDown(e.KeyValue);
            SendPost();
            System.Diagnostics.Debug.WriteLine("panel_KeyDown {0} {1:X}", e.KeyCode, e.KeyValue);
         

        }

        private void panel_KeyUp(object sender, KeyEventArgs e)
        {
        
            irmote.KeyUp(e.KeyValue);
            SendPost();
            System.Diagnostics.Debug.WriteLine("panel_KeyUp {0} {1:X}", e.KeyCode, e.KeyValue);
        }

        private void panel_KeyPress(object sender, KeyPressEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("panel_KeyPress {0}", e.KeyChar);

        }
        //protected override bool IsInputKey(Keys keyData)
        //{
        //    if (keyData == Keys.Right)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return base.IsInputKey(keyData);
        //    }
        //}
    }
}
