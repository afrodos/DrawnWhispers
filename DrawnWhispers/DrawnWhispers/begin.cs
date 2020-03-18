using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawnWhispers
{
    public partial class begin : Form
    {
        public begin()
        {
            InitializeComponent();
            try { pictureBox1.Image = Image.FromFile(String.Format(@"data\{0}", imageFileNames[0])); }
            catch { MessageBox.Show("Error loading " + imageFileNames[0]); }
            try { pictureBox2.Image = Image.FromFile(String.Format(@"data\{0}", imageFileNames[1])); }
            catch { MessageBox.Show("Error loading " + imageFileNames[1]); }
        }

        gameUtils util = new gameUtils("descriptions.json");
        string[] imageFileNames = { "logo.png", "closeButton.png" };
        TcpClient client = new TcpClient();

        private void button1_Click(object sender, EventArgs e)
        {
            client.Connect("192.168.0.111", 5002);
            NetworkStream ns = client.GetStream();
            Thread thread = new Thread(o => ReceiveData((TcpClient)o));


            //game ga = new game();
            //ga.Show();
            //Hide();
        }

        static void ReceiveData(TcpClient client)
        {
            NetworkStream ns = client.GetStream();
            byte[] receivedBytes = new byte[1024];
            int byte_count;

            while ((byte_count = ns.Read(receivedBytes, 0, receivedBytes.Length)) > 0)
            {
                MessageBox.Show((Encoding.ASCII.GetString(receivedBytes, 0, byte_count)));
            }
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
