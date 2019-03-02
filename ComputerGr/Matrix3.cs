using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGr
{
    public class Matrix3
    {
        public float[,] A { get; private set; }

        public Matrix3()
        {
            A = new float[3, 3] {
                { 1, 0, 0 },
                { 0, 1, 0 },
                { 0, 0, 1 }
            };
        }

        public Matrix3(float[,] a)
        {
            if ((a.GetLength(0) != 3 || a.GetLength(1) != 3) && (a.GetLength(0) != 2 || a.GetLength(1) != 2))
                throw new ArgumentException("Matrix must be 3x3 or 2x2");

            A = new float[3, 3];

            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    A[i, j] = a[i, j];

            if (a.GetLength(0) == 2)
                A[2, 2] = 1;
        }

        public Vector3 Apply(Vector3 x)
        {
            Vector3 y = new Vector3();
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    y.X[i] += A[i, j] * x.X[j];

            y.X[2] = 1;
            return y;
        }

        public static Vector3 operator *(Matrix3 m, Vector3 v)
        {
            return m.Apply(v);
        }

        public static Matrix3 operator *(Matrix3 a, Matrix3 b)
        {
            float[,] c = new float[3, 3];

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    for (int k = 0; k < 3; k++)
                        c[i, j] += a.A[i, k] * b.A[k, j];

            return new Matrix3(c);
        }

        public static Figure operator *(Matrix3 m, Figure f)
        {
            Vector3[] points = new Vector3[4];
            for (int i = 0; i < 4; i++)
                points[i] = m * f.Points[i];

            var up = new List<Vector3>();
            var down = new List<Vector3>();

            foreach (var v in f.Up)
                up.Add(m*v);
            foreach (var v in f.Down)
                down.Add(m*v);

            return new Figure(points[0], points[1], points[2], points[3], up, down, f.Origin, f.H);
        }
    }
}
