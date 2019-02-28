using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

using static System.Math;

namespace ComputerGr
{
    public class Figure
    {
        public Vector3[] Points { get; }
        public int H { get; private set; }
        public List<Vector3> Up { get; private set; }
        public List<Vector3> Down;
        public PointF Origin { get; private set; }

        public Figure(PointF orig, int h)
        {
            Points = new Vector3[4] { new Vector3(-50, 25), new Vector3(50, 25), new Vector3(50, -25), new Vector3(-50, -25) };
            H = h;
            Origin = orig;
            CalcUpDown();
        }

        public Figure(Vector3 a1, Vector3 a2 ,Vector3 a3, Vector3 a4, List<Vector3> up, List<Vector3> down, PointF orig, int h)
        {
            Points = new Vector3[4] { a1, a2, a3, a4 };
            Up = up;
            Down = down;
            H = h;
            Origin = orig;
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

                Up.Add(p1);
                Down.Add(p2);
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
                    new PointF(Points[a].X[0] + Origin.X, H - (Points[a].X[1] + Origin.Y)),
                    new PointF(Points[b].X[0] + Origin.X, H - (Points[b].X[1] + Origin.Y))
                });
            }

            var s = (from x in Up select new PointF(x.X[0] + Origin.X, H - (x.X[1] + Origin.Y))).ToArray();
            var t = (from x in Down select new PointF(x.X[0] + Origin.X, H - (x.X[1] + Origin.Y))).ToArray();
            g.DrawLines(pen, s);
            g.DrawLines(pen, t);
        }
    }

    public static class GraphicsExtension
    {
        public static void DrawFigure(this Graphics g, Pen pen, Figure f)
        {
            for (int i = 0; i < 4; i++)
            {
                int a = i;
                int b = (i + 1) % 4;

                g.DrawCurve(pen, new PointF[] {
                    new PointF(f.Points[a].X[0] + f.Origin.X, f.H - (f.Points[a].X[1] + f.Origin.Y)),
                    new PointF(f.Points[b].X[0] + f.Origin.X, f.H - (f.Points[b].X[1] + f.Origin.Y))
                });
            }

            var s = (from x in f.Up select new PointF(x.X[0] + f.Origin.X, f.H - (x.X[1] + f.Origin.Y))).ToArray();
            var t = (from x in f.Down select new PointF(x.X[0] + f.Origin.X, f.H - (x.X[1] + f.Origin.Y))).ToArray();
            g.DrawLines(pen, s);
            g.DrawLines(pen, t);
        }
    }
}
