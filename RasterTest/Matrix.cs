using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearOperations
{
    public class Matrix3
    {
        public int[,] A { get; private set; }

        public Matrix3()
        {
            A = new int[3, 3] {
                { 1, 0, 0 },
                { 0, 1, 0 },
                { 0, 0, 1 }
            };
        }

        public Matrix3(int[,] a)
        {
            if ((a.GetLength(0) != 3 || a.GetLength(1) != 3) && (a.GetLength(0) != 2 || a.GetLength(1) != 2))
                throw new ArgumentException("Matrix must be 3x3 or 2x2");

            A = new int[3, 3];

            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    A[i, j] = a[i, j];

            if (a.GetLength(0) == 2)
                A[2, 2] = 1;
        }

        public Vector Apply(Vector x)
        {
            Vector y = new Vector();
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    y.coord[i] += A[i, j] * x.coord[j];

            y.coord[2] = 1;
            return y;
        }

        public static Vector operator *(Matrix3 m, Vector v)
        {
            return m.Apply(v);
        }

        public static Matrix3 operator *(Matrix3 a, Matrix3 b)
        {
            int[,] c = new int[3, 3];

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    for (int k = 0; k < 3; k++)
                        c[i, j] += a.A[i, k] * b.A[k, j];

            return new Matrix3(c);
        }
    }

}
