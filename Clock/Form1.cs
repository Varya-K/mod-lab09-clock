using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba_9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            GraphicsState gs;
            int w = this.Width-18;
            int h = this.Height-45;
            g.TranslateTransform(w / 2, h / 2);
            int r = Math.Min(w, h) *9 / 20;
            int len = (int)Math.Round((double)r/10);

            Color clock_color = Color.FromArgb(231, 205, 146);
            Color clock_color1 = Color.FromArgb(217, 176, 84);
 
            //g.DrawEllipse(new Pen(Color.White, len), -r+len/2, -r+len/2, r * 2-len, r * 2-len);
            

            gs = g.Save();
            for (int i = 0; i < 60; i++)
            {
                if (i % 5 == 0)
                {
                    g.DrawLine(new Pen(clock_color,len/3), 0,-r, 0, -r + len);
                }
                else
                {
                    g.DrawLine(new Pen(clock_color1, len/5), 0, -r, 0, -r + len);
                }
                g.RotateTransform(6);
            }
            g.Restore(gs);

            g.DrawEllipse(new Pen(clock_color, len / 5), -r, -r, r * 2, r * 2);
            g.DrawEllipse(new Pen(clock_color, len / 5), -r + len, -r + len, r * 2 - len * 2, r * 2 - len * 2);

            Font font_numbers = new Font(FontFamily.GenericSansSerif, (float)len, FontStyle.Regular);
            SolidBrush sb_numbers = new SolidBrush(clock_color);

            gs = g.Save();

            g.RotateTransform(30);
            g.DrawString("I", font_numbers, sb_numbers, new Point(-len/2,-r+len+len/2));
            g.RotateTransform(30);
            g.DrawString("II", font_numbers, sb_numbers, new Point(-len*3/4, -r + len + len / 2));
            g.RotateTransform(30);
            g.DrawString("III", font_numbers, sb_numbers, new Point(-len, -r + len + len / 2));
            g.RotateTransform(30);
            g.DrawString("IV", font_numbers, sb_numbers, new Point(-len*7/6 , -r + len + len / 2));
            g.RotateTransform(30);
            g.DrawString("V", font_numbers, sb_numbers, new Point(-len*5/6, -r + len + len / 2));
            g.RotateTransform(30);
            g.DrawString("VI", font_numbers, sb_numbers, new Point(-len , -r + len + len / 2));
            g.RotateTransform(30);
            g.DrawString("VII", font_numbers, sb_numbers, new Point(-len*5/4, -r + len + len / 2));
            g.RotateTransform(30);
            g.DrawString("VIII", font_numbers, sb_numbers, new Point(-len * 3 / 2, -r + len + len / 2));
            g.RotateTransform(30);
            g.DrawString("IX", font_numbers, sb_numbers, new Point(-len*6 / 5, -r + len + len / 2));
            g.RotateTransform(30);
            g.DrawString("X", font_numbers, sb_numbers, new Point(-len*6/7, -r + len + len / 2));
            g.RotateTransform(30);
            g.DrawString("XI", font_numbers, sb_numbers, new Point(-len, -r + len + len / 2));
            g.RotateTransform(30);
            g.DrawString("XII", font_numbers, sb_numbers, new Point(-len*5/4, -r + len + len / 2));
            g.Restore(gs);

            DateTime dt = DateTime.Now;


            gs = g.Save();
            g.RotateTransform(15 * dt.Hour + dt.Minute / 2);
            Point[] points_hour = new Point[4];
            points_hour[0].X = 0; points_hour[0].Y = -r * 6 / 10;
            points_hour[1].X = len / 2; points_hour[1].Y = r / 15;
            points_hour[2].X = 0; points_hour[2].Y = r / 10;
            points_hour[3].X = -len / 2; points_hour[3].Y = r / 15;
            g.FillPolygon(new SolidBrush(Color.FromArgb(240, 62, 36)), points_hour);
            g.Restore(gs);


            gs = g.Save();
            g.RotateTransform(6 * dt.Minute + dt.Second/10);
            Point[] points_min = new Point[4];
            points_min[0].X = 0; points_min[0].Y = -r*7/10;
            points_min[1].X = len/3; points_min[1].Y = r/10;
            points_min[2].X = 0; points_min[2].Y = r/7;
            points_min[3].X = -len/3; points_min[3].Y = r/10;
            g.FillPolygon(new SolidBrush(Color.FromArgb(240, 95, 36)), points_min);
            g.Restore(gs);

            gs = g.Save();
            g.RotateTransform(6 * dt.Second);
            g.DrawLine(new Pen(new SolidBrush(Color.FromArgb(240, 151, 36)), len / 5), 0, r / 5, 0, -r * 7 / 8);
            g.Restore(gs);

            g.FillEllipse(new SolidBrush(Color.FromArgb(36, 36, 36)), -len/4, -len/4, len/2, len/2);
            g.FillEllipse(new SolidBrush(clock_color), -len / 8, -len / 8, len / 4, len / 4);


        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }
    }
}
