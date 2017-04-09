using ClassLibrary4Remote;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsRemote;

namespace ConsoleApplication
{
    class Program
    {

        static string list_test_kbd = "[{\"values\": [\"ctrl\", \"down\"], \"cmd\": \"kbd_event\"}, {\"values\": [\"a\", \"down\"], \"cmd\": \"kbd_event\"}, {\"values\": [\"a\", \"up\"], \"cmd\": \"kbd_event\"}, {\"values\": [\"ctrl\", \"up\"], \"cmd\": \"kbd_event\"}]";
        static void Connect(String server, String message)
        {
            try
            {
                // Create a TcpClient.
                // Note, for this client to work you need to have a TcpServer 
                // connected to the same address as specified by the server, port
                // combination.
                Int32 port = 5510;
                TcpClient client = new TcpClient(server, port);

                // Translate the passed message into ASCII and store it as a Byte array.
                Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);

                // Get a client stream for reading and writing.
                //  Stream stream = client.GetStream();

                NetworkStream stream = client.GetStream();

                // Send the message to the connected TcpServer. 
                stream.Write(data, 0, data.Length);

                Console.WriteLine("Sent: {0}", message);

                // Receive the TcpServer.response.

                // Buffer to store the response bytes.
                data = new Byte[256];

                // String to store the response ASCII representation.
                String responseData = String.Empty;

                // Read the first batch of the TcpServer response bytes.
                Int32 bytes = stream.Read(data, 0, data.Length);
                responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                Console.WriteLine("Received: {0}", responseData);

                // Close everything.
                stream.Close();
                client.Close();
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }

            Console.WriteLine("\n Press Enter to continue...");
            Console.Read();
        }
        static void Main(string[] args)
        {
            var classRemote = new ClassRemote();
            classRemote.KeyDown(0x41);
            classRemote.KeyUp(0x41);

            classRemote.SetSize(100,100);

            int x = 10;
            int y = 10;

            for(int i = 0; i < 10; i++)
            {
                x++;
                classRemote.MouseMove(x, y);
            }

            for (int i = 0; i < 10; i++)
            {
                y++;
                classRemote.MouseMove(x, y);
            }
            classRemote.KeyDown(0x41);
            classRemote.KeyUp(0x41);
            classRemote.MouseRigthDown(x,y);
            classRemote.MouseRightUp(x,y);

            // var tcphandler = new TcpClientHandler("192.168.0.3",5510);
            var tcphandler = new TcpClientHandler();
            tcphandler.Connect("192.168.0.3", 5510);
            //tcphandler.Connect("localhost", 5510);
            //var fdsadf = 
            //    new ClassRemotePacket()
            //{
            //    cmd = "kbd_event",
            //    values = new List<object>() { 2,3}

            //};
            //var fdsa  = JsonConvert.SerializeObject(fdsadf);
            var fdsfdafs = classRemote.InputEvent();
            Console.WriteLine(fdsfdafs);
           
            while (true)
            {
                Console.WriteLine("any key");
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.Q) break;
                tcphandler.Send(fdsfdafs);

            }
        
    
            tcphandler.Close();

        }
    }
}
