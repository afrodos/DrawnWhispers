using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawnWhispers
{
    public partial class guess : Form
    {
        public guess()
        {
            InitializeComponent();
            this.ActiveControl = submitBtn;
        }

        Point lastPoint;

        private void GuessBox_Enter(object sender, EventArgs e)
        {
            if (guessBox.Text == "Enter description")
            {
                guessBox.Text = "";
            }
        }

        private void GuessBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(guessBox.Text))
                guessBox.Text = "Enter description";
        }

        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
    }
}
