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
        public begin()
        {
            InitializeComponent();
        }

        gameUtils util = new gameUtils("descriptions.json");
        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = util.getRandomDescription("special");
            //game gameForm = new game();
            //gameForm.Show();
            //Hide();
        }
    }
}
