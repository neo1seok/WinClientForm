using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WindowRemoteControllerWpf
{
	/// <summary>
	/// MainWindow.xaml에 대한 상호 작용 논리
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		void Debug(string fmt, params object[] args)
		{
			System.Diagnostics.Debug.WriteLine(string.Format(fmt, args));
		}
		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			this.address.Text = "192.168.0.3";

		}

		private void Process_KeyDown(object sender, KeyEventArgs e)
		{
			Debug("KeyDown");
		}

		private void Process_KeyUp(object sender, KeyEventArgs e)
		{
			Debug("KeyUp");
		}

		private void Process_MouseWheel(object sender, MouseWheelEventArgs e)
		{
			Debug("MouseWheel {0}",e.Delta);
		}

		private void Process_MouseUp(object sender, MouseButtonEventArgs e)
		{
			Debug("MouseUp");
		}




		private void Window_KeyDown(object sender, KeyEventArgs e)
		{
			Debug("Window_KeyDown");

			// ... Test for F5 key.
			if (e.Key == Key.F5)
			{
				this.Title = "You pressed F5";
			}
		}




		private void Process_MouseMove(object sender, MouseEventArgs e)
		{
			//Debug("MouseMove");
		}

		private void Process_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			Debug("MouseLeftButtonDown");
		}

		private void Process_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
		{
			Debug("MouseRightButtonDown");
		}

		private void Process_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			Debug("MouseLeftButtonUp");
		}

		private void Process_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
		{
			Debug("MouseRightButtonUp");
		}

		private void Process_MouseDown(object sender, MouseButtonEventArgs e)
		{
			Debug("MouseDown");
		}

		private void Process_Loaded(object sender, RoutedEventArgs e)
		{

		}
		bool isStart = false;

		private void btn_start_Click(object sender, RoutedEventArgs e)
		{
			if (!isStart)
			{
				btn_start.Content = "중지";
				isStart = true;
			}
			else
			{

				btn_start.Content = "시작";
				isStart = false;

			}
				
		}

		private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
		{
			Debug("Window_PreviewKeyDown");

		}

		private void Window_PreviewKeyUp(object sender, KeyEventArgs e)
		{
			Debug("Window_PreviewKeyUp");
		}
		private void Rectangle_PreviewKeyDown(object sender, KeyEventArgs e)
		{
			e.Handled = true;
			Debug("Rectangle_PreviewKeyDown");
		}
		
		
	}
}
