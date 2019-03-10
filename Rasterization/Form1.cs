using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SegmentRasterization;
using LinearOperations;
using CircleRasterization;

namespace Rasterization
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            origin = new Point(canvas.Width / 2, canvas.Height / 2);
            h = canvas.Height;
        }

        const int delta = 10;
        int h;
        Point origin;

        void DrawGrid(Graphics g)
        {
            var pen = new Pen(Color.Gray);

            for (int i = 0; i <= canvas.Height; i += delta)
                g.DrawLine(pen, 0, i, canvas.Width, i);
            for (int j = 0; j <= canvas.Width; j += delta)
                g.DrawLine(pen, j, 0, j, canvas.Height);
        }

        private void DrawSegment(Graphics g, Vector a, Vector b)
        {
            g.DrawLine(new Pen(Color.Blue), 
                a.X * delta + origin.X, 
                h - (a.Y*delta + origin.Y), 
                b.X*delta + origin.X, 
                h - (b.Y*delta + origin.Y));

            var points = SegmentRaster.Rasterize(a, b);

            int sz = delta / 2;
            foreach (var pt in points)
            {
                Point p = pt.ToPoint();
                g.FillEllipse(new SolidBrush(Color.Red), 
                    pt.X*delta - sz/2 + origin.X, 
                    h - (pt.Y*delta + origin.Y) - sz/2 , 
                    sz, sz);
            }
        }

        private void DrawCircle(Graphics g, Vector a, int r)
        {
            g.DrawEllipse(new Pen(Color.Blue), (a.X - r)*delta + origin.X, (a.Y - r)*delta + origin.Y, 2*r*delta, 2*r*delta);
            var points = CircleRaster.Rasterize(a, r);

            int sz = delta / 2;
            foreach (var pt in points)
            {
                Point p = pt.ToPoint();
                g.FillEllipse(new SolidBrush(Color.Red), 
                    pt.X*delta - sz/2 + origin.X, 
                    h - (pt.Y*delta + origin.Y) - sz/2 , 
                    sz, sz);
            }
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            DrawGrid(g);
            if (segmentRB.Checked)
            {
                int x0 = int.Parse(x0TB.Text);
                int y0 = int.Parse(y0TB.Text);
                int x1 = int.Parse(x1TB.Text);
                int y1 = int.Parse(y1TB.Text);

                DrawSegment(g, new Vector(x0, y0), new Vector(x1, y1));
            }
            else
            {
                int x = int.Parse(xTB.Text);
                int y = int.Parse(yTB.Text);
                int r = int.Parse(rTB.Text);

                DrawCircle(g, new Vector(x, y), r);
            }
        }

        private void segmentRB_CheckedChanged(object sender, EventArgs e)
        {
            x0TB.Enabled = y0TB.Enabled = x1TB.Enabled = y1TB.Enabled = segmentRB.Checked;
        }

        private void circleRB_CheckedChanged(object sender, EventArgs e)
        {
            xTB.Enabled = yTB.Enabled = rTB.Enabled = circleRB.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            canvas.Refresh();
        }
    }
}
