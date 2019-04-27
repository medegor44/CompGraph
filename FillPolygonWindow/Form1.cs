using System.Drawing;
using System.Windows.Forms;
using LinearOperations;
using System.Collections.Generic;
using System;
using System.Linq;
using FillPolygon;

namespace FillPolygonWindow
{
    public partial class Form1 : Form
    {
        const int delta = 20;
        List<Vector> filledPolygon;
        Vector[] polygon;
        List<Vector> rasterizedBorder;

        int currPoint;
        Point origin;

        public Form1()
        {
            InitializeComponent();
            filledPolygon = new List<Vector>();
            rasterizedBorder = new List<Vector>();

            origin = new Point(canvas.Width / 2, canvas.Height / 2);
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

        Vector[] ReadPolygon()
        {
            var strs = polygonPts.Text.Split(new char[] { ' ', '\n', '\r', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
            Vector[] vectors = new Vector[strs.Length / 2];

            for (int i = 0; i < strs.Length; i += 2)
                vectors[i / 2] = new Vector(int.Parse(strs[i]), int.Parse(strs[i + 1]));

            rasterizedBorder = FillWithSeed.RaserizedPolygon(vectors);

            return vectors;
        }

        Vector ReadStartPoint()
        {
            var s = startPt.Text.Split(' ');
            return new Vector(int.Parse(s[0]), int.Parse(s[1]));
        }

        private void FillBtn_Click(object sender, EventArgs e)
        {
            polygon = ReadPolygon();
            var start = ReadStartPoint();

            filledPolygon = FillWithSeed.FillPolygon(polygon, start);

            currPoint = 0;
            timer1.Start();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            currPoint++;
            if (currPoint == filledPolygon.Count)
                timer1.Stop();

            canvas.Refresh();
        }

        void DrawPolygon(Graphics g)
        {
            if (polygon == null)
                return;
            var points = (from p in polygon select new Point(p.X * delta + origin.X, canvas.Height - (p.Y * delta + origin.Y))).ToList();
            points.Add(points[0]);

            g.DrawLines(new Pen(Color.Red), points.ToArray());
        }

        void DrawFilledPoint(Graphics g, List<Vector> from, int i, Color col)
        {
            var pt = from[i];
            int x = pt.X * delta + origin.X - delta/4;
            int y = canvas.Height - (pt.Y * delta + origin.Y) - delta / 4;

            g.FillRectangle(new SolidBrush(col), x, y, delta/2, delta/2);
        }

        void DrawRasterizedBorder(Graphics g)
        {
            for (int i = 0; i < rasterizedBorder.Count; i++)
                DrawFilledPoint(g, rasterizedBorder, i, Color.Orange);
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.Clear(Color.White);
            PaintAxis(g);
            DrawRasterizedBorder(g);
            DrawPolygon(g);


            for (int i = 0; i < currPoint; i++)
                DrawFilledPoint(g, filledPolygon, i, Color.Blue);
        }
    }
}
