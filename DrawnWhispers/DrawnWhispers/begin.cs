using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using WatsonTcp;
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

        WatsonTcpClient client = new WatsonTcpClient("192.168.0.185", 5002);
        private void button1_Click(object sender, EventArgs e)
        {
            client.ServerConnected += Client_ServerConnected;
            client.ServerDisconnected += Client_ServerDisconnected;
            client.MessageReceived += Client_MessageReceived;
            client.Start();
            client.Send("\n\nPENIS");
            //game ga = new game();
            //ga.Show();
            //Hide();
        }

        private void Client_MessageReceived(object sender, MessageReceivedFromServerEventArgs e)
        {
            MessageBox.Show("Message from server: " + Encoding.UTF8.GetString(e.Data));
        }

        private void Client_ServerDisconnected(object sender, EventArgs e)
        {
            Console.WriteLine("Server connected");
        }

        private void Client_ServerConnected(object sender, EventArgs e)
        {
            Console.WriteLine("Server disconnected");
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
