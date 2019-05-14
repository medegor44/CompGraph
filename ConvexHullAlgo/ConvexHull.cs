using System;
using LinearAlgebra;
using System.Collections.Generic;

namespace ConvexHullAlgo
{
    public static class Algorithm
    {
        public static List<Tuple<Vector2, Triangle>> GetSert(List<Vector2> points)
        {
            List<Tuple<Vector2, Triangle>> sert = new List<Tuple<Vector2, Triangle>>();
            int n = points.Count;

            foreach (var p in points)
            {
                bool found = false;
                for (int i = 0; i < n && !found; i++)
                    for (int j = i + 1; j < n && !found; j++)
                        for (int k = j + 1; k < n && !found; k++) 
                        {
                            var a = points[i];
                            var b = points[j];
                            var c = points[k];

                            Triangle t = new Triangle(a, b, c);

                            if (t.Countains(p))
                            {
                                sert.Add(new Tuple<Vector2, Triangle>(p, t));
                                found = true;
                            }
                        }

                if (!found)
                    sert.Add(new Tuple<Vector2, Triangle>(p, null));
            }

            return sert;
        }

        public static List<Vector2> Solve(List<Vector2> points)
        {
            List<Vector2> border = new List<Vector2>();
            int n = points.Count;

            Vector2 origin = null;

            foreach (var p in points)
            {
                bool found = false;
                for (int i = 0; i < n && !found; i++)
                    for (int j = i + 1; j < n && !found; j++)
                        for (int k = j + 1; k < n && !found; k++)
                        {
                            var a = points[i];
                            var b = points[j];
                            var c = points[k];

                            Triangle t = new Triangle(a, b, c);

                            if (t.Countains(p))
                            {
                                found = true;
                            }
                        }

                if (!found)
                {
                    border.Add(p);

                    if (origin is null || origin.X > p.X || origin.X == p.X && origin.Y > p.Y)
                        origin = p;
                }
            }

            border.Sort((x, y) => {
                return (x - origin) ^ (y - origin);
            });

            return border;
        }
    }
}
