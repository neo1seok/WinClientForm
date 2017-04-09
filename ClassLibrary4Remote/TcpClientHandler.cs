using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsFormsRemote
{
    public delegate void DEBUG(string fmt, params object[] args);
    public delegate void CBACK(string state, string msg);

    public class TcpClientHandler
    {
        TcpClient client;
        private int port;
        private string server;
        NetworkStream stream;
        Thread thread;
        DEBUG debug;
        CBACK cbstate;
        Queue<string> quemsg = new Queue<string>();
        object obj = new object();
        public  TcpClientHandler()
        {
    
            
            debug = defDebug;
            cbstate = defcbfunction;
        }
        void defcbfunction(string start, string msg)
        {

        }
        public void Connect(String server, int port)
        {
            this.server = server;
            this.port = port;
            thread = new Thread(new ThreadStart(work));
            thread.Start();




        }

        public void Close()
        {
            // Close everything.
            stream.Close();
            client.Close();
            thread.Join();

        }
        void defDebug(string fmt,params object[]args)
        {
            Console.WriteLine(fmt, args);

        }

        public void Send(string message)
        {
            lock (obj)
                quemsg.Enqueue(message);
            //lock (obj)
            //{
            //    try
            //    {
            //        // Translate the passed message into ASCII and store it as a Byte array.
            //        Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
            //        // Send the message to the connected TcpServer. 
            //        Console.WriteLine("Sent: {0}", message);
            //        stream.Write(data, 0, data.Length);
            //    }
            //    catch (ArgumentNullException e)
            //    {
            //        Console.WriteLine("ArgumentNullException: {0}", e);
            //    }
            //    catch (SocketException e)
            //    {
            //        Console.WriteLine("SocketException: {0}", e);
            //    }
            //    catch (Exception e)
            //    {
            //        Console.WriteLine("Exception: {0}", e);
            //    }



            //}

        }

        public void SetStateFuncion(CBACK cbstate)
        {
            this.cbstate = cbstate;
        }
        public void ResetSetStateFuncion()
        {
            this.cbstate = defcbfunction;
        }
        void work()
        {
            Byte[] data = new Byte[2048];
            try
            {
                cbstate("connecting", "");
                debug("connecting to {0} ({1})", server, port);
                client = new TcpClient(server, port);
                stream = client.GetStream();
               // stream.ReadTimeout = 10000;

                debug("connected");
                cbstate("connected", "");
                debug("waiting....");
                while (client.Connected)
                {
                   

                    // String to store the response ASCII representation.
                    String responseData = String.Empty;
                   
                    // Read the first batch of the TcpServer response bytes.
                    
                    // if (!stream.CanRead) continue;
                    Int32 bytes = 0;
                    string message = "";
                    int quesize = 0;
                    lock (obj)
                    {
                        if (quemsg.Count == 0)
                        {
                            Thread.Sleep(100);
                            continue;
                        }
                        quesize = quemsg.Count;
                        message = quemsg.Dequeue();;
                        //message =  string.Join("", quemsg.ToList());
                        //quemsg.Clear();




                    }
                    // Send the message to the connected TcpServer. 
                    Console.WriteLine("Sent: {0}", message);
                    Byte[] snddata = System.Text.Encoding.UTF8.GetBytes(message);
                    stream.Write(snddata, 0, snddata.Length);
                    cbstate("sent","");
                    bytes = stream.Read(data, 0, data.Length);

                    debug("received");
                    responseData = System.Text.Encoding.UTF8.GetString(data, 0, bytes);
                    Console.WriteLine("Received: {0}", responseData);
                     cbstate("received", responseData);
                    debug("waiting....");

                }
             




            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e);
            }
            finally
            {
                cbstate("disconnected","");
            }

        }

  
    }

    
}
