using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace ServerWFApp
{
    public partial class Form1 : Form
    {
        public static TcpListener server = new TcpListener(IPAddress.Parse("192.168.1.9"), 90); //Cihazın IPv4 adresi
        public static Socket sck;
        public static List<Socket> sckList = new List<Socket>();
        public static string x, y;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                server.Start();
                MessageBox.Show("Server Başlatıldı");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata : " + ex.Message);
            }
            
            Thread thread1 = new Thread(new ThreadStart(ThreadFuncClientListener));
            Thread thread2 = new Thread(new ThreadStart(ThreadFuncClientHave));
            Thread thread3 = new Thread(() => ThreadFuncEventListener());
            thread3.SetApartmentState(ApartmentState.STA);

            thread1.Start();
            thread2.Start();
            thread3.Start();
        }

        static void ThreadFuncClientListener()
        {
            while (true)
            {
                if (server.Pending())
                {
                    sck = server.AcceptSocket();
                    if (sck.Connected)
                    {
                        sckList.Add(sck);
                        Console.WriteLine("Sunucuya bir Client bağlandı.");

                        for (int i = 0; i < sckList.Count; i++)
                        {
                            NetworkStream ns = new NetworkStream(sckList[i]);
                            StreamWriter sw = new StreamWriter(ns);
                            
                            x = MousePosition.X.ToString();
                            y = MousePosition.Y.ToString();

                            sw.WriteLine(x + " " + y);
                            sw.Flush();

                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(0.01));

                            ns.Close();
                            sw.Close();
                        }
                    }
                }
                else
                    Thread.Sleep(1000);
            }
        }

        private void btnBoyut_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Screen.PrimaryScreen.Bounds.Width.ToString() + " x " +
                Screen.PrimaryScreen.Bounds.Height.ToString());
        }

        static void ThreadFuncClientHave()
        {
            while (true)
            {
                if (sck != null)
                {
                    for (int i = 0; i < sckList.Count; i++)
                    {
                        NetworkStream ns = new NetworkStream(sckList[i]);
                        StreamWriter sw = new StreamWriter(ns);
                        
                        x = MousePosition.X.ToString();
                        y = MousePosition.Y.ToString();

                        sw.WriteLine(x + " " + y);
                        sw.Flush();

                        System.Threading.Thread.Sleep(TimeSpan.FromSeconds(0.01));

                        ns.Close();
                        sw.Close();
                    }
                }
            }
        }

        internal static void ThreadFuncEventListener()
        {
            while (true)
            {
                if(sck != null)
                {
                    if ((Control.MouseButtons & MouseButtons.Left) == MouseButtons.Left)
                    {
                        for (int i = 0; i < sckList.Count; i++)
                        {
                            NetworkStream ns = new NetworkStream(sckList[i]);
                            StreamWriter sw = new StreamWriter(ns);

                            x = MousePosition.X.ToString();
                            y = MousePosition.Y.ToString();

                            sw.WriteLine(x + " " + y + " " + "leftClick");
                            sw.Flush();

                            ns.Close();
                            sw.Close();
                        }
                    }
                    else if ((Control.MouseButtons & MouseButtons.Right) == MouseButtons.Right)
                    {
                        for (int i = 0; i < sckList.Count; i++)
                        {
                            NetworkStream ns = new NetworkStream(sckList[i]);
                            StreamWriter sw = new StreamWriter(ns);

                            x = MousePosition.X.ToString();
                            y = MousePosition.Y.ToString();

                            sw.WriteLine(x + " " + y + " " + "rightClick");
                            sw.Flush();

                            ns.Close();
                            sw.Close();
                        }
                    }
                }
                Thread.Sleep(80);
            }
        }
    }
}
