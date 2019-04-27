using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinearOperations;

namespace SegmentRasterization
{
    public static class SegmentRaster
    {
        public static void Swap(ref Vector a, ref Vector b)
        {
            var c = a;
            a = b;
            b = c;
        }

        public static List<Vector> Rasterize(Vector a, Vector b)
        {
            var c = Normalize(a, b);
            int x1 = c.X;
            int y1 = c.Y;

            Vector lst = new Vector(0, 0);
            int d = x1 - 2 * y1;

            List<Vector> ans = new List<Vector>();

            ans.Add(new Vector(0, 0));

            for (int x = 1; x <= x1; x++)
            {
                var nxt1 = new Vector(lst.X + 1, lst.Y);
                var nxt2 = new Vector(lst.X + 1, lst.Y + 1);

                if (d >= 0)
                {
                    ans.Add(nxt1);
                    lst = nxt1;
                    d = d - 2 * y1;
                }
                else
                {
                    ans.Add(nxt2);
                    lst = nxt2;
                    d = d + 2 * (x1 - y1);
                }
            }

            for (int i = 0; i < ans.Count; i++)
                ans[i] = trA.Apply(ans[i]);

            return ans;
        }

        private static Matrix3 trA, trB;

        private static Vector Normalize(Vector a, Vector b)
        {
            if (a.X > b.X || (a.X == b.X && a.Y > b.Y))
                Swap(ref a, ref b);

            trA = new Matrix3();

            if ((b.Y - a.Y) * (b.X - a.X) < 0)
            {
                var refA = new Matrix3(new int[2, 2]{ 
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

            var translA = new Matrix3(new int[3, 3] {
                { 1, 0, -dx },
                { 0, 1, -dy },
                { 0, 0, 1  }
            });

            a = translA.Apply(a);
            b = translA.Apply(b);

            var translA1 = new Matrix3(new int[3, 3] {
                { 1, 0, dx },
                { 0, 1, dy },
                { 0, 0, 1  }
            });

            trA = trA * translA1;

            if (b.X - a.X < b.Y - a.Y)
            {
                var refXY = new Matrix3(new int[2, 2] {
                    { 0, 1 },
                    { 1, 0 }
                });

                a = refXY.Apply(a);
                b = refXY.Apply(b);

                trA = trA * refXY;
            }

            return b;
        }
    }
}
