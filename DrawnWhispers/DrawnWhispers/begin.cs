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
using System.Net.Sockets;
using System.Net.Http;

namespace DrawnWhispers
{
    public partial class beginBtn : Form
    {
        public beginBtn()
        {
            InitializeComponent();
            try { pictureBox1.Image = Image.FromFile(String.Format(@"data\{0}", imageFileNames[0])); }
            catch { MessageBox.Show("Error loading " + imageFileNames[0]); }
            try { pictureBox2.Image = Image.FromFile(String.Format(@"data\{0}", imageFileNames[1])); }
            catch { MessageBox.Show("Error loading " + imageFileNames[1]); }
            
        }

        gameUtils util = new gameUtils("descriptions.json");
        string[] imageFileNames = { "logo.png", "closeButton.png" };
        
        private async void button1_Click(object sender, EventArgs e)
        {
            global.name = nameTxtBox.Text;
            string res = await ExecuteCommand("/createlobby " + lobbyTxtBox.Text);
            Thread t = new Thread(new ParameterizedThreadStart(joinLobby));
            switch (res) 
            {
                case "joinlobby":
                    
                    t.Start(lobbyTxtBox.Text);
                    //joinLobby(lobbyTxtBox.Text);
                    break;
                case "makebutton":
                    Invoke(new Action(() =>
                    {
                        startBtn.Visible = true;
                    }));
                    t.Start(lobbyTxtBox.Text);
                    break;
                case "Unknown command":
                    MessageBox.Show("Internal error");
                    break;
                default:
                    MessageBox.Show("Unexpected Error");
                    break;
            }


            //game ga = new game();
            //ga.Show();
            //Hide(); 
        }

        async void joinAsLobbyLeader(object lobbyname)
        {
            string res = await ExecuteCommand("/joinleader " + global.name, (string)lobbyname);
            switch (res)
            {
                case "Error":
                    break;
                case "Successfully joined":
                    
                    break;
            }
        }
        async void joinLobby(object lobbyname)
        {
            string res = await ExecuteCommand("/join " + global.name, (string)lobbyname);
            switch (res) 
            {
                case "Username already taken":
                    MessageBox.Show(res);
                    return;
                case "Successfully joined":
                    break;
            }

            while (true)
            {
                string usersStr = await ExecuteCommand("/getUsers", (string)lobbyname);
                Invoke(new Action(() =>
                {
                    listBox1.Items.Clear();
                }));
                foreach (var i in usersStr.Split('|'))
                    Invoke(new Action(() =>
                    {
                        listBox1.Items.Add(i);
                    }));
                Thread.Sleep(2000);
            }

        }

        async Task<string> ExecuteCommand(string command, string lobby = "")
        {
            HttpClient client = new HttpClient();
            using (var requestContent = new StringContent(command, Encoding.UTF8, "text/plain"))
            {
                if (lobby.Length > 0)
                    lobby += "/";
                HttpResponseMessage response = await client.PostAsync("http://localhost:4004/" + lobby, requestContent);
                return await response.Content.ReadAsStringAsync();
            }
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void GuessBox_TextChanged(object sender, EventArgs e)
        {
            if (nameTxtBox.Text.Length <= 2)
            {
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
            }
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("starting server");
        }
    }
}
