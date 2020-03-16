using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawnWhispers
{
    public partial class begin : Form
    {

        string logoFileName = "logo.png";

        public begin()
        {
            InitializeComponent();
            try 
            { 
                pictureBox1.Image = Image.FromFile(String.Format(@"data\{0}", logoFileName)); 

            }
            catch
            {
                MessageBox.Show("Error loading Images, files missing in data");    
            }
        }

        gameUtils util = new gameUtils("descriptions.json");
        private void button1_Click(object sender, EventArgs e)
        {
            //richTextBox1.Text = util.getRandomDescription("special");
            //game gameForm = new game();
            //gameForm.Show();
            //Hide();
        }
    }
}
