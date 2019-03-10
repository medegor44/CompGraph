using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinearOperations;

namespace CircleRasterization
{
    public static class CircleRaster
    {
        public static List<Vector> Rasterize(Vector a, int r)
        {
            a = Normalize(a);

            int y = r;

            List<Vector> ans = new List<Vector>();
            ans.Add(new Vector(0, r));
            int d = 1 + 4 * (1 - r);

            for (int x = 0; r * r - x * x > x * x; x++)
            {
                var nxt1 = new Vector(x + 1, y);
                var nxt2 = new Vector(x + 1, y - 1);

                if (d >= 0)
                {
                    ans.Add(nxt2);
                    y--;
                    d = d + 8 * (x - y) + 20;
                }
                else
                {
                    ans.Add(nxt1);
                    d = d + 8 * x + 12;
                }
            }

            var q = (from x in ans select new Vector(x.Y, x.X)).ToList().Union(ans);
            var aans = new List<Vector>();
            foreach (var p in q)
            {
                aans.Add(p);
                aans.Add(new Vector(-p.X, p.Y));
                aans.Add(new Vector(p.X, -p.Y));
                aans.Add(new Vector(-p.X, -p.Y));
            }

            return (from x in aans select tr.Apply(x)).ToList(); 
        }

        static Matrix3 tr;

        private static Vector Normalize(Vector a)
        {
            tr = new Matrix3(new int[3, 3] {
                { 1, 0, a.X},
                { 0, 1, a.Y},
                { 0, 0, 1}
            });

            var m = new Matrix3(new int[3, 3] {
                { 1, 0, -a.X},
                { 0, 1, -a.Y},
                { 0, 0, 1}
            });

            return m.Apply(a);
        }
    }
}
