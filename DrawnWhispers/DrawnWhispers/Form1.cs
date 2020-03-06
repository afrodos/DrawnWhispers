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
        }

        Graphics g;
        Pen pen;
        const int ups = 20; //update per second
        Point firstPoint;
        bool first = true;//slim? nee
        bool isMouseDown = false;

        //https://docs.microsoft.com/en-us/dotnet/api/system.drawing.graphics?view=netframework-4.8
        //DrawLine(Pen, Point, Point)
        private void Form1_Load(object sender, EventArgs e)
        {
            pen = new Pen(Color.Blue, 5);
            g = pictureBox1.CreateGraphics();
            Thread thread = new Thread(canvasloop);
            thread.Start();
            g.DrawLine(pen, new Point(0, 0), new Point(1080,1920));
        }

        void placeLine()
        {
            if (first)
            {
                firstPoint = Cursor.Position;
                first = false;
                Thread.Sleep((int)Math.Round(Convert.ToDecimal(1000 / ups)));//dont touch
            }
            else
            {
                g.DrawLine(pen, firstPoint, Cursor.Position);
                first = true;
            }

        }

        void canvasloop() //diff thread
        {
            while(isMouseDown)
            {
               placeLine();
            }
        }



        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseDown = true;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
        }
        int i = 0;

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Thread.Sleep(100000);
            pen = new Pen(Color.Blue, 5);
            g = pictureBox1.CreateGraphics();
            Thread thread = new Thread(canvasloop);
            thread.Start();
            g.DrawLine(pen, new Point(0, i), new Point(1080, i));
            i += 5;
        }
    }
}
