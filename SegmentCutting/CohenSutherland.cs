using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegmentCutting
{
    static class CohenSutherland
    {
        public static int count;
        private static int[] X, Y, C;
        const double eps = 1e-6f;
        static bool midPointMode = false;

        private static int GetCode(Point a)
        {
            int code = 0;
            if (a.X < X[0])
                code |= (1 << 0);
            if (a.Y < Y[0])
                code |= (1 << 1);
            if (a.X > X[1])
                code |= (1 << 2);
            if (a.Y > Y[1])
                code |= (1 << 3);

            return code;
        }

        private static bool Bit(int mask, int i)
        {
            int b = (mask >> i) & 1;
            return b == 1;
        }

        private static Point IntersectX(Point a, Point b, int x)
        {
            double A = (a - b).Y;
            double B = (b - a).X;
            double C = -a.X * A - a.Y * B;

            return new Point { X = x, Y = (-C - A*x) / B };
        }

        private static Point IntersectY(Point a, Point b, int y)
        {
            double A = (a - b).Y;
            double B = (b - a).X;
            double C = -a.X * A - a.Y * B;

            return new Point { X = (-C - B*y) / A,  Y = y };
        }

        private static (Point, Point) GetCut(Point a, Point b)
        {
            count++;
            if (midPointMode && (a - b).Len < eps)
                return (null, null);

            int codeA = GetCode(a);
            int codeB = GetCode(b);

            if ((codeA & codeB) != 0)
                return (null, null);

            if ((codeA | codeB) == 0)
                return (a, b);

            int mask = codeA ^ codeB;

            Point v = new Point();
            Point mid;

            if (!midPointMode)
            {
                v = b - a;
                v = v * eps / v.Len;

                if (Bit(mask, 0))
                    mid = IntersectX(a, b, X[0]);
                else if (Bit(mask, 2))
                    mid = IntersectX(a, b, X[1]);
                else if (Bit(mask, 1))
                    mid = IntersectY(a, b, Y[0]);
                else
                    mid = IntersectY(a, b, Y[1]);
            }
            else
                mid = (a + b) / 2;

            var left = GetCut(a, mid - v);
            var right = GetCut(mid + v, b);

            if (!midPointMode)
            {
                if (left.Item1 != null)
                    return left;
                else if (right.Item1 != null)
                    return right;
                else
                    return (null, null);
            }
            else
            {
                if (left.Item1 == null)
                    return right;
                else if (right.Item1 == null)
                    return left;
                else
                    return (left.Item1, right.Item2);
            }
        }

        public static (Point, Point) Cut(Point a, Point b, bool midpoint, int x1, int x2, int y1, int y2)
        {
            X = new int[] { x1, x2 };
            Y = new int[] { y1, y2 };
            C = new int[] { x1, y1, x2, y2};
            midPointMode = midpoint;
            count = 0;

            var t = GetCut(a, b);

            return t;
        }
    }
}
