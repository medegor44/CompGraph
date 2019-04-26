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
        const int delta = 10;
        List<Vector> filledPolygon;
        Vector[] polygon;
        bool needsClear;

        int h;
        int currPoint;
        Point origin;

        public Form1()
        {
            InitializeComponent();
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

            currPoint = -1;
            needsClear = true;
            timer1.Start();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            currPoint = Math.Min(currPoint + 1, filledPolygon.Count);
            canvas.Refresh();
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            if (needsClear)
            {
                g.Clear(Color.White);
                PaintAxis(g);
                g.DrawLines(new Pen(new SolidBrush(Color.Red)), 
                    (from p in polygon select p.ToPoint())
                    .Union(new Point[] { polygon[polygon.Length - 1].ToPoint() })
                    .ToArray());
            }
        }
    }
}
