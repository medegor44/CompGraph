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
            
            border.Remove(origin);

            border.Sort((x, y) => {
                int q = Math.Sign((x - origin) ^ (y - origin));

                if (q == 0)
                    return Math.Sign((x - origin).Len - (y - origin).Len);
                else
                    return q;
            });

            int start = -1;
            for (int i = border.Count - 2; i >= 0; i--)
                if (((border[i] - origin) ^ (border[border.Count - 1] - origin)) != 0)
                {
                    start = i + 1;
                    break;
                }

            border.Reverse(start, border.Count - start);

            border.Add(origin);

            return border;
        }
    }
}

/*
0 0
1 0 
2 0 
3 0
3 1
3 2
3 3
2 3
1 3
0 3
0 2
0 1
*/
