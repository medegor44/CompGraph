using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegmentCutting
{
    static class CyrusBeck
    {
        public static (Point, Point) Cut(Point a, Point b, Point[] polygon)
        {
            int n = polygon.Length;

            List<double> inPoints = new List<double>();
            List<double> outPoints = new List<double>();

            for (int i = 0; i < n; i++)
            {
                Point e1 = polygon[i];
                Point e2 = polygon[(i + 1) % n];

                Point N = new Point((e2 - e1).Y, (e1 - e2).X);

                double k = Point.Dot(b - a, N);
                if (Math.Abs(k) < double.Epsilon)
                {
                    Point e3 = polygon[(i + 2) % n];
                    double A = N.X;
                    double B = N.Y;
                    double C = -A * e1.X - B * e1.Y;

                    if ((a.X * A + a.Y * B + C) * (e3.X * A + e3.Y * B + C) < 0)
                        return (null, null);

                    continue;
                }

                double t = -Point.Dot(a - e1, N) / Point.Dot(b - a, N);

                if (k < -double.Epsilon)
                    inPoints.Add(t);
                else
                    outPoints.Add(t);
            }

            double tin = inPoints.Max();
            double tout = outPoints.Min();

            if (tin > tout + double.Epsilon)
                return (null, null);
            return (a + (b - a) * tin, a + (b - a) * tout);
        }
    }
}
