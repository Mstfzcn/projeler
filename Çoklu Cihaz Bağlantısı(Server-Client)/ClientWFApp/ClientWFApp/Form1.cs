using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;
using System.Net;

namespace ClientWFApp
{
    public partial class Form1 : Form
    {
        public static string[] posVal;
        public static string x, y, mouseEventState;

        [DllImport("User32.Dll")]
        public static extern long SetCursorPos(int x, int y);

        [DllImport("User32.Dll")]
        public static extern bool ClientToScreen(IntPtr hWnd, ref POINT point);

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int x;
            public int y;
        }

        private const UInt32 MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const UInt32 MOUSEEVENTF_LEFTUP = 0x0004;
        private const UInt32 MOUSEEVENTF_RIGHTDOWN = 0x0008;
        private const UInt32 MOUSEEVENTF_RIGHTUP = 0x0010;
        [DllImport("user32.dll")]
        private static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, uint dwExtraInf);

        public Form1()
        {
            InitializeComponent();
            
        }

        private void btnBaglan_Click(object sender, EventArgs e)
        {
            try
            {
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                this.Hide();

                TcpClient client = new TcpClient("192.168.1.9", 90);//Sunucu hizmeti başlatılan cihazın IPv4 adresi

                NetworkStream ns = client.GetStream();
                StreamReader sr = new StreamReader(ns);

                Form1.POINT p = new Form1.POINT();
                
                string satir = "";
                do
                {
                    satir = sr.ReadLine();
                    posVal = satir.Split(' ');

                    if (posVal.Length == 2)
                    {
                        x = posVal[0];
                        y = posVal[1];
                        
                        p.x = Convert.ToInt16(x);
                        p.y = Convert.ToInt16(y);

                        Form1.ClientToScreen(this.Handle, ref p);
                        Form1.SetCursorPos(p.x, p.y);
                    }
                    else if(posVal.Length == 3)
                    {
                        x = posVal[0];
                        y = posVal[1];
                        mouseEventState = posVal[2];

                        p.x = Convert.ToInt16(x);
                        p.y = Convert.ToInt16(y);

                        Form1.ClientToScreen(this.Handle, ref p);
                        Form1.SetCursorPos(p.x, p.y);

                        if (mouseEventState.Equals("leftClick"))
                        {
                            int w = Convert.ToInt16(x);//set w position 
                            int h = Convert.ToInt16(y);//set h position 
                            Cursor.Position = new Point(w, h);
                            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);//make left button down
                            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);//make left button up
                        }
                        else if (mouseEventState.Equals("rightClick"))
                        {
                            int w = Convert.ToInt16(x);//set w position 
                            int h = Convert.ToInt16(y);//set h position 
                            Cursor.Position = new Point(w, h);
                            mouse_event(MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, 0);//make left button down
                            mouse_event(MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0);//make left button up
                        }
                    }
                } while (true);

                ns.Close();
                sr.Close();
                client.Close();
            }
            catch (Exception ex)
            {
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                this.WindowState = FormWindowState.Normal;
                this.Show();
                Console.WriteLine("Hata Oluştu : " + ex.Message);
            }
        }
    }
}
