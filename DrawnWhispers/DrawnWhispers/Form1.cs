using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading; //delay

namespace DrawnWhispers
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            gameUtils util = new gameUtils();
            string[,] order = util.getOrder(new string[] { "syas", "eiji", "davy", "ties", "redmer", "maikel", "bess" });
            MessageBox.Show(order[6,1]); //WHAHAHAHAHAHHAHH HET WERKT

        }

        //TODO: maak andere form die je bij het begin krijgt (title, naam invoeren, communicatie tussen 2 forms)
        //images voor groottes
        //woord boven canvas display
        //zie welke kleur je geselect hebt
        //convert tekening naar data (dus naar 2d array of image)
        //timer voor tekenen


        Graphics g;
        Pen pen;
        const int ups = 100; //update per second
        int x = -1;
        int y = -1;
        bool moving = false;

        //https://docs.microsoft.com/en-us/dotnet/api/system.drawing.graphics?view=netframework-4.8
        //DrawLine(Pen, Point, Point)
        private void Form1_Load(object sender, EventArgs e)
        {
            pen = new Pen(Color.Blue, 10);
            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            g = canvas.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            this.DoubleBuffered = true;
            Point local = this.PointToClient(Cursor.Position);
            g.DrawEllipse(pen, local.X - 25, local.Y - 25, 20, 20);
        }

        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            moving = true;
            x = e.X;
            y = e.Y;
        }

        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            moving = false;
            x = -1;
            x = -1;
        }

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (moving && x != -1 && y != -1)
            {
                g.DrawLine(pen, new Point(x, y), e.Location);
                x = e.X;
                y = e.Y;
                Thread.Sleep((int)Math.Round(Convert.ToDecimal(1000 / ups)));//dont touch
            }
        }

        private void Panel1_Click(object sender, EventArgs e)
        {
            Panel p = (Panel)sender;
            pen.Color = p.BackColor;
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            switch (p.Tag)
            {
                case "small":
                    pen.Width = 5;
                    break;
                case "normal":
                    pen.Width = 10;
                    break;
                case "large":
                    pen.Width = 20;
                    break;
                case "huge":
                    pen.Width = 40;
                    break;

            }

        }
        
    }
}
