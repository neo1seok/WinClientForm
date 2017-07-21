using ClassLibrary4Remote;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
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
        Remote main;
        Stopwatch sw = new Stopwatch();
        Point lastmove = new Point();
        private int curtick;
        private int repeat;

        public Pad(Remote main)
        {
            InitializeComponent();
            this.Focus();
            this.main = main;
            
            
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
			
        }
        void SendPost()
        {
			while (irmote.IS_INPUTQUE)
			{
				byte[] sndbuff = irmote.InputEventBytes();
				if (sndbuff == null)
				{
					int asd = 0;
				}
				if (!isStart) continue;


				// string sndbuff = irmote.InputEvent();
				string status = string.Format("irmote.STATUS:{0}", irmote.STATUS);
				textBoxStatus.Text = string.Format("irmote.STATUS:{0}\r\n", irmote.STATUS);
				main.SendToServer(sndbuff);

				System.Diagnostics.Debug.WriteLine(status);
				//this.timerInvoke.Stop();

			}

			
			//this.timerInvoke.Start();
           
          

        }
        private void timerInvoke_Tick(object sender, EventArgs e)
        {
			return;
            this.timerInvoke.Stop();

            if (!irmote.IS_INPUTQUE ) return;
            if(lastmove.X >= 0) irmote.MouseMove(lastmove.X, lastmove.Y);
            byte[] sndbuff = irmote.InputEventBytes();
           // string sndbuff = irmote.InputEvent();
            textBoxStatus.Text += string.Format("{0}\r\n", sndbuff);
            main.SendToServer(sndbuff);
            sw.Reset();
            this.repeat = 0;
         
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

		private void button_toggle_Click(object sender, EventArgs e)
		{
			if (!isStart)
			{
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
			irmote.MouseMove(panel.Size.Width/2, panel.Size.Height/2);
			SendPost();
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
