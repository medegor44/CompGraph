using System;
using LinearAlgebra;

namespace ConvexHullAlgo
{
    public class Triangle
    {
        Vector2[] _vertices;

        public Vector2[] Vertices
        {
            get
            {
                return _vertices;
            }
            private set
            {
                if (value == null || value.Length != 3)
                    throw new ArgumentException("There must be three vertices");

                _vertices = value;
            }
        }

        public Triangle(Vector2 a, Vector2 b, Vector2 c)
        {
            Vertices = new Vector2[] { a, b, c };
        }

        public Triangle(Vector2[] vert)
        {
            Vertices = vert;
        }

        public static int SignedArea2(Triangle t)
        {
            return (t._vertices[1] - t._vertices[0]) ^ (t._vertices[2] - t._vertices[0]);
        }

        public static int Area2(Triangle t)
        {
            return Math.Abs(SignedArea2(t));
        }

        public bool Countains(Vector2 v)
        {
            int n = _vertices.Length;
            int area = 0;

            for (int i = 0; i < n; i++)
            {
                int s = Area2(new Triangle(v, _vertices[i], _vertices[(i + 1) % n]));
                if (s == 0)
                    return false;
                area += s;
            }

            return Area2(this) == area;
        }
    }
}
