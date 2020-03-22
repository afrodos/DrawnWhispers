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
    public partial class game : Form
    {
        public game()
        {
            InitializeComponent();
            try{ pictureBox1.Image = Image.FromFile(String.Format(@"data\{0}", imageFileNames[0])); }
            catch { MessageBox.Show("Error loading " + imageFileNames[0]); }
            try { pictureBox2.Image = Image.FromFile(String.Format(@"data\{0}", imageFileNames[1])); }
            catch { MessageBox.Show("Error loading " + imageFileNames[1]); }
            try { pictureBox3.Image = Image.FromFile(String.Format(@"data\{0}", imageFileNames[2])); }
            catch { MessageBox.Show("Error loading " + imageFileNames[2]); }
            try { pictureBox4.Image = Image.FromFile(String.Format(@"data\{0}", imageFileNames[3])); }
            catch { MessageBox.Show("Error loading " + imageFileNames[3]); }
            try { pictureBox5.Image = Image.FromFile(String.Format(@"data\{0}", imageFileNames[4])); }
            catch { MessageBox.Show("Error loading " + imageFileNames[4]); }

        }

        //TODO: maak andere form die je bij het begin krijgt (title, naam invoeren, communicatie tussen 2 forms)
        //convert tekening naar data (dus naar 2d array of image)
        //timer voor tekenen

        /*
          #F4E8DB
          #C1B4A9
          #756A62
          #95534F
          #CC6861
         */

        Graphics g;
        Pen pen;
        const int ups = 50; //update per second

        int x = -1;
        int y = -1;
        bool moving = false;
        string[] imageFileNames = { "rondje5px.png", "rondje10px.png", "rondje20px.png", "rondje40px.png", "closeButton.png" };

        public DateTime endTime { get; private set; }

        enum pensizes
        {
            small = 10,
            normal = 20,
            large = 35,
            huge = 60
        }



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

            //timer
            var tijd = 2; //tijd om te tekenen
            var start = DateTime.UtcNow;
             endTime = start.AddMinutes(tijd);
            timer1.Enabled = true;
        }
        
        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            moving = true;
            x = e.X;
            y = e.Y;
        }


        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            moving = false;
            x = -1;
            x = -1;
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
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
            selectedColorPanel.BackColor = p.BackColor;
            pen.Color = p.BackColor;
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            switch (p.Tag)
            {
                case "small":
                    pen.Width = (float)pensizes.small;
                    break;
                case "normal":
                    pen.Width = (float)pensizes.normal;
                    break;
                case "large":
                    pen.Width = (float)pensizes.large;
                    break;
                case "huge":
                    pen.Width = (float)pensizes.huge;
                    break;
            }

        }

        int firstpos = 0;
        int secondpos = 0;
        bool isfirst = true;
        int combo = 0;
        int threshold = 30;
        int saveddiff = 2;
        Point lastPoint;
        bool mouseisdown = false;

        private void TopBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)//to move the form
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
            if (isfirst)
            {
                isfirst = false;
                firstpos = e.X; 
            }
            else
            {
                secondpos = e.X;
                int diff = firstpos - secondpos;
                if (Math.Sign(diff) != saveddiff && diff != 0 && mouseisdown && Math.Abs(diff) > 10)
                {
                    saveddiff = Math.Sign(diff);
                    if (Math.Abs(diff) >= threshold)
                    {
                        combo++;
                        Thread t = new Thread(startdecay);
                        t.Start();
                    }
                }
                firstpos = secondpos;
                Thread.Sleep(1);
            }

            if (combo == 5)
            {
                canvas.Invalidate();//clear the canvas
                combo = 0;
            }
        }
        void startdecay()
        {
            Thread.Sleep(500);
            combo = 0;
        }
        private void TopBar_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
            mouseisdown = true;
        }

        private void PictureBox5_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan remainingTime = endTime - DateTime.UtcNow;
            if (remainingTime < TimeSpan.Zero)
            {
                timerText.Text = "Done!";
                timerText.Enabled = false;
            }
            else
            {
                timerText.Text = remainingTime.ToString(@"mm\:ss");
            }
        }

        private void topBar_MouseUp(object sender, MouseEventArgs e)
        {
            mouseisdown = false;
        }
    }
}
