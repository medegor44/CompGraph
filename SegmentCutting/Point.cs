using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegmentCutting
{
    class Point
    {
        public float X { get; set; }
        public float Y { get; set; }

        public static Point operator -(Point a, Point b)
        {
            return new Point { X = a.X - b.X, Y = a.Y - b.Y };
        }

        public static Point operator +(Point a, Point b)
        {
            return new Point { X = a.X + b.X, Y = a.Y + b.Y };
        }

        public float Len
        {
            get => (float)Math.Sqrt(X * X + Y * Y);
        }

        public override string ToString()
        {
            return string.Format($"({X}, {Y})");
        }
    }
}
