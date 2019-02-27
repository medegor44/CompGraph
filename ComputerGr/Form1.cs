using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using static System.Math;

namespace ComputerGr
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            float q = (float)Math.Sqrt(2);
            var g = e.Graphics;
            Figure f = new Figure(canvas.Height);
            Matrix3 M = new Matrix3(new float[3, 3] {
                { q/2, -q/2, 0 },
                { q/2, q/2, 0 },
                { 0, 0, 1 }
            });

            Matrix3 M1 = new Matrix3(new float[3, 3] {
                { 1, 0, 50 },
                { 0, 1, 75 },
                { 0, 0, 1 }
            });

            Matrix3 M2 = new Matrix3(new float[3, 3] {
                { 1, 0, -50 },
                { 0, 1, -75 },
                { 0, 0, 1 }
            });

             Matrix3 M3 = new Matrix3(new float[3, 3] {
                { 1, 0, 0 },
                { 0, 1, 0 },
                { 0, 0, 1 }
            });

            f.Draw(g);

            Figure f1 = M1*(M*(M2*(M3*f)));
            f1.Draw(g);

            //g.DrawRectangle(new Pen(Color.Red), 100, canvas.Height - 100, 5, 5);
        }
    }

    class Figure
    {
        public Vector3[] Points { get; }
        public int H { get; private set; }
        public List<Vector3> Up { get; private set; }
        public List<Vector3> Down;

        public Figure(int h)
        {
            Points = new Vector3[4] { new Vector3(0, 100), new Vector3(100, 100), new Vector3(100, 50), new Vector3(0, 50) };
            H = h;
            CalcUpDown();
        }

        public Figure(Vector3 a1, Vector3 a2 ,Vector3 a3, Vector3 a4, List<Vector3> up, List<Vector3> down, int h)
        {
            Points = new Vector3[4] { a1, a2, a3, a4 };
            Up = up;
            Down = down;
            H = h;
        }

        private void CalcUpDown()
        {
            float a = (Points[0] - Points[1]).Len / 2;
            float b = (Points[0] - Points[3]).Len;

            const int n = 500;
            
            Up = new List<Vector3>();
            Down = new List<Vector3>();

            for (int k = 0; k <= n; k++)
            {
                float x = a * (float)Cos(PI * k / n);
                float y = b * (float)Sin(PI * k / n);

                var p1 = new Vector3(x,  y) + (Points[0] + Points[1]) * 0.5f;
                var p2 = new Vector3(x, -y) + (Points[2] + Points[3]) * 0.5f;

                Up.Add(p1 );
                Down.Add(p2 );
            }
        }

        public void Draw(Graphics g)
        {
            var pen = new Pen(Color.Black);
            for (int i = 0; i < 4; i++)
            {
                int a = i;
                int b = (i + 1) % 4;

                g.DrawCurve(pen, new PointF[] {
                    new PointF(Points[a].X[0], H - Points[a].X[1]),
                    new PointF(Points[b].X[0], H - Points[b].X[1])
                });
            }

            var s = (from x in Up select new PointF(x.X[0], H - x.X[1])).ToArray();
            var t = (from x in Down select new PointF(x.X[0], H - x.X[1])).ToArray();
            g.DrawLines(pen, s);
            g.DrawLines(pen, t);

        }
    }

    class Vector3
    {
        public float[] X { get; private set; }

        public Vector3()
        {
            X = new float[3] { 0, 0, 1 };
        }

        public Vector3(float x, float y)
        {
            X = new float[3] { x, y, 1};
        }

        public PointF ToPointF()
        {
            return new PointF(X[0], X[1]);
        }

        public static Vector3 operator +(Vector3 v1, Vector3 v2)
        {
            Vector3 u = new Vector3();
            for (int i = 0; i < 2; i++)
                u.X[i] = v1.X[i] + v2.X[i];
            return u;
        }

        public static Vector3 operator -(Vector3 v1, Vector3 v2)
        {
            Vector3 u = new Vector3();
            for (int i = 0; i < 2; i++)
                u.X[i] = v1.X[i] - v2.X[i];
            return u;
        }

        public static Vector3 operator *(Vector3 v, float t)
        {
            return new Vector3(v.X[0] * t, v.X[1] * t);
        }

        public float Len
        {
            get
            {
                return (float)Math.Sqrt(X[0] * X[0] + X[1] * X[1]);
            }
        }

        public override string ToString()
        {
            return $"({X[0]}, {X[1]})";
        }
    }

    class Matrix3
    {
        public float[,] A { get; private set; }

        public Matrix3()
        {
            A = new float[3, 3];
        }

        public Matrix3(float[,] a)
        {
            if ((a.GetLength(0) != 3 || a.GetLength(1) != 3) && (a.GetLength(0) != 2 || a.GetLength(1) != 2))
                throw new ArgumentException("Matrix must be 3x3 or 2x2");

            A = new float[3, 3];

            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    A[i, j] = a[i, j];

            if (a.GetLength(0) == 2)
                A[2, 2] = 1;
        }

        public Vector3 Apply(Vector3 x)
        {
            Vector3 y = new Vector3();
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    y.X[i] += A[i, j] * x.X[j];

            y.X[2] = 1;
            return y;
        }

        public static Vector3 operator *(Matrix3 m, Vector3 v)
        {
            return m.Apply(v);
        }

        public static Figure operator *(Matrix3 m, Figure f)
        {
            Vector3[] points = new Vector3[4];
            for (int i = 0; i < 4; i++)
                points[i] = m * f.Points[i];

            var up = new List<Vector3>();
            var down = new List<Vector3>();

            foreach (var v in f.Up)
                up.Add(m*v);
            foreach (var v in f.Down)
                down.Add(m*v);

            return new Figure(points[0], points[1], points[2], points[3], up, down, f.H);
        }
    }
}
