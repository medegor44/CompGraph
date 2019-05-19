using System;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ConvexHullAlgo;
using LinearAlgebra;

namespace ConvexHullWindow
{
    public partial class Form1 : Form
    {
        Point origin;
        const int delta = 20;
        int h;
        int currPoint;

        List<Tuple<Vector2, Triangle>> sertificate;
        List<Tuple<Color, Point>> pointsToDraw;
        List<Vector2> points;
        List<Point> convexHull;

        public Form1()
        {
            InitializeComponent();

            sertificate = new List<Tuple<Vector2, Triangle>>();
            pointsToDraw = new List<Tuple<Color, Point>>();
            points = new List<Vector2>();
            convexHull = null;

            origin = new Point(canvas.Width / 2, canvas.Height / 2);
            h = canvas.Height;
            currPoint = 0;
        }

        private void ReadPoints()
        {
            var t = (from s in pointsTb.Text.Split(new char[] { ' ', ',', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                     select int.Parse(s))
                     .ToArray();

            points.Clear();
            for (int i = 0; i < t.Length; i += 2)
                points.Add(new Vector2(t[i], t[i + 1]));
        }

        private void buildCHBtn_Click(object sender, EventArgs e)
        {
            ReadPoints();
            sertificate = Algorithm.GetSert(points);

            pointsToDraw = points.Select(x => new Tuple<Color, Point>(Color.Black, x.ToPoint(h, delta, origin))).ToList();

            convexHull = null;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (currPoint == sertificate.Count)
            {
                timer1.Stop();
                currPoint = 0;
                convexHull = Algorithm.Solve(points).Select(x => x.ToPoint(h, delta, origin)).ToList();
                convexHull.Add(convexHull[0]);
                canvas.Refresh();
                return;
            }
            if (sertificate[currPoint].Item2 is null)
                pointsToDraw.Add(new Tuple<Color, Point>(Color.Green, sertificate[currPoint].Item1.ToPoint(h, delta, origin)));
            else
                pointsToDraw.Add(new Tuple<Color, Point>(Color.Red, sertificate[currPoint].Item1.ToPoint(h, delta, origin)));

            canvas.Refresh();

            currPoint++;
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

        private void DrawPoint(Graphics g, Point p, Color c)
        {
            g.FillEllipse(new SolidBrush(c), new Rectangle(p.X - delta / 4, p.Y - delta / 4, delta/2, delta/2));
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.Clear(Color.White);
            PaintAxis(g);

            foreach (var t in pointsToDraw)
                DrawPoint(g, t.Item2, t.Item1);

            if (currPoint < sertificate.Count && (convexHull is null) && !(sertificate[currPoint].Item2 is null))
            {
                var triangle = sertificate[currPoint].Item2.Vertices.Select(x => x.ToPoint(h, delta, origin)).ToList();
                triangle.Add(sertificate[currPoint].Item2.Vertices[0].ToPoint(h, delta, origin));

                g.DrawLines(new Pen(Color.Blue), triangle.ToArray());
            }

            if (!(convexHull is null))
                g.DrawLines(new Pen(Color.Blue), convexHull.ToArray());
        }
    }
}
