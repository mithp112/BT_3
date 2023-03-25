using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BT3
{
    public partial class UDPserver : Form
    {
        public partial class Form1 : Form
        {
            UdpClient server;
            IPEndPoint clEP;

            public Form1()
            {
                server = new UdpClient(8888);
                clEP = new IPEndPoint(IPAddress.Any, 0);
                Thread receiveThread = new Thread(new ThreadStart(ReceiveData));
                receiveThread.Start();
            }

            private void ReceiveData()
            {
                while (true)
                {
                    byte[] data = server.Receive(ref clEP);
                    string message = Encoding.ASCII.GetString(data, 0, data.Length);
                }
                //Close();
            }

        }
    }
}
