using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Rasterization
{
    class Matrix2
    {
        int[,] A;

        public Matrix2(int[,] a)
        {
            A = new int[3, 3];
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    A[i, j] = a[i, j];

            if (a.GetLength(0) == 2)
                A[2, 2] = 1;
        }

        public Matrix2()
        {
            A = new int[2, 2] {
                { 1, 0 },
                { 0, 1 }
            };
        }

        public Point Apply(Point x)
        {
            return new Point(A[0, 0]*x.X + A[0, 1]*x.Y, A[1, 0]*x.X + A[1, 1]*x.Y);
        }

        public static Matrix2 operator *(Matrix2 a, Matrix2 b)
        {
            var c = new Matrix2(new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } });

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    for (int k = 0; k < 3; k++)
                        c.A[i, j] += a.A[i, k] * b.A[k, j];

            return c;
        }
    }

    static class SegmentRaster
    {
        public static void Swap(ref Point a, ref Point b)
        {
            var c = a;
            a = b;
            b = c;
        }

        public static List<Point> Rasterize(Point a, Point b)
        {
            var c = Normalize(a, b);
            int x1 = c.X;
            int y1 = c.Y;

            Point lst = new Point(0, 0);
            int d = x1 - 2 * y1;

            List<Point> ans = new List<Point>();

            for (int x = 1; x <= x1; x++)
            {
                Point nxt1 = new Point(lst.X + 1, lst.Y);
                Point nxt2 = new Point(lst.X + 1, lst.Y + 1);

                if (d >= 0)
                {
                    ans.Add(nxt1);
                    d = d - 2 * y1;
                }
                else
                {
                    ans.Add(nxt2);
                    d = d + 2 * (x1 - y1);
                }
            }

            for (int i = 0; i < ans.Count; i++)
                ans[i] = trA.Apply(ans[i]);

            return p;
        }

        private static Matrix2 trA, trB;

        private static Point Normalize(Point a, Point b)
        {
            if (a.X > b.X)
                Swap(ref a, ref b);

            trA = new Matrix2();

            if ((b.Y - a.Y) * (b.X - a.X) < 0)
            {
                var refA = new Matrix2(new int[2, 2]{ 
                    { -1, 0 }, 
                    { 0, 1 }
                });

                a = refA.Apply(a);
                b = refA.Apply(b);

                trA = trA * refA;

                Swap(ref a, ref b);
            }

            int dx = a.X;
            int dy = a.Y;

            var translA = new Matrix2(new int[3, 3] {
                { 1, 0, -dx },
                { 0, 1, -dy },
                { 0, 0, 1  }
            });

            a = translA.Apply(a);
            b = translA.Apply(b);

            var translA1 = new Matrix2(new int[3, 3] {
                { 1, 0, dx },
                { 0, 1, dy },
                { 0, 0, 1  }
            });

            trA = trA * translA1;

            return b;
        }
    }
}
