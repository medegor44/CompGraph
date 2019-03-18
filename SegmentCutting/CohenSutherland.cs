using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegmentCutting
{
    static class CohenSutherland
    {
        private static int[] X, Y, C;
        const float eps = 1e-6f;
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
            float A = (a - b).Y;
            float B = (b - a).X;
            float C = -a.X * A - a.Y * B;

            return new Point { X = x, Y = (-C - A*x) / B };
        }

        private static Point IntersectY(Point a, Point b, int y)
        {
            float A = (a - b).Y;
            float B = (b - a).X;
            float C = -a.X * A - a.Y * B;

            return new Point { X = (-C - B*y) / A,  Y = y };
        }

        private static (Point, Point) GetCut(Point a, Point b)
        {
            int codeA = GetCode(a);
            int codeB = GetCode(b);

            if ((codeA & codeB) != 0)
                return (null, null);

            if ((codeA | codeB) == 0)
                return (a, b);

            int mask = codeA ^ codeB;

            var v = b - a;
            v.X = (v.X / v.Len)*eps;
            v.Y = (v.Y / v.Len)*eps;

            if (Bit(mask, 0))
            {
                var p = IntersectX(a, b, X[0]);

                var left = GetCut(a, p - v);
                var right = GetCut(p + v, b);

                if (left.Item1 != null)
                    return left;
                else if (right.Item1 != null)
                    return right;
                else
                    return (null, null);
            }
            else if (Bit(mask, 2))
            {
                var p = IntersectX(a, b, X[1]);
                var left = GetCut(a, p - v);
                var right = GetCut(p + v, b);

                if (left.Item1 != null)
                    return left;
                else if (right.Item1 != null)
                    return right;
                else
                    return (null, null);
            }
            else if (Bit(mask, 1))
            {
                var p = IntersectY(a, b, Y[0]);
                var left = GetCut(a, p - v);
                var right = GetCut(p + v, b);

                if (left.Item1 != null)
                    return left;
                else if (right.Item1 != null)
                    return right;
                else
                    return (null, null);
            }
            else
            {
                var p = IntersectY(a, b, Y[1]);
                var left = GetCut(a, p - v);
                var right = GetCut(p + v, b);

                if (left.Item1 != null)
                    return left;
                else if (right.Item1 != null)
                    return right;
                else
                    return (null, null);
            }
        }

        public static (Point, Point) Cut(Point a, Point b, int x1, int x2, int y1, int y2)
        {
            X = new int[] { x1, x2 };
            Y = new int[] { y1, y2 };
            C = new int[] { x1, y1, x2, y2};

            var t = GetCut(a, b);

            return t;
        }
    }
}
