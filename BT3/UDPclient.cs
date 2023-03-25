using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace BT3
{
    public partial class client : Form
    {
        Socket clientSK;
        IPEndPoint EndPoint;
        public client()
        {
            InitializeComponent();
            clientSK = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            EndPoint = new IPEndPoint(IPAddress.Parse("172.0.0.1"), 8888);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string message = textBox1.Text;
            byte[] data = Encoding.ASCII.GetBytes(message);
            clientSK.SendTo(data, EndPoint);
            //textBox1.Text = "";
            Byte[] buffer = new byte[1024];
            clientSK.Receive(buffer);
            String data1 = Encoding.ASCII.GetString(buffer);
        }
    }
}