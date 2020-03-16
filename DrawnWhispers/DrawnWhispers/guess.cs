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

        private void GuessBox_Enter_1(object sender, EventArgs e)
        {
            if (GuessBox.Text == "Enter description")
            {
                GuessBox.Text = "";
            }
        }

        private void GuessBox_Leave_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(GuessBox.Text))
                GuessBox.Text = "Enter description";
        }
    }
}
