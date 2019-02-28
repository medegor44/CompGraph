using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGr
{
    public class Vector3
    {
        public float[] X { get; private set; }

        public Vector3()
        {
            X = new float[3] { 0, 0, 1 };
        }

        public Vector3(float x, float y)
        {
            X = new float[3] { x, y, 1};
        }

        public PointF ToPointF()
        {
            return new PointF(X[0], X[1]);
        }

        public static Vector3 operator +(Vector3 v1, Vector3 v2)
        {
            Vector3 u = new Vector3();
            for (int i = 0; i < 2; i++)
                u.X[i] = v1.X[i] + v2.X[i];
            return u;
        }

        public static Vector3 operator -(Vector3 v1, Vector3 v2)
        {
            Vector3 u = new Vector3();
            for (int i = 0; i < 2; i++)
                u.X[i] = v1.X[i] - v2.X[i];
            return u;
        }

        public static Vector3 operator *(Vector3 v, float t)
        {
            return new Vector3(v.X[0] * t, v.X[1] * t);
        }

        public float Len
        {
            get
            {
                return (float)Math.Sqrt(X[0] * X[0] + X[1] * X[1]);
            }
        }

        public override string ToString()
        {
            return $"({X[0]}, {X[1]})";
        }
    }
}
