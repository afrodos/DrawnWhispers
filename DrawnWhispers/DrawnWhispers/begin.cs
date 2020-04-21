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

        private void button1_Click(object sender, EventArgs e)
        {
            //game ga = new game();
            //ga.Show();
            //Hide();
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
    }
}
