using System;
using System.Drawing;

namespace LinearOperations
{
    public class Vector
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

        public Vector()
        {
            coord = new int[3] { 0, 0, 1 };
        }

        public Vector(int x, int y)
        {
            coord = new int[3] { x, y, 1 };
        }

        public Point ToPoint()
        {
            return new Point(X, Y);
        }

        public static Vector operator +(Vector v1, Vector v2)
        {
            Vector u = new Vector();
            for (int i = 0; i < 2; i++)
                u.coord[i] = v1.coord[i] + v2.coord[i];
            return u;
        }

        public static Vector operator -(Vector v1, Vector v2)
        {
            Vector u = new Vector();
            for (int i = 0; i < 2; i++)
                u.coord[i] = v1.coord[i] - v2.coord[i];
            return u;
        }

        public static Vector operator *(Vector v, int t)
        {
            return new Vector(v.X * t, v.Y * t);
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
            if (obj is null || !(obj is Vector))
                return false;

            Vector v = (Vector)obj;

            return v.X == X && v.Y == Y;
        }

        public override int GetHashCode()
        {
            return X * 1000000 + Y;
        }

        public static bool operator ==(Vector v1, Vector v2)
        {
            return v1.Equals(v2);
        }

        public static bool operator !=(Vector v1, Vector v2)
        {
            return !v1.Equals(v2);
        }
    }

}
