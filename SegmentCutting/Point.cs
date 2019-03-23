using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegmentCutting
{
    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point()
        {
            X = 0;
            Y = 0;
        }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public System.Drawing.PointF ToPointF(float d, float h, float dx, float dy)
        {
            return new System.Drawing.PointF((float)X * d + dx, h - ((float)Y * d + dy));
        }

        public static Point operator -(Point a, Point b)
        {
            return new Point { X = a.X - b.X, Y = a.Y - b.Y };
        }

        public static Point operator +(Point a, Point b)
        {
            return new Point { X = a.X + b.X, Y = a.Y + b.Y };
        }

        public static Point operator *(Point a, double k)
        {
            return new Point { X = a.X * k, Y = a.Y * k };
        }

        public static Point operator /(Point a, double k)
        {
            return new Point { X = a.X / k, Y = a.Y / k };
        }

        public static double Dot(Point a, Point b)
        {
            return a.X * b.X + a.Y * b.Y;
        }

        public double Len
        {
            get => Math.Sqrt(X * X + Y * Y);
        }

        public override string ToString()
        {
            return string.Format($"({X}, {Y})");
        }
    }
}
