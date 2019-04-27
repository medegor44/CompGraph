using LinearOperations;
using SegmentRasterization;
using System.Collections.Generic;
using System.Linq;

using static System.Math;

namespace FillPolygon
{
    static class FillWithSeed
    {
        public static List<Vector> RaserizedPolygon(Vector[] v)
        {
            int n = v.Length;
            List<Vector> points = new List<Vector>();
            for (int i = 0; i < n; i++)
            {
                var t = SegmentRaster.Rasterize(v[i], v[(i + 1) % n]);
                points = points.Concat(t).ToList();
            }

            return points;
        }
        public static List<Vector> FillPolygon(Vector[] points, Vector start)
        {
            HashSet<Vector> usedPoints = new HashSet<Vector>();
            Stack<Vector> stack = new Stack<Vector>();
            int n = points.Length;

            int MinX = (from p in points select p.X).Min();
            int MaxX = (from p in points select p.X).Max();
            int MinY = (from p in points select p.Y).Min();
            int MaxY = (from p in points select p.Y).Max();

            for (int i = 0; i < n; i++)
            {
                var t = SegmentRaster.Rasterize(points[i], points[(i + 1) % n]);
                usedPoints.UnionWith(t);
            }

            stack.Push(start);
            usedPoints.Add(start);
            List<Vector> ans = new List<Vector>();

            while (stack.Count > 0)
            {
                var p = stack.Pop();
                ans.Add(p);

                for (int dx = -1; dx <= 1; dx++)
                    for (int dy = -1; dy <= 1; dy++)
                    {
                        int x = p.X + dx;
                        int y = p.Y + dy;

                        if (Abs(dx) + Abs(dy) == 1)
                        {
                            var nxtPoint = new Vector(x, y);

                            if (MinX <= x && x <= MaxX && MinY <= y && y <= MaxY && !usedPoints.Contains(nxtPoint))
                            {
                                stack.Push(nxtPoint);
                                usedPoints.Add(nxtPoint);
                            }
                        }
                    }
            }

            return ans;
        }
    }
}
