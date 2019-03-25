using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PointD = SegmentCutting.Point;

namespace SegmentCut
{
    public partial class Form1 : Form
    {
        const int delta = 15;
        int h;
        Point origin;
        public Form1()
        {
            InitializeComponent();
            origin = new Point(canvas.Width / 2, canvas.Height / 2);
            h = canvas.Height;
        }

        private void PaintAxis(Graphics g)
        {
            var p = new Pen(Color.LightGray);

            for (int i = 0; i < canvas.Width; i += delta)
                g.DrawLine(p, i, 0, i, canvas.Height);
            for (int i = 0; i < canvas.Height; i += delta)
                g.DrawLine(p, 0, i, canvas.Width, i);

            p.Width = 3;
            g.DrawLine(p, 0, canvas.Height / 2, canvas.Width, canvas.Height / 2);
            g.DrawLine(p, canvas.Width / 2, 0, canvas.Width / 2, canvas.Height);
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.Clear(Color.White);
            PaintAxis(g);

            if (!(string.IsNullOrEmpty(polygonPoints.Text) || string.IsNullOrEmpty(segmPoints.Text)))
            {
                PointD[] polygon;
                (PointD, PointD) segm;

                polygon = ReadPolygon();
                segm = ReadSegment();

                var cutted = SegmentCutting.CyrusBeck.Cut(segm.Item1, segm.Item2, polygon);

                var q = (from p in polygon select p.ToPointF(delta, h, origin.X, origin.Y)).ToList();
                q.Add(q[0]);

                g.DrawLines(new Pen(Color.Blue, 1.5f), q.ToArray());
                g.DrawLine(new Pen(Color.Red, 1.5f), 
                    segm.Item1.ToPointF(delta, h, origin.X, origin.Y), 
                    segm.Item2.ToPointF(delta, h, origin.X, origin.Y));

                if (cutted.Item1 != null)
                {
                    g.DrawLine(new Pen(Color.Green, 1.5f),
                        cutted.Item1.ToPointF(delta, h, origin.X, origin.Y),
                        cutted.Item2.ToPointF(delta, h, origin.X, origin.Y));
                }

                var A = segm.Item1;
                var B = segm.Item2;

                var inPts = (from t in SegmentCutting.CyrusBeck.inPoints
                             select (A + (B - A) * t).ToPointF(delta, h, origin.X, origin.Y)).ToArray();
                var outPts = (from t in SegmentCutting.CyrusBeck.outPoints
                              select (A + (B - A) * t).ToPointF(delta, h, origin.X, origin.Y)).ToArray();

                g.FillRectangles(new SolidBrush(Color.Violet), 
                    (from p in inPts
                     select new RectangleF(p.X - (float)delta / 4, p.Y - (float)delta / 4, (float)delta / 2, (float)delta / 2)).ToArray());

                g.FillRectangles(new SolidBrush(Color.DarkBlue), 
                    (from p in outPts
                     select new RectangleF(p.X - (float)delta / 4, p.Y - (float)delta / 4, (float)delta / 2, (float)delta / 2)).ToArray());
            }
        }

        private PointD[] ReadPolygon()
        {
            var s = polygonPoints.Text.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            int n = s.Length;

            if (n % 2 != 0 || n < 6)
                throw new Exception("Invalid list of polygon coordinates");

            PointD[] p = new PointD[n / 2];

            for (int i = 0; i < n; i += 2)
            {
                double x = double.Parse(s[i]);
                double y = double.Parse(s[i + 1]);

                p[i / 2] = new PointD(x, y);
            }

            return p;
        }

        private (PointD, PointD) ReadSegment()
        {
            var s = segmPoints.Text.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            int n = s.Length;

            if (n != 4)
                throw new Exception("Invalid list of segment coordinates");

            double x = double.Parse(s[0]);
            double y = double.Parse(s[1]);
            double x1 = double.Parse(s[2]);
            double y1 = double.Parse(s[3]);

            return (new PointD(x, y), new PointD(x1, y1));
        }

        private void cutBtn_Click(object sender, EventArgs e)
        {
            canvas.Refresh();
        }
    }
}
