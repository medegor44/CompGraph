using System;
using System.Drawing;

namespace LinearAlgebra
{
    public class Vector2 : ICloneable
    {
        public int[] coord { get; private set; }

        public int X
        {
            get => coord[0];
            set => coord[0] = value;
        }

        public int Y
        {
            get => coord[1];
            set => coord[1] = value;
        }

        public Vector2()
        {
            coord = new int[3] { 0, 0, 1 };
        }

        public Vector2(int x, int y)
        {
            coord = new int[3] { x, y, 1 };
        }

        public Point ToPoint()
        {

            return new Point(X, Y);
        }

        public static Vector2 operator +(Vector2 v1, Vector2 v2)
        {
            Vector2 u = new Vector2();
            for (int i = 0; i < 2; i++)
                u.coord[i] = v1.coord[i] + v2.coord[i];
            return u;
        }

        public static Vector2 operator -(Vector2 v1, Vector2 v2)
        {
            Vector2 u = new Vector2();
            for (int i = 0; i < 2; i++)
                u.coord[i] = v1.coord[i] - v2.coord[i];
            return u;
        }

        public static Vector2 operator *(Vector2 v, int t)
        {
            return new Vector2(v.X * t, v.Y * t);
        }

        public static int operator ^(Vector2 u, Vector2 v)
        {
            return u.X * v.Y - u.Y * v.X;
        }

        public int Len
        {
            get
            {
                return (int)Math.Sqrt(X * X + Y * Y);
            }
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }

        public override bool Equals(object obj)
        {
            if (obj is null || !(obj is Vector2))
                return false;

            Vector2 v = (Vector2)obj;

            return v.X == X && v.Y == Y;
        }

        public override int GetHashCode()
        {
            return X * 1000000 + Y;
        }

        public static bool operator ==(Vector2 v1, Vector2 v2)
        {
            return v1.Equals(v2);
        }

        public static bool operator !=(Vector2 v1, Vector2 v2)
        {
            return !v1.Equals(v2);
        }

        public object Clone()
        {
            return new Vector2(X, Y);
        }
    }
}
